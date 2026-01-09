namespace DependencyInjectionPractice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add MVC services to the container.
            builder.Services.AddMvc();

            var app = builder.Build();

            app.UseRouting();
            
            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}
