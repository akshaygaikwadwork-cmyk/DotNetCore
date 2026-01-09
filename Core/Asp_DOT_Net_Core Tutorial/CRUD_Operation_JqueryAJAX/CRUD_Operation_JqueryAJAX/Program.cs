using CRUD_Operation_JqueryAJAX.Attribute;
using CRUD_Operation_JqueryAJAX.Configuration;
using CRUD_Operation_JqueryAJAX.Repository;
using CRUD_Operation_JqueryAJAX.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(options =>
{
    options.Filters.Add(typeof(ApplicationException_Handlercs));
});
// Add services to the container.

builder.Services.AddControllersWithViews();
var dbConnection = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContext<HotelDbContext>(options => options.UseSqlServer(dbConnection));
builder.Services.AddScoped<IHotel_Service, Hotel_Service>();
builder.Services.AddScoped<IHotel_Repository, Hotel_Repository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Hotel}/{action=GetHotelData}/{id?}");

app.Run();
