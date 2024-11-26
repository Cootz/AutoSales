using AutoSales.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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