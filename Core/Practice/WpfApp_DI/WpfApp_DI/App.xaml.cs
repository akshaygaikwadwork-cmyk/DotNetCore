using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace WpfApp_DI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var collection = new ServiceCollection();

            collection.AddScoped<TestClass>();
            collection.AddTransient<MainWindow>();

            var provider = collection.BuildServiceProvider();
            var mainWindow = provider.GetService<MainWindow>();
            MainWindow.Show();
        }
    }

}
