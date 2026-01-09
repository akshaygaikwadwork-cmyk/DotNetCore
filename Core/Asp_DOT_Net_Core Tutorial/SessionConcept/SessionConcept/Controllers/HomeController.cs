using Microsoft.AspNetCore.Mvc;
using SessionConcept.Models;
using System.Diagnostics;

namespace SessionConcept.Controllers
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
            HttpContext.Session.SetString("Key", "Welcome to session concept");
            TempData["SessionId"] = HttpContext.Session.Id;
            return View();
        }

        public IActionResult About()
        {
            //if( HttpContext.Session.GetString("Key") != null )
            //{
            //    ViewBag.SessionData = HttpContext.Session.GetString("Key");
            //}
            return View();
        }

        public IActionResult Details()
        {
            if (HttpContext.Session.GetString("Key") != null)
            {
                ViewBag.SessionData = HttpContext.Session.GetString("Key");
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