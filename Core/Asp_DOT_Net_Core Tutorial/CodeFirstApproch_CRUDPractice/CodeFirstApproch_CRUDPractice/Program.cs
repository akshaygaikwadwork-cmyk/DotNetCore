using CodeFirstApproch_CRUDPractice.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproch_CRUDPractice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            var provider = builder.Services.BuildServiceProvider();
            var config = provider.GetRequiredService<IConfiguration>();
            builder.Services.AddDbContext<EmpDbContext>(item => item.UseSqlServer(config.GetConnectionString("dbConnection")));


            var app = builder.Build();

            app.UseStaticFiles(); //important to use because to access wwwroot files

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=index}/{id?}"
                );

            app.Run();
        }
    }
}