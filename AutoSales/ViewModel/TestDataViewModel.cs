using AutoSales.Model;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace AutoSales.ViewModel
{
    public partial class TestDataViewModel
    {
        public TextBox QuerryTextBox { get; set; } = default!;

        private readonly AutoSalesDbContext context;

        public TestDataViewModel(AutoSalesDbContext salesDbContext)
        { 
            context = salesDbContext;
        }

        [RelayCommand]
        private async Task ExecuteQuerry()
        {
            try
            {
                await context.Database.ExecuteSqlAsync(FormattableStringFactory.Create(QuerryTextBox.Text));
                await context.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                Debug.WriteLine(ex);
            }
        }

    }
}