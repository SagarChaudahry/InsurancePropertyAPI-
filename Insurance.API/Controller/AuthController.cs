using System.Security.Claims;
using Insurance.Application.DTO;
using Insurance.Application.Interface.IService;
using Insurance.Application.Service;
using Insurance.Domain;
using Insurance.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authservice) : ControllerBase
    {
        private readonly IAuthService _authservice = authservice;
        private void SetRefreshCookie(string Refreshtoken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = false, // Only over HTTPS
                                // Secure = true, // Only over HTTPS
                SameSite = SameSiteMode.Strict, // Prevent cross-origin use
                Expires = DateTime.UtcNow.AddMinutes(5)
            };

            Response.Cookies.Append("refreshTokenInsurance", Refreshtoken, cookieOptions);
        }

        private void SetAccessTokenCookie(string Accesstoken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = false, // Only over HTTPS
                                // Secure = true, // Only over HTTPS
                SameSite = SameSiteMode.Strict, // Prevent cross-origin use
                Expires = DateTime.UtcNow.AddMinutes(5)
            };

            Response.Cookies.Append("AccessTokenInsurance", Accesstoken, cookieOptions);
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                string result = await _authservice.Register(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            try
            {
                var result = await _authservice.Login(request);
                if(result.responseCode=="00")
                {
                    SetAuthCookies(result.result);        
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost("RefreshToken"),Authorize]
        public async Task<IActionResult> RefreshToken() { 
            try
            {

                var refreshtoken = Request.Cookies["refreshTokenInsurance"];
                if (refreshtoken == null)
                {
                    return BadRequest("Refresh token not found.");
                }
                var result = await _authservice.GetRefreshToken(refreshtoken);
                if (result.responseCode == "00")
                {
                    SetAuthCookies(result.result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private void SetAuthCookies(LoginToken token)
        {
            Response.Cookies.Delete("AccessTokenInsurance");
            Response.Cookies.Delete("refreshTokenInsurance");

            SetAccessTokenCookie(token.access_token);
            SetRefreshCookie(token.refresh_token);
        }
        [HttpPost ("Logout")]
        public async Task<ActionResult<ApiResponse<int>>> Logout()
        {
            try
            {
                int UserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                var refreshtoken = Request.Cookies["refreshTokenInsurance"];
                var result = await _authservice.LogOut(new LogoutParam { UserId = UserId, RefreshToken = refreshtoken });
                Response.Cookies.Delete("AccessTokenInsurance");
                Response.Cookies.Delete("refreshTokenInsurance");
                return Ok(new ApiResponse<int>
                {
                    result = 1,
                    responseCode = "00",
                    message = "Logged out successfully",
                });


            }
            catch (Exception ex)
            {
                return BadRequest("Error processing request");
            }
        }
    }



}