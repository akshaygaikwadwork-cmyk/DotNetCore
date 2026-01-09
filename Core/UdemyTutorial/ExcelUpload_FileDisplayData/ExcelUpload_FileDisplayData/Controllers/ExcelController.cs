using ExcelUpload_FileDisplayData.Models;
using ExcelUpload_FileDisplayData.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExcelUpload_FileDisplayData.Controllers
{
    public class ExcelController : Controller
    {
        private readonly IExcelService _excelService;

        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadExcel(IFormFile file)
        {
            var (userList, errorMessage) = await _excelService.ReadExcelAsync(file);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                ViewBag.ErrorMessage = errorMessage;
                return View("Index", new List<UserData>());
            }

            return View("Index", userList);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new List<UserData>());
        }
    }
}
