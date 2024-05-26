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
        public OrderView()
        {
            InitializeComponent();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            Window window = new OrderWindow();
            window.Owner = Application.Current.MainWindow;

            window.ShowDialog();
        }
    }
}
