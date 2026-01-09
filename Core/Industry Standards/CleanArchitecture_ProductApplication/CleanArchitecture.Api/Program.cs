
using CleanArchitecture.Api.Middleware;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Repositorys;
using CleanArchitecture.Infrastructure.Repositorys;
using CleanArchitecture.Application.AutoMapper;

namespace CleanArchitecture.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

            // Configure Dapper and Dependency Injection
            builder.Services.AddScoped<IProductRepository>(provider =>
                new ProductRepository(builder.Configuration.GetConnectionString("DbConnection")));
            builder.Services.AddScoped<ProductService>();

            var app = builder.Build();

            // Use custom middleware
            app.UseMiddleware<GlobalExceptionMiddleware>();

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
