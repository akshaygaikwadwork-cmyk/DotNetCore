using AddKeysMethods;
using Microsoft.Extensions.DependencyInjection;

var collection = new ServiceCollection();

collection.AddKeyedSingleton<ITaxCalculators, MumbaiTaxCalculator>(UserLocations.Mumbai);
collection.AddKeyedSingleton<ITaxCalculators, PuneTaxCalculator>(UserLocations.Pune);

var provider = collection.BuildServiceProvider();   

ITaxCalculators taxCalculators = provider.GetKeyedService<ITaxCalculators>(UserLocations.Mumbai);

Console.Clear();
Console.WriteLine($"Your tax rate is {taxCalculators.Calculate()}");


Console.ReadKey();
