using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ViewModel_MultiModelInOneView.Models;

namespace ViewModel_MultiModelInOneView.Controllers
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
            List<Student> students = new List<Student>()
            {
                new Student {Id = 1, Name = "Akshay", Gender = "Male", Standard = 12},
                new Student {Id = 2, Name = "Vivek", Gender = "Male", Standard =23},
                new Student {Id = 3, Name = "Ganesh", Gender = "Male", Standard = 33},
                new Student {Id = 4, Name = "Pranit", Gender = "Male", Standard = 33},
            };
            List<TeacherModel> teachers = new List<TeacherModel>()
            {
                new TeacherModel {Id = 1, TeacherName = "Akshay", Qualification = "BSC", Salary = 12000},
                new TeacherModel {Id = 2, TeacherName = "Vivek", Qualification = "MSC", Salary = 312000 }  ,
                new TeacherModel {Id = 3, TeacherName = "Ganesh", Qualification = "Diploma", Salary = 212000 },
                new TeacherModel {Id = 4, TeacherName = "Pranit",  Qualification = "BOM", Salary = 312000},
            };

            SchoolViewModel schoolViewModel = new SchoolViewModel()
            {
                Students = students,
                Teachers = teachers
            };

            return View(schoolViewModel);
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