
using CQRS_DesignPrin_WebAPI.Data;
using CQRS_DesignPrin_WebAPI.Repositorys;
using CQRS_DesignPrin_WebAPI.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CQRS_DesignPrin_WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Added service for GetDBConnectionString
            builder.Services.AddDbContext<ApplicationDbContext>(o
                => o.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"))
                );

            //Added service for Dependency of Services
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            //Added Mediator service
            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
