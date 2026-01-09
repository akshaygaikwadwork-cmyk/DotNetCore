using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace SecretManagerExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherAPIOptions _options;
        public HomeController(IOptions<WeatherAPIOptions> weatherAPIIptions)
        {
            _options = weatherAPIIptions.Value;
        }

        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.ClientId = _options.ClientId;
            ViewBag.ClientSecret = _options.ClientSecret;
            return View();
        }
    }
}
