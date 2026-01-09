using CutomMiddlewareAssign;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//app.MapPost("/", async (HttpContext context) =>
//{
//    context.Response.Headers["Content-type"] = "text/html";
//    if(context.Request.Method == "POST")
//    {
//        StreamReader streamReader = new StreamReader(context.Request.Body);
//        string body = await streamReader.ReadToEndAsync();

//        Dictionary<string, StringValues> queryDict = QueryHelpers.ParseQuery(body);
//        context.Response.StatusCode = 400;
//        if (queryDict != null)
//        {
//            await context.Response.WriteAsync("Invalid input for email \nInvalid input for password");
//        }
//        if (!queryDict.ContainsKey("email") || string.IsNullOrEmpty(queryDict["email"][0]))
//        {
//            await context.Response.WriteAsync("Invalid input for email.");
//        }
//        if (!queryDict.ContainsKey("password") || string.IsNullOrEmpty(queryDict["password"][0]))
//        {
//            await context.Response.WriteAsync("Invalid input for password.");
//        }
//        else if (!string.IsNullOrEmpty(queryDict["email"][0]) && !string.IsNullOrEmpty(queryDict["password"][0]))
//        {
//            if ((queryDict["email"][0] == "admin@example.com") && (queryDict["password"][0] == "admin1234"))
//            {
//                context.Response.StatusCode = 200;
//                await context.Response.WriteAsync("Successful login");
//            }
//        }
//    }

//});

app.UseMiddlewareExtention();

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("No  response.");
});


app.Run();
