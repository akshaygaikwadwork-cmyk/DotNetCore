using CRUD_WithWebAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var provider = builder.Services.BuildServiceProvider();
var config = provider.GetService<IConfiguration>();
builder.Services.AddDbContext<Asp_DOT_NetCore_DBContext>(i => i.UseSqlServer(config.GetConnectionString("dbcs")));

builder.Services.AddOpenTelemetryTracing(traceBuilder =>
{
    traceBuilder
        .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("YourServiceName"))
        .AddAspNetCoreInstrumentation()
        .AddJaegerExporter(options =>
        {
            options.AgentUri = new Uri("http://localhost:14250"); // Adjust to your Jaeger endpoint
        });
});

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
