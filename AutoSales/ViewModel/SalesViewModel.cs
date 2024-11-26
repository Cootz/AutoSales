using AutoSales.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace AutoSales.ViewModel
{
    public partial class SalesViewModel : ObservableObject
    {
        private readonly AutoSalesDbContext context;
        
        public SalesViewModel(AutoSalesDbContext autoSalesDbContext) 
        { 
            context = autoSalesDbContext;

            salesInfo = context.Sales.Local.ToObservableCollection();
        }

        [ObservableProperty]
        private ObservableCollection<Sale>? salesInfo;
        
    }
}