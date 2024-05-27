using BreadyToomy.Models;
using BreadyToomy.ViewModels;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace BreadyToomy.Views.Windows
{    
    public partial class OrderWindow : Window
    {
        private OrderViewModel OrderViewModel;
        public Order Order = new Order();
        public RelayCommand AddOrderCommand;

        public OrderWindow(OrderViewModel orderViewModel)
        {
            InitializeComponent();
            OrderViewModel = orderViewModel;
            DataContext = OrderViewModel;
            AddOrderCommand = new RelayCommand(execute => OrderViewModel.AddItem(item: Order), canExecute => CanAddItem());
        }

        private bool CanAddItem()
        {
            if (OrderViewModel == null)
            {
                errorString.Text = "Error";
                return false;
            }

            if (string.IsNullOrWhiteSpace(inputNumber.Text) || !Regex.IsMatch(inputNumber.Text, "^[0-9]+$"))
            {
                errorString.Text = "Invalid Order Number";
                return false;
            }

            if (string.IsNullOrWhiteSpace(inputType.Text))
            {
                errorString.Text = "Type empty";
                return false;
            }

            if (string.IsNullOrWhiteSpace(inputState.Text))
            {
                errorString.Text = "State empty";
                return false;
            }

            errorString.Text = "Order Added";
            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!CanAddItem())
            {
                return;
            }
            Order.Number = int.Parse(inputNumber.Text);
            Order.Type = inputType.Text;
            Order.State = inputState.Text;
            OrderViewModel.AddItem(item: Order);
        }
    }
}
