using Microsoft.AspNetCore.Mvc;

namespace testing.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
