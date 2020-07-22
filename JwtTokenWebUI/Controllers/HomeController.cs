using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JwtTokenWebUI.Models;
using JwtTokenWebUI.ApiServices.Interfaces;

namespace JwtTokenWebUI.Controllers
{
    public class HomeController : Controller
    {  
        
        
        private readonly ILogger<HomeController> _logger;
        IProductApiService _productApiService;

   
        
      

        public HomeController(ILogger<HomeController> logger, IProductApiService productApiService)
        {
            _logger = logger;
            _productApiService = productApiService;
        }

        public async Task< IActionResult> Index()
        {
          var model=  await _productApiService.GetAllAsync();
            return View(model);
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Create(ProductAdd productAdd)
        {

            if (ModelState.IsValid)
            {
                await _productApiService.AddAsync(productAdd);

                RedirectToAction("Index","Home");
            }


            return View(productAdd);
        }
        public  IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
