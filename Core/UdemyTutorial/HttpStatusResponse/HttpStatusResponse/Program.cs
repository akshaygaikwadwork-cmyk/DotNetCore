var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    context.Response.ContentType = "text/html";
    //OR
    //context.Response.Headers["ContentType"] = "text/html";
    context.Response.Headers["Server"] = "Akshay";
    await context.Response.WriteAsync("<h1> Hello </h1>");
    await context.Response.WriteAsync("<h1> World </h1>");
});
app.Run();
