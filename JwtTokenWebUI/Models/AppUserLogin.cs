using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTokenWebUI.Models
{
    public class AppUserLogin
    {

        [Required(ErrorMessage ="Kullanıcı adı gereklidir")]
        [Display(Name = "Kullaıcı adı")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre adı gereklidir")]
        [Display(Name ="Şifer")]
        public string Password { get; set; }
    }
}
