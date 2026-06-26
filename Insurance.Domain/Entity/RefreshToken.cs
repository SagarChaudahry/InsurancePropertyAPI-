using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Entity
{
    public class RefreshToken
    {
        public int Rfid { get; set; }
        public int UserId { get; set; }
        public string RefreshTokens { get; set; }
        public DateTime Expiry { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Status { get; set; }
    }
}
