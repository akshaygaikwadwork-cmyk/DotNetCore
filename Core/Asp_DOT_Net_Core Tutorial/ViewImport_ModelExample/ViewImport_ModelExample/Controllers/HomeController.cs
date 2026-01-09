using Microsoft.AspNetCore.Mvc;
using ViewImport_ModelExample.Model;

namespace ViewImport_ModelExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Student> student = new List<Student>()
            {
                new Student { Id = 1, Name = "Akshay", Age = 21, City = "Mumbai"},
                new Student { Id = 2, Name = "Ganesh", Age = 21, City = "Thane"},
                new Student { Id = 3, Name = "Vivek", Age = 21, City = "Pune"},
                new Student { Id = 4, Name = "Pranit", Age = 21, City = "Satara"},
            };
            return View(student);
        }

        public IActionResult About()
        {
            List<Student> student = new List<Student>()
            {
                new Student { Id = 1, Name = "Akshay", Age = 21, City = "Mumbai"},
                new Student { Id = 2, Name = "Ganesh", Age = 21, City = "Thane"},
                new Student { Id = 3, Name = "Vivek", Age = 21, City = "Pune"},
                new Student { Id = 4, Name = "Pranit", Age = 21, City = "Satara"},
            };
            return View(student);
        }
    }
}
