using BreadyToomy.Models;
using BreadyToomy.Views.Windows;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BreadyToomy.Views
{
    /// <summary>
    /// Logique d'interaction pour IngredientView.xaml
    /// </summary>
    public partial class IngredientView : Page
    {
        private List<Ingredient> ingredients;
        public IngredientView()
        {
            InitializeComponent();
            ingredientsEntries.Items.Add(new Ingredient { Name = "Farine", Quantity = 500 });

        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            Window window = new IngredientWindow();
            window.Owner = Application.Current.MainWindow;

            window.ShowDialog();
        }
    }
}
