using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Insurance.Application.DTO;
using Insurance.Application.Interface.IRepo;
using Insurance.Application.Interface.IService;
using Insurance.Domain;
using Insurance.Domain.Entity;

namespace Insurance.Application.Service
{
    public class AuthService(IHashingService hashingservice, IAuthRepository authrepo,ITokenServices TokenService) : IAuthService
    {
        private readonly IHashingService _hashingService = hashingservice;
        private readonly IAuthRepository _authrepo = authrepo;
        private readonly ITokenServices _tokenService = TokenService;
        public async Task<string> Register(User user)
        {
            try
            {


                _hashingService.CreatePasswordHash(user.Password, out string passwordHash, out string passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                string result = await _authrepo.Register(user);
                if (result == "Success")
                {
                    return "User registered successfully";
                }
                else
                {
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse<LoginToken> > Login(LoginRequest request)
        {
            var res = new ApiResponse<LoginToken>();
            try
            {
                var user = await _authrepo.GetUserInfo(request.UserName);

                if (user == null)
                {
                    res.responseCode = "401";
                    res.message = "Invalid username or password.";
                    return res;
                }
                

                bool verified = _hashingService.VerifyPasswordHash(
                    request.Password,
                    user.PasswordHash,
                    user.PasswordSalt);

                if (!verified)
                {
                    res.responseCode = "401";
                    res.message = "Invalid username or password.";
                    return res;
                }
                var token = await _tokenService.JwtResponseWithRefresh(user);
                res.responseCode = token.responseCode;
                res.result = token.result;
                res.message = token.message;
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }



        public async Task<ApiResponse<LoginToken>> GetRefreshToken(string token)
        {
            var res = new ApiResponse<LoginToken>();
            try
            {
                var tkn = _tokenService.ValidateJwtToken(token);
                if (tkn == null)
                {
                    res.responseCode = "97";
                    res.message = "Invalid token.";
                    return res;
                }
                var userId = tkn.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var userInfo = await _authrepo.CheckUsrDetails(Convert.ToInt32(userId));
                if (userInfo == null)
                {
                    res.responseCode = "97";
                    res.message = "User not found.";
                    return res;
                }
                var tokens = await _tokenService.JwtResponseWithRefresh(userInfo, token);
                res.responseCode = tokens.responseCode;
                res.result = tokens.result;
                res.message = tokens.message;
                return res;

            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public async Task<ApiResponse<int>> LogOut(LogoutParam LOP)
{
    try
    {
        var res = new ApiResponse<int>();
        var result = await _authrepo.LogOut(LOP);
        if (result > 0)
        {
            res.responseCode = "00";
            res.result = result;
            res.message = "Logout successful.";
            return res;

        }
        else
        {
            res.responseCode = "97";
            res.result = result;
            res.message = "Logout failed.";
            return res;
        }
    }
    catch (Exception ex)
    {
        return new ApiResponse<int>
        {
            responseCode = "500",
            result = 0,
            message = "An error occurred during logout. Please try again later."
        };
    }
}
    }
}