using Controllers;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace UI.Views
{
    /// <summary>
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Order : Page
    {
        public OrdersController ordersCont = new OrdersController();
        public Order()
        {
            InitializeComponent();
            try
            {
                dgOrder.ItemsSource = ordersCont.GetOrderHeaders();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Button_Click method- the action when either "Details" Button or "Add Order" Button in Order view is clicked
        /// </summary>
        /// <param name="sender">The object which creates the event</param>
        /// <param name="e">The event data</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // details or Add order
            string action = (sender as Button).Content.ToString();
            if (action == "Details")
            {
                var button = (Button)e.Source;
                var order = (OrderHeader)button.DataContext;
                NavigationService.Navigate(new OrderDetails(order));
            }
            else if (action == "Add Order")
            {
                NavigationService.Navigate(new AddOrder());
            }
        }
    }
}