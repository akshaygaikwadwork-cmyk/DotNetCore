using HttpClient_StockApps.ServiceContract;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace HttpClient_StockApps.Services
{
    public class FinHubService : IFinHubService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration; //here we used ScretManager and set Token in configuration using terminal (dotnet user-secret set "KeyName" value

        public FinHubService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol = "")
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            string requestUrl = $"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_configuration["FinHubToken"]}";

            HttpResponseMessage response = await httpClient.GetAsync(requestUrl);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"API request failed with status code {response.StatusCode}");

            string responseString = await response.Content.ReadAsStringAsync();

            try
            {
                var responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(responseString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (responseDictionary == null || responseDictionary.ContainsKey("error"))
                    throw new InvalidOperationException($"Error from API: {responseDictionary?["error"]}");

                return responseDictionary;
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Failed to parse API response", ex);
            }
        }
    }
}
