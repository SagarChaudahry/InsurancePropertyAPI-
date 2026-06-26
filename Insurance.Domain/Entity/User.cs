using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; } = string.Empty;
        public string? PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public int Status { get; set; }
        public string Password { get; set; }

    }
}
