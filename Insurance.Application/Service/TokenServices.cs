using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Insurance.Application.Interface.IService;
using Insurance.Domain.Entity;
using Insurance.Domain;
using Microsoft.Extensions.Configuration;
using Insurance.Application.DTO;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Insurance.Application.Interface.IRepo;

namespace Insurance.Application.Service
{
    public class TokenServices(IConfiguration configuration, ITokenRepository tokenRepository) : ITokenServices
    {
        private readonly IConfiguration _config = configuration;
        private readonly ITokenRepository _tokenRepository = tokenRepository;


        public async Task<ApiResponse<LoginToken>> JwtResponseWithRefresh(User user, string oldRefreshToken = null)
        {
            var res = new ApiResponse<LoginToken>();
            try
            {
                var refreshToken = await CreateRefreshToken(user.UserId, user.RoleId.ToString());
                var rftsig = GetSignatureFromToken(refreshToken.RefreshTokens);

                int rfTknId;
                refreshToken.UserId = user.UserId;
                if (string.IsNullOrEmpty(oldRefreshToken ))
                {
                    // New login, set the refresh token
                    rfTknId = await _tokenRepository.SetRefreshTokenLogin(refreshToken);
                }
                else
                {
                    // Refresh logic
                    rfTknId = await _tokenRepository.SetRefreshToken(refreshToken, oldRefreshToken);
                }

                if (rfTknId <= 0)
                {
                    res.responseCode = "96";
                    res.message = "Error occurred while setting refresh token";
                    return res;
                }

                var loginToken = new LoginToken();
                var accessTokenExpiry = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["Jwt:AccessTokenExpiryInMin"]));
                string accessToken = CreateJwtToken(user.UserId.ToString(), user.UserName.ToString(), user.RoleId.ToString(), accessTokenExpiry, rftsig.ToString());

                res.responseCode = "00";
                loginToken.token_type = "Bearer";
                loginToken.access_token = accessToken;
                loginToken.expires_in = accessTokenExpiry;
                loginToken.refresh_token = refreshToken.RefreshTokens;

                res.result = loginToken;
                res.message = $"Success..";
                //res.UserId = user.UserId;
            }
            catch (Exception ex)
            {
                res.responseCode = "96";
                res.message = ex.Message;
            }
            return res;
        }

        private async Task<RefreshToken> CreateRefreshToken(int UserId, string role)
        {
            DateTime expires = DateTime.UtcNow.AddDays(Convert.ToDouble(_config["Jwt:RefreshTokenExpiryInDay"]));
            string token = CreateJwtToken(UserId.ToString(), Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)), role, expires, "0");
            var refreshtoken = new RefreshToken
            {
                RefreshTokens = token,
                Expiry = expires,
                CreatedAt = DateTime.Now
            };
            return refreshtoken;
        }


        private string CreateJwtToken(string userId, string username, string role, DateTime accessTokenExpiry, string rftsig)
        {
            // Claims
            List<Claim> claims = new()
    {
        //new Claim("1", userId),
        //new Claim("2", username),
        //new Claim("3", role),
        //new Claim("4", rftsig)
        new Claim(ClaimTypes.NameIdentifier, userId),
        new Claim(ClaimTypes.Name, username),
        new Claim(ClaimTypes.Role, role),
        new Claim("4", rftsig)
    };

            // Read key
            var keyBytes = Encoding.UTF8.GetBytes(_config["Jwt:APIKey"]!);
            var securityKey = new SymmetricSecurityKey(keyBytes);

            //  Signing credentials (JWT -> JWS)
            var signingCredentials = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha512Signature
            );
            var keyBytesenc = Encoding.UTF8.GetBytes(_config["Jwt:EncryptedKey"]!);
            var securityKeyenc = new SymmetricSecurityKey(keyBytesenc);

            //  Encrypting credentials (JWS -> JWE)
            var encryptingCredentials = new EncryptingCredentials(
                securityKeyenc,
                SecurityAlgorithms.Aes256KW,                 // Key wrap algorithm
                SecurityAlgorithms.Aes256CbcHmacSha512       // Content encryption algorithm
            );

            // Build token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = accessTokenExpiry,
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                SigningCredentials = signingCredentials,
                EncryptingCredentials = encryptingCredentials
            };

            // Create and return signed + encrypted token (nested JWT)
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = tokenHandler.CreateEncodedJwt(tokenDescriptor);
            return jwt;
        }
        private string GetSignatureFromToken(string token)
        {
            var parts = token.Split('.');
            if (parts.Length == 5)
            {
                var header = parts[0];
                var encryptedKey = parts[1];
                var iv = parts[2];
                var ciphertext = parts[3];
                var tag = parts[4];
                return tag;
            }
            return string.Empty;
        }

        public ClaimsPrincipal ValidateJwtToken(string token)
        {
            var key = Encoding.UTF8.GetBytes(_config.GetSection("Jwt:APIKey").Value!);
            var keyenc = Encoding.UTF8.GetBytes(_config.GetSection("Jwt:EncryptedKey").Value!);//whole lai encrypt garni kaam
            try
            {
                //create a token handler and validate the token
                var tokenHandler = new JwtSecurityTokenHandler();
                var claimsPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = _config["Jwt:Issuer"],
                    ValidAudience = _config["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    TokenDecryptionKey = new SymmetricSecurityKey(keyenc),
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken ValidatedToken);
                return claimsPrincipal;
            }
            catch (SecurityTokenExpiredException stee)
            {
                //Handle token expiration
                throw new ApplicationException("Token Has Expired");
            }
            catch (SecurityTokenException ex)
            {
                throw new ApplicationException($"Token Validation Failed: {ex.Message}");
            }
        }

        public async Task<ApiResponse<LoginToken>> CreateTempToken(User User, string Session)
        {
            var res = new ApiResponse<LoginToken>();
            var loginToken = new LoginToken();
            string token = CreateJwtToken(User.UserId.ToString(), Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)), User.RoleId.ToString(), DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["OtpService:TimeExpiredInMinutes"])), Session);
            res.responseCode = "202";
            loginToken.token_type = "Bearer";
            loginToken.access_token = token;

            res.result = loginToken;
            res.message = $"Success..";
            return res;
        }

    }
}