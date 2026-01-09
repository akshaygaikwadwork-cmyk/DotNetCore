using SecretManagerExample;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.Configure<WeatherAPIOptions>(builder.Configuration.GetSection("weatherapi"));

//Loding my custom Json File (This is will consider higher priority)
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("MyCustomJsonFile.json", optional: true, reloadOnChange: true);
});
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.Run();
