using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Insurance.Application.DTO;
using Insurance.Domain;
using Insurance.Domain.Entity;

namespace Insurance.Application.Interface.IService
{
    public interface ITokenServices 
    {
        Task<ApiResponse<LoginToken>> JwtResponseWithRefresh(User user, string oldRefreshToken = null);
        ClaimsPrincipal ValidateJwtToken(string token);
        Task<ApiResponse<LoginToken>> CreateTempToken(User User, string sessionToken);
    }
}
