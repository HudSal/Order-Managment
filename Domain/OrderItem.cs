using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderItem
    {
        public string Description { get; set; }
        public OrderHeader OrderHeader { get; set; }
        public int OrderHeaderId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int StockItemId { get; set; }
        public decimal Total { 
            get {
                return Price * Quantity ; 
            } 
        }
        public OrderItem(string desc, OrderHeader order,decimal price, int quantity, int stockItemId)
        {
            Description = desc;
            OrderHeader = order;
            OrderHeaderId = order.Id;
            Price = price;
            Quantity = quantity;
            StockItemId = stockItemId;
        }

    }
}
