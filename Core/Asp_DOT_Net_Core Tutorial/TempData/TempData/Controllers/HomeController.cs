using Microsoft.AspNetCore.Mvc;

namespace TempData.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Data"] = "ViewData";
            ViewBag.Data1 = "ViewBag";
            TempData["Data2"] = "TempData";
            TempData["Data3"] = "TempData";

            string[] arrList = { "Apple", "Banana", "Mango" };
            TempData["arryaList"] = arrList;

            TempData["List"] = new List<string>()
            {
                "1","2","3"
            };

            //Note -  if you want to keep TempData to other view then use .keep method

            TempData.Keep(); // this means it keep tempdata for About

            return View();
        }
        public IActionResult About()
        {
            TempData.Keep(); // this means it keep tempdata for Contact
            return View();
        }

        public IActionResult Contact()
        {
            TempData.Keep(); // this means it keep tempdata for Contact
            return View();
        }
    }
}
