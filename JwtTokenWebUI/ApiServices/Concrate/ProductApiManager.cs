using JwtTokenWebUI.ApiServices.Interfaces;
using JwtTokenWebUI.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JwtTokenWebUI.ApiServices.Concrate
{
    public class ProductApiManager:IProductApiService
    {

        private readonly IHttpContextAccessor _accessor;
        public ProductApiManager(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public async Task AddAsync(ProductAdd productAdd)
        {
            var token = _accessor.HttpContext.Session.GetString("Token");

            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var jsonData = JsonConvert.SerializeObject(productAdd);
                var stringContent = new StringContent(jsonData, Encoding.UTF8,"application/json");

             var responceMessage=   await httpClient.PostAsync("http://localhost:50853/api/products", stringContent);

                if (responceMessage.IsSuccessStatusCode)
                {

                }

            }


            //throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var token = _accessor.HttpContext.Session.GetString("Token");

            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                 var responceMessage = await httpClient.DeleteAsync($"http://localhost:50853/api/products/{id}");


            }
        }
            public  async Task<List<ProductList>> GetAllAsync()
        {

          
            var token = _accessor.HttpContext.Session.GetString("Token");
              //  if (!string.IsNullOrWhiteSpace(token))
              //{


                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                   var responceMessage=  await   httpClient.GetAsync("http://localhost:50853/api/products");

                //if (responceMessage.IsSuccessStatusCode)
                //{
                  return JsonConvert.DeserializeObject<List<ProductList>> ( await  responceMessage.Content.ReadAsStringAsync());
            //    }
            //}
            //else
            //{
            //    return null;
            //}
        }

        public async Task<ProductList> GetByIdAsync(int id)
        {
            var token = _accessor.HttpContext.Session.GetString("Token");

            if (!string.IsNullOrWhiteSpace(token))
            {


                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responceMessage = await httpClient.GetAsync($"http://localhost:50853/api/products/{id}");
                if (responceMessage.IsSuccessStatusCode)
                {
                    
                    var pruduct= JsonConvert.DeserializeObject<ProductList>(await responceMessage.Content.ReadAsStringAsync());
                    return pruduct;
                }
            }


            return null;
        
        }

        public async Task UpdateAsync(ProductList productList)
        {
            var token = _accessor.HttpContext.Session.GetString("Token");

            if (!string.IsNullOrWhiteSpace(token))
            {


                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var jsonData = JsonConvert.SerializeObject(productList);
                var stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
                var responceMessage = await httpClient.PutAsync($"http://localhost:50853/api/products",stringContent);
                //if (responceMessage.IsSuccessStatusCode)
                //{

                //    var pruduct = JsonConvert.DeserializeObject<ProductList>(await responceMessage.Content.ReadAsStringAsync());
                //    return pruduct;
                //}
            }
        }
    }
}
