using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataAccess;
using Controllers;

namespace HookIn
{
    class Program
    {
        static void Main(string[] args)
        {

            //OrderHeader order = new OrderHeader(1,);

            //try
            //{
            //    order.Submit();
            //    Console.WriteLine(order.State.GetType().Name);
            //    order.Complete();
            //    Console.WriteLine(order.State.GetType().Name);
            //    order.Reject();
            //    Console.WriteLine(order.State.GetType().Name);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //OrderItem orderItem = new OrderItem("Bed", order, 90, 2, 1);
            //order.AddOrderItem(orderItem);
            //Console.WriteLine(order.Total);

            //Test GetStockItems() in StockItemRepo class//////////

            //StockItemsRepo repo = new StockItemsRepo();
            //IEnumerable<StockItem> stockItems = repo.GetStockItems();
            //Console.WriteLine(stockItems.Count() + " stock Items");
            //foreach (StockItem item in stockItems)
            //{
            //    Console.WriteLine(item.Id + " " + item.Name + " " + item.Price + " " + item.InStock);
            //}
            //StockItemsController stockItemsController = new StockItemsController();
            //IEnumerable<StockItem> stockItems = stockItemsController.GetStockItems();
            //Console.WriteLine(stockItems.Count() + " stock Items");
            //foreach (StockItem item in stockItems)
            //{
            //    Console.WriteLine(item.Id + " " + item.Name + " " + item.Price + " " + item.InStock);
            //}

            //Test GetStockItem(int id) in StockItemRepo class /////

            //StockItem item1= repo.GetStockItem(3);
            //Console.WriteLine(item1.Id + " " + item1.Name + " " + item1.Price + " " + item1.InStock);

            //repo.UpdateStockItemAmount(order);
            //StockItem item1 = repo.GetStockItem(1);
            //Console.WriteLine(item1.Id + " " + item1.Name + " " + item1.Price + " " + item1.InStock);

            //Testing GetOrderHeaders() (OrderRepo Class)///////////
            //OrdersRepo repo = new OrdersRepo();
            //OrdersCotroller ordersControllers = new OrdersCotroller();
            //IEnumerable<OrderHeader> orderHeaders = ordersControllers.GetOrderHeaders();
            //Console.WriteLine(orderHeaders.Count() + " OrderHeaders");
            //foreach (OrderHeader item in orderHeaders)
            //{
            //    Console.WriteLine(item.Id + " " + item.State.GetType().Name + " " + item.DateTime + " " + item.Total);
            //}

            //Testing GetOrderHeader by Id (OrderRepo class)////////
            //OrderHeader orderHeader = repo.GetOrderHeader(13);
            //Console.WriteLine(orderHeader.Id + " " + orderHeader.State.GetType().Name + " " + orderHeader.DateTime + " " + orderHeader.Total);

            //Testing InsertOrderHeader (OrderRepo class)///////
            //OrderHeader orderHeader = repo.InsertOrderHeader();
            //OrdersController ordersControllers = new OrdersController();
            //OrderHeader orderHeader = ordersControllers.CreateNewOrderHeader();
            //Console.WriteLine(orderHeader.Id + " " + orderHeader.State.GetType().Name + " " + orderHeader.DateTime + " " + orderHeader.Total);

            //Testing UpdateOrderState(OrderHeader order) => (OrderRepo class)/////////
            //OrdersRepo repo = new OrdersRepo();
            //OrderHeader orderHeader = repo.GetOrderHeader(18);/////
            //Console.WriteLine(orderHeader.Id + " " + orderHeader.State.GetType().Name + " " + orderHeader.DateTime + " " + orderHeader.Total);
            //OrderHeader orderHeader1 = new OrderHeader(orderHeader.Id, orderHeader.DateTime,3);
            //repo.UpdateOrderState(orderHeader1);
            //Console.WriteLine(orderHeader.Id + " " + orderHeader.State.GetType().Name + " " + orderHeader.DateTime + " " + orderHeader.Total);

            //Testing  UpdateStockItemAmount(OrderHeader order) => StockItemRepo/////////////
            //StockItemsRepo stockRepo = new StockItemsRepo();
            //OrdersRepo repo = new OrdersRepo();
            //OrderHeader orderHeader = repo.GetOrderHeader(16);
            //stockRepo.UpdateStockItemAmount(orderHeader);
            //IEnumerable<StockItem> stockItems = stockRepo.GetStockItems();
            //Console.WriteLine(stockItems.Count() + " stock Items");
            //foreach (StockItem item in stockItems)
            //{
            //    Console.WriteLine(item.Id + " " + item.Name + " " + item.Price + " " + item.InStock);
            //}

            //Testing DeleteOrderHeaderAndOrderItems(int orderHeaderId) => OrdersRepo///////
            //OrdersRepo repo = new OrdersRepo();
            //repo.DeleteOrderHeaderAndOrderItems(19);


            //Testing DeleteOrderItem(int orderHeaderId, int stockItemId) => OrderRepo///////////
            //OrdersRepo repo = new OrdersRepo();
            //repo.DeleteOrderItem(18, 5);

            //Testing UpsertOrderItem(OrderItem orderItem) => (OrderRepo Class)////
            //OrdersRepo repo = new OrdersRepo();
            //OrderHeader orderHeader = repo.GetOrderHeader(18);
            //OrderItem orderItem = new OrderItem("Table", orderHeader, 100, 2, 1);
            //OrderItem orderItem1 = new OrderItem("Single Bed", orderHeader, 120, 1, 6);
            //repo.UpsertOrderItem(orderItem);
            //repo.UpsertOrderItem(orderItem1);

            //OrdersController ordersControllers = new OrdersController();
            //OrderHeader orderHeader = ordersControllers.UpsertOrderItem(8,4,2);
            //OrderHeader orderHeader2 = ordersControllers.UpsertOrderItem(8, 5, 3);
            //Console.WriteLine(orderHeader2.Id + " " + orderHeader2.State.GetType().Name + " " + orderHeader2.DateTime + " " + orderHeader2.Total);
            //List<OrderItem> orderItems = orderHeader2.OrderItems;
            //Console.WriteLine(orderItems.Count() + " order Items");
            //foreach (OrderItem item in orderItems)
            //{
            //    Console.WriteLine(item.Description + " " + item.OrderHeaderId + " " + item.Price + " " + item.Quantity+" "+item.Total+" "+item.StockItemId);
            //}


            //Testing SubmitOrder=> OrdersController Class
            //OrdersController ordersController = new OrdersController();
            //OrderHeader orderHeader = ordersController.SubmitOrder(13);
            //Console.WriteLine(orderHeader.Id + " " + orderHeader.State.GetType().Name + " " + orderHeader.DateTime + " " + orderHeader.Total);

            //Testing ProcessOrder => OrdersController Class
            //OrdersController ordersController = new OrdersController();
            //OrderHeader orderHeader = ordersController.ProcessOrder(17);
            //Console.WriteLine(orderHeader.Id + " " + orderHeader.State.GetType().Name + " " + orderHeader.DateTime + " " + orderHeader.Total);

            //Testing DeleteOrderHeaderAndOrderItems  => OrdersController Class
            //OrdersController ordersController = new OrdersController();
            //OrdersRepo ordersRepo = new OrdersRepo();
            //OrderHeader orderHeader = ordersRepo.GetOrderHeader(20);
            //ordersController.DeleteOrderHeaderAndOrderItems(20);
            //Console.WriteLine(orderHeader.Id + " " + orderHeader.State.GetType().Name + " " + orderHeader.DateTime + " " + orderHeader.Total);

            //Testing DeleteOrderItem => OrdersController Class
            //OrdersController ordersController = new OrdersController();
            //OrderHeader orderHeader = ordersController.DeleteOrderItem(6,1);
            //Console.WriteLine(orderHeader.Id + " " + orderHeader.State.GetType().Name + " " + orderHeader.DateTime + " " + orderHeader.Total);
            //List<OrderItem> orderItems = orderHeader.OrderItems;
            //Console.WriteLine(orderItems.Count() + " order Items");
            //foreach (OrderItem item in orderItems)
            //{
            //    Console.WriteLine(item.Description + " " + item.OrderHeaderId + " " + item.Price + " " + item.Quantity + " " + item.Total + " " + item.StockItemId);
            //}


            //create a new order header
            OrdersController ordersController = new OrdersController();
            var order1 = ordersController.CreateNewOrderHeader();
            //what is current order state?
            Console.WriteLine($"After creating order: {order1.State.GetType().Name}");

            //add an order item to the new order header
            order1 = ordersController.UpsertOrderItem(order1.Id, 1, 1);
            order1 = ordersController.UpsertOrderItem(order1.Id, 1, 2);
            order1 = ordersController.UpsertOrderItem(order1.Id, 2, 3);
            order1 = ordersController.UpsertOrderItem(order1.Id, 3, 3);
            order1 = ordersController.DeleteOrderItem(order1.Id, 2);

            //submit order
            order1 = ordersController.SubmitOrder(order1.Id);

            //what is current order state?
            Console.WriteLine($"After submitting order: {order1.State.GetType().Name}");

            //process order
            order1 = ordersController.ProcessOrder(order1.Id);
            Console.WriteLine($"After processing order: {order1.State.GetType().Name}");

            var order2 = ordersController.CreateNewOrderHeader();
            order2 = ordersController.UpsertOrderItem(order2.Id, 4, 1);
            order2 = ordersController.UpsertOrderItem(order2.Id, 4, 2);
            order2 = ordersController.UpsertOrderItem(order2.Id, 5, 3);
            order2 = ordersController.UpsertOrderItem(order2.Id, 3, 3);


            var order3 = ordersController.CreateNewOrderHeader();
            order3 = ordersController.UpsertOrderItem(order3.Id, 4, 1);
            order3 = ordersController.UpsertOrderItem(order3.Id, 4, 2);
            order3 = ordersController.UpsertOrderItem(order3.Id, 5, 3);
            order3 = ordersController.UpsertOrderItem(order3.Id, 3, 3);

            //OrdersCotroller ordersControllers = new OrdersCotroller();
            IEnumerable<OrderHeader> orderHeaders = ordersController.GetOrderHeaders();
            Console.WriteLine(orderHeaders.Count() + " OrderHeaders");
            foreach (OrderHeader item in orderHeaders)
            {
                Console.WriteLine(item.Id + " " + item.State.GetType().Name + " " + item.DateTime + " " + item.Total);
            }

            Console.ReadKey();
        
        }
    }
}
