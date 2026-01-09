using Angular_Application.Model.Core;
using Microsoft.AspNetCore.Mvc;

namespace Angular_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 75000 },
            new Product { Id = 2, Name = "Smartphone", Price = 45000 },
            new Product { Id = 3, Name = "Tablet", Price = 30000 }
        };

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(products);
        }
    }
}
