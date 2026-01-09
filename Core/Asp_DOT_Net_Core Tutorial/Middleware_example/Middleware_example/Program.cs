using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseExceptionHandler("/Home/Error");
// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.  
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("This is from use method before next method\n");
    await next();
    await context.Response.WriteAsync("This is from use method after next method\n");
});

app.MapGet("/home", () => "Welcome Ak\n");

app.Map("/about", about =>
{
    about.Run(async context =>
    {
        await context.Response.WriteAsync("This is from run method using Map method\n");
    });
    app.Use(async (context, next) =>
    {
        await context.Response.WriteAsync("This is from use method using Map method before next method\n");
        await next();
        await context.Response.WriteAsync("This is from use method using Map method after next method\n");
    });
    about.Run(async context =>
    {
        await context.Response.WriteAsync("This is from 2nd run method using Map method\n");
    });
    app.Run(async context =>
    {
        await context.Response.WriteAsync("This is from 3rd run method using Map method\n");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync("From normal Run method\n");
});
//app.MapGet("/", () => "Hello World!\n");

//app.Use(async (context, next) =>
//{
//    Debug.WriteLine("A (before)\n");
//    await next();
//    Debug.WriteLine("A (after)\n");
//});

//// Middleware B
//app.Map("/abc", a =>
//{
//    a.Use(async(context, next ) =>
//    {
//        await next();
//       await context.Response.WriteAsync("This is from Map method");
//    });
//});

//// Middleware C (terminal)
//app.Run(async context =>
//{
//    Debug.WriteLine("C (end MiddleWare in pipeline)\n");
//    await context.Response.WriteAsync("Hello world from run method\n");
//});

app.Run();
