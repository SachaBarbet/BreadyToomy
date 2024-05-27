using BreadyToomy.Models;
using BreadyToomy.ViewModels;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace BreadyToomy.Views.Windows
{
    /// <summary>
    /// Logique d'interaction pour IngredientControl.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        private ProductViewModel ProductViewModel;
        public Product Product = new Product();
        public RelayCommand AddIngredientCommand;

        public ProductWindow(ProductViewModel productViewModel)
        {
            InitializeComponent();
            ProductViewModel = productViewModel;
            DataContext = ProductViewModel;
            AddIngredientCommand = new RelayCommand(execute => ProductViewModel.AddItem(item: Product), canExecute => CanAddItem());
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
            if (ProductViewModel == null)
            {
                errorString.Text = "Error";
                return false;
            }

            if (inputName.Text.Replace(" ", "") == "")
            {
                errorString.Text = "Name empty";
                return false;
            }

            errorString.Text = "Product Added";
            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!CanAddItem())
            {
                return;
            }
            Product.Name = inputName.Text;
            Product.Price = decimal.Parse(inputPrice.Text);
            Product.Description = inputDescription.Text;
            Product.Type = inputType.Text;

            Product.Archived = false;
            ProductViewModel.AddItem(item: Product);
        }
    }
}
