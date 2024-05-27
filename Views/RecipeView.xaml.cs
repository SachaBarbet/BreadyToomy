using BreadyToomy.ViewModels;
using BreadyToomy.Views.Windows;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BreadyToomy.Views
{
    /// <summary>
    /// Interaction logic for RecipeView.xaml
    /// </summary>
    public partial class RecipeView : Page
    {

        private RecipeViewModel _viewModel;
        public RecipeView()
        {
            InitializeComponent();
            _viewModel = new RecipeViewModel();
            DataContext = _viewModel;
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            RecipeWindow window = new RecipeWindow();
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
