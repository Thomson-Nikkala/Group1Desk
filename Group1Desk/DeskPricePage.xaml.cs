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

            BasePrice.Content = "Base Desk Price: " + Order.BasePrice;
            getDrawersPrice.Content = order.yourDesk.drawers + " Added Drawers : " + order.getDrawersPrice();

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
       //     string[] lines = {
        //                "{",
        //                string.Format("\"deskWidth\":{0},",yourOrder.yourDesk.width),
        //                string.Format("\"deskLength\":{0},",yourDesk.length),
        //                string.Format("\"numDrawers\":{0},",yourDesk.drawers),
        //                string.Format("\"surfaceMaterial\":\"{0}\",",surfaceMaterial),
          //              string.Format("\"shippingSpeed\":\"{0}\",",shippingSpeed),
       //                 string.Format("\"BaseDeskPrice\":200,"),
       //                 string.Format("\"priceFromSurfaceArea\":{0},",priceFromSurfaceArea),
        //                string.Format("\"priceFromDrawers\":{0},",priceFromDrawers),
         //               string.Format("\"surfaceMaterialFee\":{0},",surfaceMaterialFee),
         //               string.Format("\"deliveryFee\":{0},",deliveryFee),
         //               string.Format("\"deskPrice\":{0},",deskPrice),"}"
         //           };
         
            //write string to file
          //  System.IO.File.WriteAllLines(@outputFileName, lines);
        
            Environment.Exit(0);   // end program
        }
    }
}
