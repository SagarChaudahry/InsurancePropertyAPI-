using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Application.DTO;
using Insurance.Domain;
using Insurance.Domain.Entity;

namespace Insurance.Application.Interface.IService
{
    public interface IAuthService
    {
        Task<string> Register(User user);


        Task<ApiResponse<LoginToken>> Login(LoginRequest request);
        Task<ApiResponse<LoginToken>> GetRefreshToken(string token);
        Task<ApiResponse<int>> LogOut(LogoutParam LOP);

    }
}
