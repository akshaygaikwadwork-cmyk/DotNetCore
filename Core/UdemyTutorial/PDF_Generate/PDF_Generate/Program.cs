using Rotativa.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Initialize Rotativa and set the correct path to wkhtmltopdf.exe
RotativaConfiguration.Setup(app.Environment.WebRootPath, "Rotativa");

app.UseRouting();
app.UseStaticFiles();
app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
