using CSV_GenerateFile.Models;
using CSV_GenerateFile.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSV_GenerateFile.Controllers
{
    public class CsvController : Controller
    {
        private readonly ICsvService _csvService;

        public CsvController(ICsvService csvService)
        {
            _csvService = csvService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DownloadCsv()
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

            var fileBytes = _csvService.GenerateCsv(userList);
            return File(fileBytes, "text/csv", "UserList.csv");
        }
    }
}
