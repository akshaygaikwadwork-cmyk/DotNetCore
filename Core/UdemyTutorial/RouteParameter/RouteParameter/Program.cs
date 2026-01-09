var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

//defaulr values will only work in UseEndpoints it will not work in Map because in dot net core UseEndpoints only supports the default values. Because of Map it's used for minimal API so default value is not supported in Map
//app.UseEndpoints(endpoint =>
//{
//    endpoint.Map("/file/{filename}/{extension}", async context =>
//    {
//        if (context.Request.RouteValues.ContainsKey("extension"))
//        {
//            string? fileName = context.Request.RouteValues["filename"].ToString();
//            string? extension = context.Request.RouteValues["extension"].ToString();
//            await context.Response.WriteAsync($"In files - {fileName}.{extension}");
//        }
//        else
//        {
//            await context.Response.WriteAsync("extension data is null");
//        }

//    });
//    endpoint.Map("/employee/profile/{employeename=harsh}", async context =>
//    {
//        string? employeename = context.Request.RouteValues["employeename"].ToString();
//        await context.Response.WriteAsync($"In employeename - {employeename}");
//    });
//});

app.Map("/file/{filename}.{extension = chup}", async context =>
{
    string? fileName = context.Request.RouteValues["filename"]?.ToString();
    string? extension = context.Request.RouteValues["extension"]?.ToString();
    await context.Response.WriteAsync($"In files - {fileName}.{extension}");
});
app.Map("/employee/profile/{employeename = harsh}", async context =>
{
    string? employeename = context.Request.RouteValues["employeename"]?.ToString();
    await context.Response.WriteAsync($"In employeename - {employeename}");
});

app.Run(async context =>
{
    await context.Response.WriteAsync($"URL is - {context.Request.Path}");
});

app.Run();
