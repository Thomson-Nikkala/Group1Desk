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
    /// Interaction logic for Group1DeskHome.xaml
    /// </summary>
    public partial class Group1DeskHome : Page
    {
        public Group1DeskHome()
        {
            InitializeComponent();
        }

        private Desk desk;
        public Desk yourDesk
        {
            get
            {
                if (desk == null)
                {
                    desk = new Desk();
                }
                return desk;
            }
            set
            {
                desk = value;
            }
        }

        private Order order;
        public Order Ord
        {
            get

            {
                if (order == null)
                {
                    order = new Order();
                    order.yourDesk = yourDesk;

                }

                return order;
            }
            set
            {
                order = value;
            }
        }
        public int desklength { get; set; }
        public int deskwidth { get; set; }
        public int numdrawers { get; set; }
        public string deskmaterial { get; set; }
        public int shippingdays { get; set; }


        //Get Length of Desk
        private void comboBox_Length(object sender, RoutedEventArgs e)
        {
            // Drop down List.
            List<int> data = new List<int>();
            data.Add(24);
            data.Add(28);
            data.Add(32);
            data.Add(36);
            data.Add(40);
            data.Add(44);
            data.Add(48);
            data.Add(52);
            data.Add(56);
            data.Add(60);
            data.Add(64);
            data.Add(68);
            data.Add(72);

            // Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;

            // Makes the first item selected.
            comboBox.SelectedIndex = 0;
        }
        private void ComboBox_LengthChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get the ComboBox.
            var comboBox = sender as ComboBox;

            // ... Set SelectedItem as Window Title.
            desklength = int.Parse(comboBox.SelectedItem.ToString());
            this.Title = "Selected: " + desklength;

            // DeskPricePage desk = new DeskPricePage();
            Ord.yourDesk.length = desklength;

        }
        //Get Width of Desk
        private void comboBox_Width(object sender, RoutedEventArgs e)
        {
            // Drop down List.
            List<int> data = new List<int>();
            data.Add(24);
            data.Add(28);
            data.Add(32);
            data.Add(36);
            data.Add(40);
            data.Add(44);
            data.Add(48);

            // Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;

            // Makes the first item selected.
            comboBox.SelectedIndex = 0;
        }
        private void ComboBox_WidthChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get the ComboBox.
            var comboBox = sender as ComboBox;

            // ... Set SelectedItem as Window Title.
            deskwidth = int.Parse(comboBox.SelectedItem.ToString());
            this.Title = "Selected: " + deskwidth;

            // DeskPricePage desk = new DeskPricePage();
            order.yourDesk.width = deskwidth;

        }
        //Get Drawers
        private void comboBox_Drawers(object sender, RoutedEventArgs e)
        {
            // Drop down List.
            List<int> data = new List<int>();
            data.Add(1);
            data.Add(2);
            data.Add(3);
            data.Add(4);
            data.Add(5);
            data.Add(6);
            data.Add(7);

            // Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;

            // Makes the first item selected.
            comboBox.SelectedIndex = 0;
        }
        private void ComboBox_DrawersChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get the ComboBox.
            var comboBox = sender as ComboBox;

            // ... Set SelectedItem as Window Title.
            numdrawers = int.Parse(comboBox.SelectedItem.ToString());
            this.Title = "Selected: " + numdrawers;

            //DeskPricePage desk = new DeskPricePage();
            order.yourDesk.drawers = numdrawers;
        }
        //Get Material of Desk
        private void comboBox_Material(object sender, RoutedEventArgs e)
        {
            // Drop down List.
            List<string> data = new List<string>();
            data.Add(SurfaceMaterial.oak.ToString());
            data.Add(SurfaceMaterial.pine.ToString());
            data.Add(SurfaceMaterial.laminate.ToString());
            data.Add(SurfaceMaterial.poplar.ToString());
            data.Add(SurfaceMaterial.alder.ToString());

            // Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;

            // Makes the first item selected.
            comboBox.SelectedIndex = 0;
        }
        private void ComboBox_MaterialChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get the ComboBox.
            var comboBox = sender as ComboBox;

            // ... Set SelectedItem as Window Title.
            deskmaterial = comboBox.SelectedItem as string;
            this.Title = "Selected: " + deskmaterial;


            //DeskPricePage desk = new DeskPricePage();
            order.yourDesk.surfaceType = (SurfaceMaterial)Enum.Parse(typeof(SurfaceMaterial), deskmaterial);
        }
        //Get Shipping Length
        private void comboBox_Shipping(object sender, RoutedEventArgs e)
        {
            // Drop down List.
            List<int> data = new List<int>();
            data.Add(3);
            data.Add(5);
            data.Add(7);
            data.Add(14);

            // Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;

            // Makes the first item selected.
            comboBox.SelectedIndex = 0;
        }
        private void ComboBox_ShippingChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get the ComboBox.
            var comboBox = sender as ComboBox;

            // ... Set SelectedItem as Window Title.
            shippingdays = int.Parse(comboBox.SelectedItem.ToString());
            this.Title = "Selected: " + shippingdays;



            //DeskPricePage desk = new DeskPricePage();
            order.speed = (OrderSpeed)shippingdays;

        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            DeskPricePage DeskPricePage = new DeskPricePage(order);
            this.NavigationService.Navigate(DeskPricePage);
            //}
        }
    }
}
