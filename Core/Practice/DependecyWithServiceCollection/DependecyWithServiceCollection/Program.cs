using DependecyWithServiceCollection.Classes;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;


var collection = new ServiceCollection();

// Register services
services.AddSingleton<ISingletonService, ClassA>();
services.AddScoped<IScopedService, ClassA>();
services.AddTransient<ITransientService, ClassA>();

var app = builder.Build();
// Creating a scope for testing dependency injection
using (var scope = app.Services.CreateScope())
{
    var provider = scope.ServiceProvider;

    Console.WriteLine("--------- Singleton Object Creation ---------");
    for (int i = 0; i < 5; i++)
    {
        var obj = provider.GetRequiredService<ISingletonService>();
        Console.WriteLine($"Singleton object {i}: {obj.Id}");
    }

    Console.WriteLine("\n--------- Scoped Object Creation (With Inner Singleton Call) ---------");
    for (int i = 0; i < 2; i++)
    {
        using (var innerScope = provider.CreateScope())  // New scope every iteration
        {
            var scopedProvider = innerScope.ServiceProvider;
            Console.WriteLine($"Scoped Scope {i} Started");

            for (int j = 0; j < 3; j++)
            {
                var scopedObj = scopedProvider.GetRequiredService<IScopedService>();
                var singletonObj = scopedProvider.GetRequiredService<ISingletonService>(); // Called inside scope

                Console.WriteLine($"Scoped object {i}.{j}: {scopedObj.Id}");  // New per scope
                Console.WriteLine($"Singleton object inside scope {i}.{j}: {singletonObj.Id}"); // Always same ID
            }

            Console.WriteLine($"Scoped Scope {i} Ended\n");
        }
    }

    Console.WriteLine("--------- Transient Object Creation ---------");
    for (int i = 0; i < 5; i++)
    {
        var obj = provider.GetRequiredService<ITransientService>();
        Console.WriteLine($"Transient object {i}: {obj.Id}");
    }
}


app.MapGet("/", () => "Hello World!");
app.Run();
