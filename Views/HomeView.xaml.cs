using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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
