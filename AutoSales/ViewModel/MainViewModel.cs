using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Navigation;
using System.Windows.Controls;
using AutoSales.View;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace AutoSales.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private readonly Dictionary<string, Page> loadedPages = [];

        public NavigationService NavigationService { get; set; } = null!;

        public MainViewModel()
        {
            NavigateToSalesOverviewCommand = new RelayCommand(NavigateToPage<SalesOverveiw>);
            NavigateToTestDataCommand = new RelayCommand(NavigateToPage<TestData>);
        }

        public ICommand NavigateToSalesOverviewCommand { get; }
        public ICommand NavigateToTestDataCommand { get; }

        private void NavigateToPage<T>() where T : Page, new()
        {
            string typeName = typeof(T).Name;

            if (loadedPages.TryGetValue(typeName, out Page? page))
            {
                NavigationService.Navigate(page);
            }
            else
            {
                page = new T();

                loadedPages.Add(typeName, page);
            }
        }
    }
}