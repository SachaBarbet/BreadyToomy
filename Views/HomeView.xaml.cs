using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BreadyToomy.Views
{
    /// <summary>
    /// Logique d'interaction pour HomePage.xaml
    /// </summary>
    public partial class HomeView : Page
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void Navigate_To_Order(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderView());
        }

        private void Navigate_To_Recipe(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RecipeView());
        }

        private void Navigate_To_Product(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductView());
        }

        private void Navigate_To_Ingredient(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new IngredientView());
        }

    }
}
