using BreadyToomy.Views.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BreadyToomy.Views
{
    /// <summary>
    /// Logique d'interaction pour Recipeview.xaml
    /// </summary>
    public partial class RecipeView : Page
    {
        public RecipeView()
        {
            InitializeComponent();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            Window window = new RecipeWindow();
            window.Owner = Application.Current.MainWindow;

            window.ShowDialog();
        }
    }
}
