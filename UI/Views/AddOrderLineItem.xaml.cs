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
    /// Interaction logic for AddOrderLineItem.xaml
    /// </summary>
    public partial class AddOrderLineItem : Page
    {
        private OrdersController _ordersCont= new OrdersController();
        private OrderHeader _orderHeader;
        private StockItemsController stockItemsCont = new StockItemsController();
        public int Quantity { get; set; } = 1;
        public IEnumerable<StockItem> StockItems { get; private set; }
        public AddOrderLineItem( OrderHeader orderHeader)
        {
            InitializeComponent();
            try
            {
                _orderHeader = orderHeader;
                StockItems = stockItemsCont.GetStockItems();
                DataContext = this;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Button_Click method- the action when "Add Order" Button in AddOrderLineItem view is clicked
        /// </summary>
        /// <param name="sender">The object which creates the event</param>
        /// <param name="e">The event data</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StockItem stockItem = (StockItem)dgStockItem.SelectedItem;
            if (stockItem == null)
            {
                MessageBox.Show("Please select a stock item", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (Quantity > stockItem.InStock)
            {
                MessageBox.Show($"There is currently not enough items in stock. Requested: {Quantity} In stock: {stockItem.InStock}\nThis order might be rejected if there is not enough stock when the order is being processed ", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            try
            {
                _orderHeader = _ordersCont.UpsertOrderItem(_orderHeader.Id, stockItem.Id, Quantity);
                NavigationService.Navigate(new AddOrder(_orderHeader));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        } 
    }
}
