using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Application.Interface.IRepo;
using Insurance.Domain.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Infrastructure.Repository
{
    public class TokenRepository(ApplicationDBFactory context) : ITokenRepository
    {
        private readonly ApplicationDBFactory _context = context;
        public async Task<int> SetRefreshTokenLogin(RefreshToken DTO)
        {
            SqlParameter[] parameters =
            {
                new ("@UserId", DTO.UserId),
                new ("@Token", DTO.RefreshTokens),
                new ("@Expires", DTO.Expiry),
                new ("@Created", DTO.CreatedAt)
            };
            string query = @"
                INSERT INTO RefreshTokens (UserId, 	RefreshToken,	Expiry,	CreatedAt,	Status)
                VALUES (@UserId, @Token, @Expires, @Created,1)";
            int rowsAffected = await _context.Database.ExecuteSqlRawAsync(query, parameters);
            return rowsAffected;
        }

        public async Task<int> SetRefreshToken(RefreshToken DTO, string OldRefreshTkn)
        {
            SqlParameter[] parameters =
            {
                new ("@UserId", DTO.UserId),
                new ("@OldRefreshToken", OldRefreshTkn),
                new ("@Token", DTO.RefreshTokens),
                new ("@Expires", DTO.Expiry),
                new ("@Created", DTO.CreatedAt)
            };
            string query = @"
                Update RefreshTokens set RefreshToken=@Token,	Expiry=@Expires,	CreatedAt=@Created,	Status=1
                where UserId=@UserId and RefreshToken=@OldRefreshToken";
            int rowsAffected = await _context.Database.ExecuteSqlRawAsync(query, parameters);
            return rowsAffected;
        }
    }
}