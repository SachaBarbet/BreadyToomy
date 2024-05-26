using BreadyToomy.Models;
using BreadyToomy.ViewModels;
using BreadyToomy.Views.Windows;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace BreadyToomy.Views
{
    /// <summary>
    /// Logique d'interaction pour IngredientView.xaml
    /// </summary>
    public partial class IngredientView : Page
    {

        private IngredientViewModel _ingredientViewModel;
        public IngredientView()
        {
            InitializeComponent();
            _ingredientViewModel = new IngredientViewModel();
            DataContext = _ingredientViewModel;
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            IngredientWindow window = new IngredientWindow(ingredientViewModel: _ingredientViewModel);
            window.Owner = Application.Current.MainWindow;
            window.Show();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
