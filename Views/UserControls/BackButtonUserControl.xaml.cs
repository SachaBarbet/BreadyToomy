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

namespace BreadyToomy.Views.UserControls
{
    /// <summary>
    /// Logique d'interaction pour BackButtonUserControl.xaml
    /// </summary>
    public partial class BackButtonUserControl : UserControl
    {
        public BackButtonUserControl()
        {
            InitializeComponent();
        }

        private void Go_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).GoBack();
        }
    }
}
