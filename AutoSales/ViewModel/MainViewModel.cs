using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Navigation;
using System.Windows.Controls;
using AutoSales.View;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using AutoSales.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
            NavigationService.Navigate(serviceProvider.GetRequiredService<T>());
        }

        public Task MigrateDb()
        {
            AutoSalesDbContext dbContext = serviceProvider.GetRequiredService<AutoSalesDbContext>();
            
            return dbContext.Database.MigrateAsync();
        }
    }
}