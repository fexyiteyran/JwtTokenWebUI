using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtTokenWebUI.ApiServices.Interfaces;
using JwtTokenWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace JwtTokenWebUI.Controllers
{
    public class AcountController : Controller
    {
      private readonly  IAuthSrvice _authSrvice;
        public AcountController(IAuthSrvice authSrvice)
        {
            _authSrvice = authSrvice;
        }
        
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async  Task< IActionResult> SignIn(AppUserLogin  appUserLogin)
        {

            if (ModelState.IsValid)
            {
                if (await _authSrvice.Login(appUserLogin))
                {

                }

                ModelState.AddModelError("","Kullanıcı adı veya şifre hatlı");
            }
            return View(appUserLogin);
        }
    }
}