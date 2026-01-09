using Microsoft.AspNetCore.Mvc;

namespace LayoutExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        //Note - We created Layout -
        /*
         1. Created Shared folder in Views
         2. In Shared folder we created new Razor Layout page => Add => new item => Razor Layout
        */
          
         
    }
}
