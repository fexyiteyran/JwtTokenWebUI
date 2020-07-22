using JwtTokenWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTokenWebUI.ApiServices.Interfaces
{
 public   interface IProductApiService
    {

        Task<List<ProductList>> GetAllAsync();
        Task AddAsync(ProductAdd productAdd);
    }
}
