namespace RoutingWithoutMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Note- Following to add our view service in our application runtime before build application
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");

            //Note- To add default Routing on Application runtime
            //app.MapDefaultControllerRoute(); //it will default call home constroller and index method
            //OR
            //Note- To add customise default Routing on Application runtime
            //app.MapControllerRoute(
            //    name:"default",
            //    pattern:"{controller=Home}/{action=Index}/{Id?}"
            //    );

            app.MapControllerRoute(
             name: "default",
             pattern: "{controller=Home}/{action=About}/{Id?}"
             );

            app.Run();
        }
    }
}