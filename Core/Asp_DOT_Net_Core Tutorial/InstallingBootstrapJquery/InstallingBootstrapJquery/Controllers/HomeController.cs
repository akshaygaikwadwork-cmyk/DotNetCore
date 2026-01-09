using Microsoft.AspNetCore.Mvc;

namespace InstallingBootstrapJquery.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
