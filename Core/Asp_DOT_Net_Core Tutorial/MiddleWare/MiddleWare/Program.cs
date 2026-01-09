namespace MiddleWare
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");

            //Note - If you want to use multiple middleware then you have to use USE() middleware method RUN() it only run once 

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("This is 1st USE method middleware");
                await next();
                await context.Response.WriteAsync("\nreturn to 1st middleware");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("\nThis is 2nd USE method middleware");
                await next();
                await context.Response.WriteAsync("\nreturn to 2nd middleware");
            });

            app.Run(async(context) =>
            {
                await context.Response.WriteAsync("\nhello welcome to akshay first DotNetCore Application");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("\nThis is 3rd USE method middleware");
                await next();
                await context.Response.WriteAsync("\nreturn to 3rd middleware");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("\nThis is second Run Method i.e. middelware");
            });

            app.Run();
        }
    }
}