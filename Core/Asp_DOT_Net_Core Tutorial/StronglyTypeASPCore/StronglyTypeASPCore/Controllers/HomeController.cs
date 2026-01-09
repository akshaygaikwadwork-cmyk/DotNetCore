using Microsoft.AspNetCore.Mvc;
using StronglyTypeASPCore.Models;
using System.Diagnostics;

namespace StronglyTypeASPCore.Controllers
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
            EmployeeModel employee = new EmployeeModel()
            {
                EmpId = 1,
                EmpName = "Akshay",
                Designation = "CEO",
                Salary = 250000
            };

            List<EmployeeModel> employee2 = new List<EmployeeModel>()
            {
                new EmployeeModel() {EmpId = 2,EmpName="Vievk",Designation="Software Developer",Salary=70000},
                new EmployeeModel() {EmpId = 3,EmpName="Ganesh",Designation="Database Administrator",Salary=60000},
                new EmployeeModel() {EmpId = 3,EmpName="Pranit",Designation="Project Manager",Salary=40000},
            };
            return View(employee2);
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