var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    context.Response.ContentType = "text/html";
    string path = context.Request.Path;
    string methodType = context.Request.Method;
    await context.Response.WriteAsync($"<h1> Path :  {path} </h1>");
    await context.Response.WriteAsync($"<h1> Method Type :  {methodType} </h1>");
});
app.Run();
