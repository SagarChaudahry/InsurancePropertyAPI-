using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.DTO
{
    public class LoginToken
    {
        public string token_type { get; set; } = string.Empty;
        public string access_token { get; set; } = string.Empty;
        public DateTime expires_in { get; set; }
        public string refresh_token { get; set; } = string.Empty;
    }
    //public class RefreshToken
    //{
    //    public string Token { get; set; } = string.Empty;
    //    public DateTime Created { get; set; }
    //    public DateTime Expires { get; set; }
    //}


}
