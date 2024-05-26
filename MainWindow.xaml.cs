using BreadyToomys.Services;
using System.Windows;

namespace BreadyToomy
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new Views.HomeView());
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            Database database = Database.GetInstance();
            database.close();
        }
    }
}
