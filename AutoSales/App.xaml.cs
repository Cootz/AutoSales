using AutoSales.Model;
using AutoSales.View;
using AutoSales.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModernWpf;
using System.Configuration;
using System.Data;
using System.Windows;

namespace AutoSales
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        { 
            ServiceCollection services = new ();

            services.AddDbContext<AutoSalesDbContext>();

            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainViewModel>();

            services.AddSingleton<SalesOverveiw>();
            services.AddSingleton<SalesViewModel>();

            services.AddSingleton<TestData>();
            services.AddSingleton<TestDataViewModel>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            MainWindow mainWindow = serviceProvider.GetRequiredService<MainWindow>();

            mainWindow.Show();
        }
    }
}