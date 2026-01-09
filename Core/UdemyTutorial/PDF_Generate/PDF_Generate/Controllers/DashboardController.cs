using Microsoft.AspNetCore.Mvc;
using PDF_Generate.Models;
using Rotativa.AspNetCore;

namespace PDF_Generate.Controllers
{
    public class DashboardController : Controller
    {
        List<string> userList = new List<string>()
            {
                "Akshay",
                "Vivek",
                "Rhuddhi",
                "Drashti",
                "Priyanka",
                "Pankaj"
            };
        string DashboardTitle = "Dashboard Report";

        public IActionResult Index()
        {
            var model = new DashboardModel()
            {
                Title = DashboardTitle,
                Date = DateTime.Now,
                Users = userList
            };
            return View(model);
        }

        public IActionResult DownloadPdf()
        {
            var model = new DashboardModel()
            {
                Title = DashboardTitle,
                Date = DateTime.Now,
                Users = userList
            };

            return new ViewAsPdf("DownloadPdf", model)
            {
                FileName = "DashboardReport.pdf"
            };
        }
    }
}
