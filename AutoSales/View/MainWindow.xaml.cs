using AutoSales.ViewModel;
using System.Windows;

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