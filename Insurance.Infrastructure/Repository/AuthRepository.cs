using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Insurance.Application.Interface.IRepo;
using Insurance.Domain.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Insurance.Application.Service;
using Microsoft.EntityFrameworkCore;
using Insurance.Infrastructure;

namespace Insurance.Infrastructure.Repository
{
    public class AuthRepository(ApplicationDBFactory dbcontext) : IAuthRepository
    {
        private readonly ApplicationDBFactory _dbContext = dbcontext;
        public async Task<string> Register(User user)
        {
            try
            {
                SqlParameter[] parameters =
                {

                    new("@Username", user.UserName),
                    new("@PasswordHash", user.PasswordHash),
                    new("@PasswordSalt", user.PasswordSalt),
                    new("@Email", user.Email),
                    new("@RoleId", user.RoleId),
                    new("@Status", user.Status),
                    new("@Contact", user.Contact)
                };

                int rowsaffected = await _dbContext.Database.ExecuteSqlRawAsync(
                    "Insert Into Users ( Username, PasswordHash, PasswordSalt, Email, RoleId, Status,Contact) VALUES(@Username, @PasswordHash, @PasswordSalt, @Email, @RoleId, @Status,@Contact)",
                    parameters);
                return rowsaffected > 0 ? "Success" : "Failed";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<User?> GetUserInfo(string username)
        {
            try
            {
                SqlParameter[] parameters =
     {
        new SqlParameter("@UserName", username)
    };

                var query = @"
        SELECT
            UserId,
            UserName,
            PasswordHash,
            PasswordSalt,
            RoleId,
            Email,
            Contact,
            Status,
           'Password' as Password
        FROM Users
        WHERE UserName = @UserName";

                var result = await _dbContext.Database
                    .SqlQueryRaw<User>(query, parameters)
                    .FirstOrDefaultAsync();
                return result;
            }
            catch
            {
                throw;
            }
        }



        public async Task<User?> CheckUsrDetails(int userid)
        {
            try
            {
                SqlParameter[] parameters =
     {
        new SqlParameter("@Userid", userid)
    };

                var query = @"
        SELECT
            UserId,

            UserName,
            PasswordHash,
            PasswordSalt,
            RoleId,
            Email,
            Contact,
            Status,
           'Password' as Password
        FROM Users
        WHERE UserId = @Userid";

                var result = await _dbContext.Database
                    .SqlQueryRaw<User>(query, parameters)
                    .FirstOrDefaultAsync();
                return result;
            }
            catch
            {
                throw;
            }
        }


        public async Task<int> LogOut(LogoutParam LOP)
        {
            try
            {
                SqlParameter[] parameters =
     {
        new SqlParameter("@Userid", LOP.UserId),
        new SqlParameter("@RefreshToken", LOP.RefreshToken)

    };


                return await _dbContext.Database.ExecuteSqlRawAsync("Delete From RefreshTokens where UserId = @UserId and RefreshToken = @RefreshToken", parameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}