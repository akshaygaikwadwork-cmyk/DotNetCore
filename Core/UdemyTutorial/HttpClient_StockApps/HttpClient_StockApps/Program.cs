using HttpClient_StockApps;
using HttpClient_StockApps.ServiceContract;
using HttpClient_StockApps.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
//builder.Services.Configure<PublicTradingOptions>(builder.Configuration.GetSection("TradingOptions")); //This is an optional but best practice to define/implment this.
builder.Services.AddHttpClient<IFinHubService,FinHubService>()
                .SetHandlerLifetime(TimeSpan.FromMinutes(5));
builder.Services.AddScoped<IFinHubService, FinHubService>();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
