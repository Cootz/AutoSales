using AutoSales.ViewModel;
using System.Windows.Controls;

namespace AutoSales.View
{
    /// <summary>
    /// Interaction logic for SalesOverveiw.xaml
    /// </summary>
    public partial class SalesOverveiw : Page
    {
        private SalesViewModel ViewModel { get; }

        public SalesOverveiw(SalesViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
            ViewModel = viewModel;

            ViewModel.DatePicker = filterDatePicker;
        }
    }
}
