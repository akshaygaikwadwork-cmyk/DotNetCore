using Microsoft.AspNetCore.Mvc;

namespace AttributeBasedRouting.Controllers
{
    [Route("Home")]
    //OR
    //[Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        [Route("")]
        //[Route("Home")]
        //[Route("Home/Index")]
        [Route("Index")] // because controller having Routing eith name Home so we don't need to pass Home again and again
        [Route("~/")]
        [Route("~/Home")]
        public IActionResult Index()
        {
            return View();
        }

        //[Route("Home/About")]
        [Route("About")] // because controller having Routing eith name Home so we don't need to pass Home again and again
        public IActionResult About()
        {
            return View();
        }

        //[Route("Home/Details/{id}")]
        [Route("Details/{id}")] // because controller having Routing eith name Home so we don't need to pass Home again and again
        public int Details(int? id) //?
        {
            return id ?? 1; //null collasce operator but add ? at delcare time
        }
    }
}
