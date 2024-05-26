using BreadyToomy.ViewModels;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace BreadyToomy.Views.Windows
{
    /// <summary>
    /// Logique d'interaction pour IngredientControl.xaml
    /// </summary>
    public partial class IngredientWindow : Window
    {
        private IngredientViewModel IngredientViewModel;
      

        public IngredientWindow(IngredientViewModel ingredientViewModel)
        {
            InitializeComponent();
            IngredientViewModel = ingredientViewModel;
            DataContext = IngredientViewModel;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
