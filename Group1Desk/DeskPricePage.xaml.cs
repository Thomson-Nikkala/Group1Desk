using System;
using System.Collections.Generic;
using System.IO;
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
    /// 

    public partial class DeskPricePage : Page
    {
        public DeskPricePage()
        {
            InitializeComponent();
        }

        public DeskPricePage(Desk desk)
        {
            InitializeComponent();
            this.desk = desk;
        }
        public DeskPricePage(Order order)
        {
            InitializeComponent();
            this.order = order;
            this.DataContext = this;

            BasePrice.Content = Order.BasePrice;
            getDrawersPrice.Content = order.getDrawersPrice();
            getSurfaceAreaPrice.Content =  order.getSurfaceAreaPrice();
            getSurfaceTypePrice.Content =  order.getSurfaceTypePrice();
            getSpeedPrice.Content = order.getSpeedPrice();
            getTotalPrice.Content = order.getTotalPrice();
        }

        private Desk desk;
        private Order order;
        public Order orderProperty
        {
            get
            {
                return order;
            }
        }
        public int deskLength
        {
            get { return desk.length; }
            set { desk.length = value; }
        }
        public int deskWidth
        {
            get { return desk.width; }
            set { desk.width = value; }
        }
        public int numDrawers
        {
            get { return desk.drawers; }
            set { desk.drawers = value; }

        }
        public string deskMaterial
        {
            get { return order.yourDesk.surfaceType.ToString(); }
            set { order.yourDesk.surfaceType = (SurfaceMaterial)Enum.Parse(typeof(SurfaceMaterial), value); }
        }
        public int shippingDays
        {
            get { return (int)order.speed; }
            set { order.speed = (OrderSpeed)value; }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // save desk and order to file here
            string[] lines = {
                   "{",
                        string.Format("\"width\":{0},", order.yourDesk.width),
                        string.Format("\"length\":{0},", order.yourDesk.length),
                        string.Format("\"drawers\":{0},", order.yourDesk.drawers),
                        string.Format("\"surfaceType\":\"{0}\",", order.yourDesk.surfaceType),
                        string.Format("\"speed\":\"{0}\",", order.speed),
                        string.Format("\"BasePrice\":200,"),
                        string.Format("\"surfaceAreaPrice\":{0},",order.getSurfaceAreaPrice()),
                        string.Format("\"drawersPrice\":{0},", order.getDrawersPrice()),
                        string.Format("\"surfaceTypePrice\":{0},", order.getSurfaceTypePrice()),
                        string.Format("\"speedPrice\":{0},", order.getSpeedPrice()),
                       string.Format("\"totalPrice\":{0},",order.getTotalPrice()),"}"
            };
         
            //write string to file
            System.IO.File.WriteAllLines("output.json", lines);
        
            Environment.Exit(0);   // end program
        }
    }
}
