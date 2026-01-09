using Microsoft.AspNetCore.Mvc;
using ModelEx.Models;
using System.Diagnostics;

namespace ModelEx.Controllers
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
            var studenLit = new List<Student>()
            {
                new Student {Id=1, Name="Akshay", Age=23},
                new Student {Id=1, Name="Pankaj", Age=24},
                new Student {Id=1, Name="Satyaprakash", Age=24}
            };

            ViewData["StudentList"] = studenLit; 
            return View();
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