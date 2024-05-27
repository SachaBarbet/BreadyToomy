using BreadyToomy.ViewModels;
using System;
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
        public string ErrorString = "";

        public RelayCommand AddCommand => new RelayCommand(execute => IngredientViewModel.AddItem(), canExecute => CanAddItem());

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

        private bool CanAddItem()
        {
            if (IngredientViewModel == null) {
                return false;
            }

            if (inputName.Text.Replace(" ", "") == "")
            {
                ErrorString = "Name empty";
                return false;
            }
            return true;
        }
    }
}
