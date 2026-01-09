using CustomeMiddlewareExtensions.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("First middleware start");
    await next(context);
    await context.Response.WriteAsync("\nFirst middleware end");

});

app.UseMyCustomMiddleware();

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("\nLast middleware start");
});

app.Run();