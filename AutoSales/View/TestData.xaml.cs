using AutoSales.ViewModel;
using System.Windows.Controls;

namespace AutoSales.View
{
    /// <summary>
    /// Interaction logic for TestData.xaml
    /// </summary>
    public partial class TestData : Page
    {
        private TestDataViewModel ViewModel { get; }

        public TestData(TestDataViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
            ViewModel = viewModel;

            ViewModel.QuerryTextBox = sqlQuerryTextBox;
        }
    }
}