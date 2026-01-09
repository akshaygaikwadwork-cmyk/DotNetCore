using DependencyExecerise1.Classes;
using DependencyExecerise1.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDataAccess, DataAccess>();
builder.Services.AddScoped<IAccount, Account>();
builder.Services.AddScoped<IUser, Account>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
