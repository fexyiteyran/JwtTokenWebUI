using JwtTokenWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTokenWebUI.ApiServices.Interfaces
{
  public  interface IAuthSrvice
    {

        Task<bool> Login(AppUserLogin appUserLogin);
        void LogOut();

    }
}
