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
        string[] materials = new string[3] { "oak", "laminate", "pine" };
        int[] materialCosts = new int[3] { 200, 100, 50 };

        //Get Length of Desk
        private void comboBox_Length(object sender, RoutedEventArgs e)
        {
            // Drop down List.
            List<int> length = new List<int>();
            length.Add(24);
            length.Add(28);
            length.Add(32);
            length.Add(36);
            length.Add(40);
            length.Add(44);
            length.Add(48);
            length.Add(52);
            length.Add(56);
            length.Add(60);
            length.Add(64);
            length.Add(68);
            length.Add(72);

            // Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // Assign the ItemsSource to the List.
            comboBox.ItemsSource = length;

            // Makes the first item selected.
            comboBox.SelectedIndex = 0;
        }
        private void ComboBox_LengthChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get the ComboBox.
            var comboBox = sender as ComboBox;

            // ... Set SelectedItem as Window Title.
            string value = comboBox.SelectedItem as string;
            this.Title = "Selected: " + value;
        }
        //Get Width of Desk
        private void comboBox_Width(object sender, RoutedEventArgs e)
        {
            // Drop down List.
            List<int> width = new List<int>();
            width.Add(24);
            width.Add(28);
            width.Add(32);
            width.Add(36);
            width.Add(40);
            width.Add(44);
            width.Add(48);

            // Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // Assign the ItemsSource to the List.
            comboBox.ItemsSource = width;

            // Makes the first item selected.
            comboBox.SelectedIndex = 0;
        }
        private void ComboBox_WidthChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get the ComboBox.
            var comboBox = sender as ComboBox;

            // ... Set SelectedItem as Window Title.
            string value = comboBox.SelectedItem as string;
            this.Title = "Selected: " + value;
        }
        //Get Material of Desk
        private void comboBox_Material(object sender, RoutedEventArgs e)
        {
            // Drop down List.
            List<string> material = new List<string>();
            material.Add("oak");
            material.Add("laminate");
            material.Add("pine");

            // Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // Assign the ItemsSource to the List.
            comboBox.ItemsSource = material;

            // Makes the first item selected.
            comboBox.SelectedIndex = 0;
        }
        private void ComboBox_MaterialChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get the ComboBox.
            var comboBox = sender as ComboBox;

            // ... Set SelectedItem as Window Title.
            string value = comboBox.SelectedItem as string;
            this.Title = "Selected: " + value;
        }
        //Get Shipping Length
        private void comboBox_Shipping(object sender, RoutedEventArgs e)
        {
            // Drop down List.
            List<int> shipping = new List<int>();
            shipping.Add(3);
            shipping.Add(5);
            shipping.Add(7);
            shipping.Add(14);

            // Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // Assign the ItemsSource to the List.
            comboBox.ItemsSource = shipping;

            // Makes the first item selected.
            comboBox.SelectedIndex = 0;
        }
        private void ComboBox_ShippingChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get the ComboBox.
            var comboBox = sender as ComboBox;

            // ... Set SelectedItem as Window Title.
            string value = comboBox.SelectedItem as string;
            this.Title = "Selected: " + value;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            DeskPricePage deskPricePage = new DeskPricePage();
            NavigationService.Navigate(deskPricePage);
        }
    }
}
