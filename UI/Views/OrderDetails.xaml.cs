using Controllers;
using Domain;
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

namespace UI.Views
{
    /// <summary>
    /// Interaction logic for OrderDetails.xaml
    /// </summary>
    public partial class OrderDetails : Page
    {
        private OrdersController _ordersCont = new OrdersController();
       
        public OrderDetails( OrderHeader orderHeader)
        {
            InitializeComponent();
            DataContext = orderHeader;
        }

        /// <summary>
        /// Orders_Click method- the action when "Orders" Button in OrderDetails view is clicked
        /// </summary>
        /// <param name="sender">The object which creates the event</param>
        /// <param name="e">The event data</param>
        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Order());
        }

        /// <summary>
        /// ProcessOrder_Click method- the action when "Process" Button or "Submit" Button in OrderDetails view is clicked
        /// </summary>
        /// <param name="sender">The object which creates the event</param>
        /// <param name="e">The event data</param>
        private void ProcessOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderHeader order = (OrderHeader)DataContext;
                if (order.State.State == OrderStates.Pending)
                {
                    DataContext = _ordersCont.ProcessOrder(order.Id);
                }
                else if(order.State.State == OrderStates.New)
                {
                    DataContext = _ordersCont.SubmitOrder(order.Id);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
