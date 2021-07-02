using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.SqlClient;

namespace Controllers
{
    public class OrdersController
    {
        /// <summary>
        /// Get all OrderHeader objects
        /// </summary>
        /// <returns>return list of all OrderHeader objects</returns>
        public IEnumerable<OrderHeader> GetOrderHeaders()
        {
            OrdersRepo repo = new OrdersRepo();
            IEnumerable<OrderHeader> orderHeaders = repo.GetOrderHeaders();
            return orderHeaders;
        }

        /// <summary>
        /// Create and Insert in the database new OrderHeader object 
        /// </summary>
        /// <returns>return the new OrderHeader object </returns>
        public OrderHeader CreateNewOrderHeader()
        {
            OrdersRepo repo = new OrdersRepo();
            OrderHeader orderHeader = repo.InsertOrderHeader();
            return orderHeader;
        }

        /// <summary>
        ///  Update the quantity of the stock item in the orderitem or insert new Order Item in Order Header
        /// </summary>
        /// <param name="orderHeaderId">OrderHeader Id- integer </param>
        /// <param name="stockItemId">StockItem Id- integer</param>
        /// <param name="quantity">the wanted quantity from the stock item- integer</param>
        /// <returns>return the OrderHeader object</returns>
        public OrderHeader UpsertOrderItem(int orderHeaderId, int stockItemId, int quantity)
        {
            //call StockItemRepo method - GetStockItem to get StockItem object
            StockItemsRepo stockRepo = new StockItemsRepo();
            StockItem stockItem = stockRepo.GetStockItem(stockItemId);
            //call OrderRepo method - GetOrderHeader to get OrderHeader object
            OrdersRepo ordersRepo = new OrdersRepo();
            OrderHeader orderHeader = ordersRepo.GetOrderHeader(orderHeaderId);
            //call OrderHeader method - AddOrderItem to get OrderItem object
            OrderItem orderItem = orderHeader.AddOrderItem(stockItemId, stockItem.Price, stockItem.Name, quantity);
            //call OrderRepo method - UpsertOrderItem to update stock level in database
            ordersRepo.UpsertOrderItem(orderItem);
            //return OrderHeader object
            return orderHeader;
        }

        /// <summary>
        /// Sbmit the OrderHeader -> Change the OrderHeader state from New to Pending
        /// </summary>
        /// <param name="orderHeaderId">OrderHeader Id- integer</param>
        /// <returns>return the OrderHeader object with the new state</returns>
        public OrderHeader SubmitOrder(int orderHeaderId)
        {
            //call OrderRepo method - GetOrderHeader to get OrderHeader object
            OrdersRepo ordersRepo = new OrdersRepo();
            OrderHeader orderHeader = ordersRepo.GetOrderHeader(orderHeaderId);
            //call OrderHeader method - submit
            orderHeader.Submit();
            //call OrderRep method - UpdateOrderState
            ordersRepo.UpdateOrderState(orderHeader);
            //return OrderHeader object
            return orderHeader;           
        }

        /// <summary>
        /// Process the OrderHeader -> Change the OrderHeader state from Pending to Complete or Rejected
        /// </summary>
        /// <param name="orderHeaderId">OrderHeader Id- integer</param>
        /// <returns>return the OrderHeader object with the new state</returns>
        public OrderHeader ProcessOrder(int orderHeaderId)
        {
            OrdersRepo ordersRepo = new OrdersRepo();
            OrderHeader orderHeader = ordersRepo.GetOrderHeader(orderHeaderId);
            //call StockItemRepo method - UpdateStockItemAmount. If no exception thrown, call OrderHeader method - Complete. If exception thrown, call OrderHeader method - Reject.
            StockItemsRepo stockRepo = new StockItemsRepo();
            try
            {
                stockRepo.UpdateStockItemAmount(orderHeader);
                orderHeader.Complete();
            }
            catch
            {
                orderHeader.Reject();
            }
            ordersRepo.UpdateOrderState(orderHeader);
            return orderHeader;
        }

        /// <summary>
        /// Delete OrderHeader and all the OrderItems which is included under the OrderHeader 
        /// </summary>
        /// <param name="orderHeaderId">OrderHeader Id - integer</param>
        public void DeleteOrderHeaderAndOrderItems(int orderHeaderId)
        {
            OrdersRepo ordersRepo = new OrdersRepo();
            ordersRepo.DeleteOrderHeaderAndOrderItems(orderHeaderId);
        }

        /// <summary>
        /// Delete only one specific OrderItem from the OrderItem list
        /// </summary>
        /// <param name="orderHeaderId">OrderHeader Id - integer</param>
        /// <param name="stockItemId">StockItem Id - integer</param>
        /// <returns>return the OrderHeader object</returns>
        public OrderHeader DeleteOrderItem(int orderHeaderId, int stockItemId)
        {
            //call OrderRepo method - DeleteOrderItem
            OrdersRepo ordersRepo = new OrdersRepo();
            ordersRepo.DeleteOrderItem(orderHeaderId, stockItemId);
            OrderHeader orderHeader = ordersRepo.GetOrderHeader(orderHeaderId);
            return orderHeader;
        }
    }
}
