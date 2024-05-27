using BreadyToomy.Models;
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
        public Ingredient Ingredient = new Ingredient();
        public RelayCommand AddIngredientCommand;

        public IngredientWindow(IngredientViewModel ingredientViewModel)
        {
            InitializeComponent();
            IngredientViewModel = ingredientViewModel;
            DataContext = IngredientViewModel;
            AddIngredientCommand = new RelayCommand(execute => IngredientViewModel.AddItem(item: Ingredient), canExecute => CanAddItem());
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

            if (e.Handled)
            {
                errorString.Text = "Only numbers allowed";
            }
            else
            {
                errorString.Text = "";
            }
        }

        private bool CanAddItem()
        {
            if (IngredientViewModel == null) {
                errorString.Text = "Error";
                return false;
            }

            if (inputName.Text.Replace(" ", "") == "")
            {
                errorString.Text = "Name empty";
                return false;
            }

            errorString.Text = "Ingredient Added";
            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!CanAddItem())
            {
                return;
            }
            Ingredient.Name = inputName.Text;
            Ingredient.Quantity = int.Parse(inputQuantity.Text);
            Ingredient.Archived = false;
            IngredientViewModel.AddItem(item: Ingredient);
        }
    }
}
