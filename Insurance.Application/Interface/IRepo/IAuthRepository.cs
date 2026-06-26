using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Domain.Entity;

namespace Insurance.Application.Interface.IRepo
{
    public interface IAuthRepository
    {
        Task<string> Register(User user);
        //Task<User?> Login(string username);

        Task<User?> GetUserInfo(string username);




        Task<int> LogOut(LogoutParam LOP);
        Task<User?> CheckUsrDetails(int userid);
        
    }
}
