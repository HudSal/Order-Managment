using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderHeader
    {
        private OrderState _state;
        private List<OrderItem> _orderItems= new List<OrderItem>();

        public DateTime DateTime { get; set; }
        public int Id { get; set; }
        public decimal Total {
            get {
                decimal Total = 0;
                foreach (var item in _orderItems)
                {
                    Total += item.Total;
                }
                return Total;
            } 
        }
        public OrderState State { get { return _state; } }

        public List<OrderItem> OrderItems { get { return _orderItems; } }

        //Constructor
        /// <summary>
        /// Construstor for OrderHeader Clsaa 
        /// </summary>
        /// <param name="id">OrderHeader Id</param>
        /// <param name="dateTime">OrderHeader DateTime</param>
        /// <param name="stateId">OrderHeader stateId-integer</param>
        public OrderHeader(int id, DateTime dateTime, int stateId)
        {
            Id = id;
            DateTime = dateTime;
            setState(stateId);
        }
        /// <summary>
        /// OrderHeader Sate Setter 
        /// </summary>
        /// <param name="stateNum"> stateId- integer</param>
        public void setState(int stateNum)
        {
            switch (stateNum)
            {
                case 1:
                    _state = new OrderNew(this);
                    break;
                case 2:
                    _state = new OrderPending(this);
                    break;
                case 3:
                    _state = new OrderRejected(this);
                    break;
                case 4:
                    _state = new OrderComplete(this);
                    break;
                default:
                    throw new InvalidOrderStateException($"Invalid State Id: {stateNum}");
            }
        }
        /// <summary>
        /// Adding order item to the order header by creating new order item if it is not exist otherwise increment its quantity 
        /// </summary>
        /// <param name="stockItemId">stock item Id- integer</param>
        /// <param name="price">the price for the stock item- decimal</param>
        /// <param name="description">the description or the name of the stock item- string</param>
        /// <param name="quantity">the desired quantity from this stock item</param>
        /// <returns>the order item which is added to the order header</returns>
        public OrderItem AddOrderItem(int stockItemId, decimal price, string description, int quantity)
        {
            OrderItem item = null;
            //check to see if there is already an existing order item for the selected stock item
            foreach (var i in OrderItems)
            {
                if (i.StockItemId == stockItemId)
                {
                    item = i;
                }
            }
            //if there isn't create a new instance and add it to the collection of order items
            if (item == null)
            {
                item = new OrderItem(description, this, price, quantity, stockItemId);
                OrderItems.Add(item);
            }
            else
            {
                item.Quantity += quantity;
            }
            //return the order item object
            return item;
        }
        /// <summary>
        /// calling Complete method to change the state of the order header to Complete
        /// </summary>

        public void Complete()
        {
            _state.Complete();
        }
        /// <summary>
        /// calling Submit method to change the state of the order header to Pending
        /// </summary>
        public void Submit()
        {
            _state.Submit();
        }
        /// <summary>
        /// calling Reject method to change the state of the order header to Rejected
        /// </summary>
        public void Reject()
        {
            _state.Reject();
        }
    }
}
