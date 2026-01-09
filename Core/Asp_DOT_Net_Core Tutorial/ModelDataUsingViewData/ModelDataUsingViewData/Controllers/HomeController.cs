using Microsoft.AspNetCore.Mvc;
using ModelDataUsingViewData.Models;
using System.Diagnostics;

namespace ModelDataUsingViewData.Controllers
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
                EmpId = 101,
                EmpName = "Akshay",
                Designation = "CEO",
                Salary = 400000
            };

            ViewData["EmployeeDtl"] = employee;

            ViewBag.EmployeeDtl = employee;

            TempData["EmployeeDtl"] = employee;

            List<EmployeeModel> employeeModel = new List<EmployeeModel>()
            {
                new EmployeeModel() {EmpId=1,EmpName="Akshay",Designation="CEO",Salary=400000},
                new EmployeeModel() {EmpId=1,EmpName="Rhoit",Designation="HR",Salary=50000},
                new EmployeeModel() {EmpId=1,EmpName="Sai",Designation="Manager",Salary=100000},
            };

            ViewData["EmployeeDtl_list"] = employeeModel;

            ViewBag.EmployeeDtl_list = employeeModel;

            TempData["EmployeeDtl_list"] = employeeModel;
            return View();
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