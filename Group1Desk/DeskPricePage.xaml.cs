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

namespace Group1Desk
{
    /// <summary>
    /// Interaction logic for DeskPricePage.xaml
    /// </summary>
    public partial class DeskPricePage : Page
    {
        public DeskPricePage()
        {
            InitializeComponent();
        }

        // Custom constructor to pass order data
        public DeskPricePage(object yourOrder):this()
        {
            // Bind to order data
            this.DataContext = yourOrder;
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // save desk and order to file here
            Environment.Exit(0);   // end program
        }
    }
}
