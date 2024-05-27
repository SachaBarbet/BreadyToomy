using BreadyToomy.ViewModels;
using BreadyToomy.Views.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BreadyToomy.Views
{
    /// <summary>
    /// Logique d'interaction pour OrderView.xaml
    /// </summary>
    public partial class OrderView : Page
    {
        private OrderViewModel _orderViewModel;

        public OrderView()
        {
            InitializeComponent();
            _orderViewModel = new OrderViewModel();
            DataContext = _orderViewModel;
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            Window window = new OrderWindow(_orderViewModel);
            window.Owner = Application.Current.MainWindow;

            window.ShowDialog();
        }
    }
}
