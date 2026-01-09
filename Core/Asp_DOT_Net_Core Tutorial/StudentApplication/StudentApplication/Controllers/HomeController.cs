using Microsoft.AspNetCore.Mvc;
using StudentApplication.Models;
using StudentApplication.Services;
using System.Diagnostics;

namespace StudentApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentService _studentService;

        public HomeController(IStudentService service)
        {
            _studentService = service;
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
                int result = _studentService.AddStudent(obj);
                string Msg = string.Empty;
                if (result > 0)
                {
                    Msg = "Data insert successfully";
                }
                else
                {
                    Msg = "Data insert failed";
                }
            }
            return View(obj);
        }


        public IActionResult About()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Index(StudentModel studentModel)
        //{
        //    if(ModelState.IsValid)
        //    {

        //    }
        //    return View(studentModel);
        //}

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
