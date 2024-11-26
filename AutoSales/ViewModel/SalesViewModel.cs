using AutoSales.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;

namespace AutoSales.ViewModel
{
    public partial class SalesViewModel : ObservableObject
    {
        private readonly AutoSalesDbContext context;
        
        public SalesViewModel(AutoSalesDbContext autoSalesDbContext) 
        { 
            context = autoSalesDbContext;

            var salesQuerry = context.Sales
                .Where(x => x.Date.Year == 2021)
                .GroupBy(x => x.Car.Id)
                .Select(x => new SalesOverviewRow
                { 
                    Model = x.First().Car.Model,
                    January = x.Where(sale => sale.Date.Month == 1).Sum(sale => sale.Price),
                    February = x.Where(sale => sale.Date.Month == 2).Sum(sale => sale.Price),
                    March = x.Where(sale => sale.Date.Month == 3).Sum(sale => sale.Price),
                    April = x.Where(sale => sale.Date.Month == 4).Sum(sale => sale.Price),
                    May = x.Where(sale => sale.Date.Month == 5).Sum(sale => sale.Price),
                    June = x.Where(sale => sale.Date.Month == 6).Sum(sale => sale.Price),
                    July = x.Where(sale => sale.Date.Month == 7).Sum(sale => sale.Price),
                    August = x.Where(sale => sale.Date.Month == 8).Sum(sale => sale.Price),
                    September = x.Where(sale => sale.Date.Month == 9).Sum(sale => sale.Price),
                    October = x.Where(sale => sale.Date.Month == 10).Sum(sale => sale.Price),
                    November = x.Where(sale => sale.Date.Month == 11).Sum(sale => sale.Price),
                    December = x.Where(sale => sale.Date.Month == 12).Sum(sale => sale.Price),
                });

            List<Sale> list = context.Sales.ToList();

            salesInfo = new (salesQuerry);
        }

        [ObservableProperty]
        private ObservableCollection<SalesOverviewRow>? salesInfo;
        
    }
}