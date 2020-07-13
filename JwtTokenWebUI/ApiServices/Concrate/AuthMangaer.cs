using JwtTokenWebUI.ApiServices.Interfaces;
using JwtTokenWebUI.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JwtTokenWebUI.ApiServices.Concrate
{
    public class AuthMangaer : IAuthSrvice
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthMangaer(IHttpContextAccessor httpContextAccessor)
        {

            
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> Login(AppUserLogin appUserLogin)
        {
            string jsonData = JsonConvert.SerializeObject(appUserLogin);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            using var httpClient = new  HttpClient();
          var responsMessage=  await httpClient.PostAsync("http://localhost:50853/api/Auth/Signin", stringContent);

            if (responsMessage.IsSuccessStatusCode)
            {
                var token = JsonConvert.DeserializeObject<AccessToken>(await responsMessage.Content.ReadAsStringAsync());
                _httpContextAccessor.HttpContext.Session.SetString("Token", token.Token);

                return true;
            }
            else
            {
               return false;
            }
          
        }

        public void LogOut()
        {
            _httpContextAccessor.HttpContext.Session.Remove("Token");
        }
    }
}
