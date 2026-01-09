using Excel_GenerateFile.Models;
using Excel_GenerateFile.Services;
using Microsoft.AspNetCore.Mvc;

namespace Excel_GenerateFile.Controllers
{
    public class ExcelController : Controller
    {
        private readonly IExcelService _excelService;

        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DownloadExcel()
        {
            var userList = new List<UserData>
            {
                new UserData { Id = 1, Name = "Akshay", Email = "akshay@example.com" },
                new UserData { Id = 2, Name = "Vivek", Email = "vivek@example.com" },
                new UserData { Id = 3, Name = "Rhuddhi", Email = "rhuddhi@example.com" },
                new UserData { Id = 4, Name = "Drashti", Email = "drashti@example.com" },
                new UserData { Id = 5, Name = "Priyanka", Email = "priyanka@example.com" },
                new UserData { Id = 6, Name = "Pankaj", Email = "pankaj@example.com" }
            };

            var fileBytes = _excelService.GenerateExcel(userList);
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "UserList.xlsx");
        }
    }
}
