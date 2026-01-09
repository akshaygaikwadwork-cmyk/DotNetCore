namespace MapMethodsRouting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //Following will run on gte/post/put/delete on every http request verb
            //app.Map("/Home", () => "Hello World!");

            //Following only For Single Line

            //app.MapGet("/Home", () => "Hello World!  - This MapGET method it will work only GET Request");
            //app.MapPost("/Home", () => "Hello World!  - This MapPOST method it will work only POST Request");
            //app.MapPut("/Home", () => "Hello World!  - This MapPUT method it will work only PUT Request");
            //app.MapDelete("/Home", () => "Hello World!  - This MapDELETE method it will work only DELETE Request");


            //Following for multiline statement
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/Home", async (context) =>
                {
                    await context.Response.WriteAsync("This message come from ENDPoint MapGET method");
                });
                endpoints.MapPost("/Home", async (context) =>
                {
                    await context.Response.WriteAsync("This message come from ENDPoint MapPOST method");
                });
                endpoints.MapPut("/Home", async (context) =>
                {
                    await context.Response.WriteAsync("This message come from ENDPoint MapPUT method");
                });
                endpoints.MapDelete("/Home", async (context) =>
                {
                    await context.Response.WriteAsync("This message come from ENDPoint MapDELETE method");
                });
            });

            app.Run(async(HttpContext context) =>
            {
                await context.Response.WriteAsync("This message commin from RUN method with HTTPContext");
            });

            app.Run();
        }
    }
}