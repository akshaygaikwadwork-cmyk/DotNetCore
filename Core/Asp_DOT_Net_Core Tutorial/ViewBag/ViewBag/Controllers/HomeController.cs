using Microsoft.AspNetCore.Mvc;

namespace ViewBag.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            ViewBag.Datetime = DateTime.Now.ToShortTimeString();
            ViewBag.Age = 23;

            string[] arrList = { "Apple", "Mango", "Banana" };
            ViewBag.ArryList = arrList;

            ViewBag.List = new List<string>()
            {
                "1","2","3","4","5"
            };

            ViewData["data"] = "This value stored in ViewData but you are using Viewbag in View check it code";

            return View();
        }
    }
}
