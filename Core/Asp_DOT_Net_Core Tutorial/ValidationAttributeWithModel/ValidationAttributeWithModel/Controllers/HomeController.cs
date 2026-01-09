using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ValidationAttributeWithModel.Models;

namespace ValidationAttributeWithModel.Controllers
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
        public IActionResult Index(StudentModel obj)
        {
            if(ModelState.IsValid)
            {
                ViewBag.StudentName = " Name is : " + obj.Name + "<br> Email is : " + obj.Email + "<br> Age is : " + obj.Age + 
                    " <br> Password is : " + obj.Password + " <br> Mobile No is : " + obj.MobileNo + " <br> Confirm Password is : " + obj.ConfirmPassword;
            }
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