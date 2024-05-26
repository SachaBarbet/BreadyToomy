using BreadyToomy.Views.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BreadyToomy.Views
{
    /// <summary>
    /// Logique d'interaction pour ProductView.xaml
    /// </summary>
    public partial class ProductView : Page
    {
        public ProductView()
        {
            InitializeComponent();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            Window window = new ProductWindow();
            window.Owner = Application.Current.MainWindow;

            window.ShowDialog();
        }
    }
}
