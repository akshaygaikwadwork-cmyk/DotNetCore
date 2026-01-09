using DIExample.Interface;
using DIExample.Repository;

var builder = WebApplication.CreateBuilder(args);
// Register services with different lifetimes
builder.Services.AddSingleton<SingletonGuidGenerator>();   // Singleton
builder.Services.AddTransient<TransientGuidGenerator>();   // Transient
builder.Services.AddScoped<ScopedGuidGenerator>();      // Scoped
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.MapDefaultControllerRoute();
app.Run();
