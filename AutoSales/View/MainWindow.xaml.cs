using AutoSales.Model;
using AutoSales.View;
using AutoSales.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoSales
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel ViewModel { get; }

        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;

            ViewModel = viewModel;
            ViewModel.NavigationService = mainFrame.NavigationService;
        }

        /// <summary>
        ///  Ensures db created/migration completed after main page is loaded
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e) => ViewModel.MigrateDb();
    }
}