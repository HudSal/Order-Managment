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
    /// Interaction logic for AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Page
    {
        private OrdersController _ordersCont=new OrdersController();
        public AddOrder( OrderHeader order=null)
        {
            InitializeComponent();
            if (order==null)
            {
                DataContext = _ordersCont.CreateNewOrderHeader();
            }
            else
            {
                DataContext = order;
            }
        }

        /// <summary>
        ///  Button_Click method- the action when the "Delete" Button in AddOrder view is clicked to delete the orderItem
        /// </summary>
        /// <param name="sender">The object which creates the event</param>
        /// <param name="e">The event data</param>
        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderItem orderItem = (OrderItem)((Button)e.Source).DataContext;
                DataContext = _ordersCont.DeleteOrderItem(((OrderHeader)DataContext).Id, orderItem.StockItemId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        ///  Button_Click method- the action when either "Add Order Item" Button or "Submit" Button or "Cancel" in AddOrder view is clicked
        /// </summary>
        /// <param name="sender">The object which creates the event</param>
        /// <param name="e">The event data</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string action = (sender as Button).Content.ToString();
            if (action == "Add Order Item")
            {
                try
                {
                    NavigationService.Navigate(new AddOrderLineItem((OrderHeader)DataContext));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (action == "Submit")
            {
                try
                {
                    _ordersCont.SubmitOrder(((OrderHeader)DataContext).Id);
                    NavigationService.Navigate(new Order());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (action == "Cancel")
            {
                _ordersCont.DeleteOrderHeaderAndOrderItems((DataContext as OrderHeader).Id);
                NavigationService.Navigate(new Order());
            }
        }
    }
}
