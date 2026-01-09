var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IMethod1, Method1>();
builder.Services.AddSingleton<Method1>();

var app = builder.Build();

var serviceProviderIsService = app.Services.GetService<IServiceProviderIsService>();

var isInterfaceRegistered = serviceProviderIsService != null && serviceProviderIsService.IsService(typeof(IMethod1));
var isClassRegistered = serviceProviderIsService != null && serviceProviderIsService.IsService(typeof(Method1));

app.MapGet(pattern: "/", handler: () => $"Interface Registered: {isInterfaceRegistered}, Class Registered: {isClassRegistered}");
app.Run();


public class Method1 : IMethod1
{
    public string Hello() => "Hello I am a service";
}