
using Application.Handlers.CommandsHandlers;
using Application.Handlers.QueriesHandlers;
using Common.Middleware;
using Core.I_Repository;
using Infrastructure.Repositories;


namespace StudentWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Register Dapper repositories
            builder.Services.AddScoped<IProductRepository>(sp => new ProductRepository(builder.Configuration.GetConnectionString("DbConnection")));

            // Register command handlers
            builder.Services.AddScoped<AddProductCommandHandler>();
            builder.Services.AddScoped<UpdateProductCommandHandler>();
            builder.Services.AddScoped<DeleteProductCommandHandler>();
            builder.Services.AddScoped<GetProductByIdQueryHandler>();
            builder.Services.AddScoped<GetAllProductsQueryHandler>();



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

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
