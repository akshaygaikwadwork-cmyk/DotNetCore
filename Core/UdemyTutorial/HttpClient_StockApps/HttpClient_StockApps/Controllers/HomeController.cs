using HttpClient_StockApps.Models;
using HttpClient_StockApps.ServiceContract;
using HttpClient_StockApps.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HttpClient_StockApps.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFinHubService _finHubService;
        private readonly PublicTradingOptions _tradingOptions; //here we used ScretManager and set Token in configuration using terminal (dotnet user-secret set "KeyName" value
        public HomeController(IFinHubService finHubService, IOptions<PublicTradingOptions> tradingOptions)
        {
            _finHubService = finHubService;
            _tradingOptions = tradingOptions.Value;
        }


        [Route("/")]
        public async Task<IActionResult> Index()
        {
            if (_tradingOptions.DefaultStockSymbol == null)
                _tradingOptions.DefaultStockSymbol = "MSFT";
            Dictionary<string, object>? responseDictionary = await _finHubService.GetStockPriceQuote(_tradingOptions.DefaultStockSymbol);
            Stock stock = new Stock()
            {
                StockSymbol = _tradingOptions.DefaultStockSymbol,
                CurrentPrice = Convert.ToDecimal(responseDictionary?["c"].ToString()),
                LowestPrice = Convert.ToDecimal(responseDictionary?["l"].ToString()),
                HighestPrice = Convert.ToDecimal(responseDictionary?["h"].ToString()),
                OpenPrice = Convert.ToDecimal(responseDictionary?["o"].ToString()),
            };
            return View(stock);
        }
    }
}
