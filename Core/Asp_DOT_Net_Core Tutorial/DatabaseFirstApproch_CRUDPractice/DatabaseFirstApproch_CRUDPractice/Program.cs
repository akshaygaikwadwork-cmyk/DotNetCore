using DatabaseFirstApproch_CRUDPractice.Model;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstApproch_CRUDPractice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            var configuration = new ConfigurationBuilder()
            .SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile("appsettings.json")
            .Build();

            builder.Services.AddSingleton(configuration);
            builder.Services.AddDbContext<Asp_DOT_NetCore_DBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DBConnection")));

            //      OR

            //var provider = builder.Services.BuildServiceProvider();
            //var config = provider.GetRequiredService<IConfiguration>();
            //builder.Services.AddDbContext<Asp_DOT_NetCore_DBContext>(item => item.UseSqlServer(config.GetConnectionString("DBConnection")));

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );

            app.Run();
        }
    }
}