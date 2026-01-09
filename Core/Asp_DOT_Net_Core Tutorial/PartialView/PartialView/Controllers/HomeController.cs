using Microsoft.AspNetCore.Mvc;
using PartialView.Models;
using System.Diagnostics;

namespace PartialView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Products()
        {
            List<Product> products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Bata Shoes", Description = "Description Bata Shoes", Price = 10000, Image = "~/Images/WorldHealthDay_Offer.png"},
                new Product() { Id = 2, Name = "Nike Shoes", Description = "Description Nike Shoes", Price = 10000, Image = "~/Images/noodles.jpeg"},
                new Product() { Id = 3, Name = "Sports Shoes", Description = "Description Sports Shoes", Price = 10000, Image = "~/Images/maggi.jpeg"}
            };
            return View(products);
        }

        public IActionResult Privacy()
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