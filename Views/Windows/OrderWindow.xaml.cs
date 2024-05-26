using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace BreadyToomy.Views.Windows
{
    /// <summary>
    /// Logique d'interaction pour IngredientControl.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public OrderWindow()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Add ingredient to bdd
            this.Close();
        }
    }
}
