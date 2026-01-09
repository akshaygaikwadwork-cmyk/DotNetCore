using Microsoft.AspNetCore.Mvc;

namespace ViewData.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Data1"] = "Akshay";
            ViewData["Data2"] = "Gaikwad";

            string[] arrList = { "Apple", "Banana", "Mango", "Pineapple" };
            ViewData["arrayListData"] = arrList;

            ViewData["GenericList"] = new List<string>()
            {
                "Cricket","Football","Badminton", "Hockey"
            };

            //Note - when passing arraylist or any other generic or non generic list then we need to type case in view in loop

            return View();
        }
    }
}
