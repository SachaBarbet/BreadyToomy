using BreadyToomy.ViewModels;
using BreadyToomy.Views.Windows;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BreadyToomy.Views
{
    /// <summary>
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : Page
    {
        private ProductViewModel _viewModel;

        public ProductView()
        {
            InitializeComponent();
            _viewModel = new ProductViewModel(); 
            DataContext = _viewModel;
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            ProductWindow window = new ProductWindow(_viewModel);
            window.Owner = Application.Current.MainWindow;

            window.ShowDialog();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
