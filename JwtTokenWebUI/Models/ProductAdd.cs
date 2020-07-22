using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTokenWebUI.Models
{
    public class ProductAdd
    {
        [Required(ErrorMessage ="Ad alnanı boş geçilemez")]
      public  string Name { get; set; }
    }
}
