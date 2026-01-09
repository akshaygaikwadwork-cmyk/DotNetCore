using Microsoft.AspNetCore.Mvc;

namespace AttributeBasedRouting.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
