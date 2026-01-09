using CheckBox.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CheckBox.Controllers
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
            var model = new ViewModel()
            {
                //Following for single checkbox
                AcceptTerm = false,
                CheckBoxText = "I Accept the terms",

                //Following for multi checkbox
                Options = new List<CheckBoxOptionModel>()
                {
                    new CheckBoxOptionModel()
                    {
                        IsChecked = true,
                        Text = "Cricket",
                        Value = "Cricket"
                    },
                    new CheckBoxOptionModel()
                    {
                        IsChecked = false,
                        Text = "Football",
                        Value = "Football"
                    },
                    new CheckBoxOptionModel()
                    {
                        IsChecked = false,
                        Text = "Hockey",
                        Value = "Hockey"
                    },
                }
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(ViewModel modelObj)
        {
            var model = new ViewModel()
            {
                //Following for single checkbox
                AcceptTerm = false,
                CheckBoxText = "I Accept the terms",

                //Following for multi checkbox
                Options = new List<CheckBoxOptionModel>()
                {
                    new CheckBoxOptionModel()
                    {
                        IsChecked = true,
                        Text = "Cricket",
                        Value = "Cricket"
                    },
                    new CheckBoxOptionModel()
                    {
                        IsChecked = false,
                        Text = "Football",
                        Value = "Football"
                    },
                    new CheckBoxOptionModel()
                    {
                        IsChecked = false,
                        Text = "Hockey",
                        Value = "Hockey"
                    },
                }
            };
            ViewBag.CheckBoxSelectedList = modelObj.sports;
            return View(model);
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