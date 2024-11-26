using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Navigation;
using System.Windows.Controls;
using AutoSales.View;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using AutoSales.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModernWpf;

namespace AutoSales.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private readonly IServiceProvider serviceProvider;

        public NavigationService NavigationService { get; set; } = null!;

        public MainViewModel(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;

            NavigateToSalesOverviewCommand = new RelayCommand(NavigateToPage<SalesOverveiw>);
            NavigateToTestDataCommand = new RelayCommand(NavigateToPage<TestData>);
        }

        public ICommand NavigateToSalesOverviewCommand { get; }
        public ICommand NavigateToTestDataCommand { get; }

        private void NavigateToPage<T>() where T : Page
        {
            T page = serviceProvider.GetRequiredService<T>();

            // This is just for my sanaty. Dark theme doesnt work properly
            // nor can I set it for MainWindow bc doing so causes NullReferenceException
            ThemeManager.SetRequestedTheme(page, ElementTheme.Light); 

            // We rely on IServiceProvider singleton to cache and lazy load pages
            NavigationService.Navigate(page);
        }

        public Task MigrateDb()
        {
            AutoSalesDbContext dbContext = serviceProvider.GetRequiredService<AutoSalesDbContext>();
            
            return dbContext.Database.MigrateAsync();
        }
    }
}