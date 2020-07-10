using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTokenWebUI.Models
{
    public class AppUser
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public List<string> Roles { get; set; }
    }
}
