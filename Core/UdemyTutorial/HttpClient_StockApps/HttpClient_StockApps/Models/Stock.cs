namespace HttpClient_StockApps.Models
{
    public class Stock
    {
        public string? StockSymbol { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal LowestPrice { get; set; }
        public decimal HighestPrice { get; set; }
        public decimal OpenPrice { get; set; }
    }
}
