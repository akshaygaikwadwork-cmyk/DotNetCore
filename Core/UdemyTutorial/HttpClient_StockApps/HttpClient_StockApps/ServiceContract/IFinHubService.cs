using System.Globalization;

namespace HttpClient_StockApps.ServiceContract
{
    public interface IFinHubService
    {
        Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol);
    }
}
