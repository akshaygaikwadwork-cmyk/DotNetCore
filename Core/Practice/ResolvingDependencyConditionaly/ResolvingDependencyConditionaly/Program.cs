using Microsoft.Extensions.DependencyInjection;
using ResolvingDependencyConditionaly;

var collection = new ServiceCollection();
collection.AddScoped<MumbaiTaxCalculator>();
collection.AddScoped<PuneTaxCalculator>();

collection.AddScoped<Func<UserLocations, ITaxCalculator>>(
        ServiceProvider => key =>
        {
            switch (key)
            {
                case UserLocations.Mumbai: return ServiceProvider.GetService<MumbaiTaxCalculator>();
                case UserLocations.Pune: return ServiceProvider.GetService<PuneTaxCalculator>();
                default: return null;
            }
        }
    );

collection.AddSingleton<Purchase>();
var provider = collection.BuildServiceProvider();
var purchase = provider.GetService<Purchase>();
var totalcharge = purchase.CheckOut(UserLocations.Pune);
Console.WriteLine(totalcharge);

var totalcharge1 = purchase.CheckOut(UserLocations.Banglore);
Console.WriteLine(totalcharge1);

Console.WriteLine("Press a key");
Console.ReadKey();