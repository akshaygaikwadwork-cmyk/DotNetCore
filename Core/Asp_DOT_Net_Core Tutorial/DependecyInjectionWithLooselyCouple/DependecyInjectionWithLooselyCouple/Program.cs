using DependecyInjectionWithLooselyCouple.Model;

namespace DependecyInjectionWithLooselyCouple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add MVC services to the container.
            builder.Services.AddMvc();


            //builder.Services.AddSingleton<IStudentRepository, StudentRepository>();
            //builder.Services.AddSingleton<SomeOtherService>();

            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<SomeOtherService>();

            //builder.Services.AddTransient<IStudentRepository, StudentRepository>();
            //builder.Services.AddTransient<SomeOtherService>();

            //Application Service
            //builder.Services.AddSingleton<IStudentRepository, StudentRepository>();
            //builder.Services.AddSingleton(typeof(IStudentRepository), typeof(StudentRepository));
            //builder.Services.AddTransient<IStudentRepository, StudentRepository>();
            //builder.Services.AddTransient(typeof(IStudentRepository), typeof(StudentRepository));
            //builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            //builder.Services.AddScoped(typeof(IStudentRepository), typeof(StudentRepository));
            //Add Application Service to the Container.
            //builder.Services.Add(new ServiceDescriptor(typeof(IStudentRepository),
            //    new StudentRepository())); // by default singleton
            //builder.Services.Add(new ServiceDescriptor(typeof(IStudentRepository),
            //    typeof(StudentRepository), ServiceLifetime.Singleton)); // singleton
            //builder.Services.Add(new ServiceDescriptor(typeof(IStudentRepository),
            //    typeof(StudentRepository), ServiceLifetime.Transient)); // Transient
            //builder.Services.Add(new ServiceDescriptor(typeof(IStudentRepository),
            //    typeof(StudentRepository), ServiceLifetime.Scoped));    // Scoped



            var app = builder.Build();

            app.UseRouting();

            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}
