using Microsoft.AspNetCore.Mvc;
using ModelBindingAspCore.Models;
using System.Diagnostics;

namespace ModelBindingAspCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string Index(EmployeeModel obj)
        {
            return "Name : " + obj.Name + " Age : " + obj.Age + " Salary : " + obj.Salary + " Gender : " + obj.Gender +  " Designation : " + obj.Designation + " Married : " + obj.Married + " Description : " +obj.Description;
        }

        public string Details(string name, int id)
        {
            return "Id is : " + id + " Name is : " + name;
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