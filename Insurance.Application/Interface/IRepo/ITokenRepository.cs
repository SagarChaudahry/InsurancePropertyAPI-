using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Domain.Entity;

namespace Insurance.Application.Interface.IRepo
{
    public interface ITokenRepository
    {
        Task<int> SetRefreshTokenLogin(RefreshToken DTO);
        Task<int> SetRefreshToken(RefreshToken DTO, string OldRefreshTkn);
    }
}
