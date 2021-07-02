using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controllers;
using System.Collections.Generic;
using Domain;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetOrderHeaders()
        {
            //Arange
            OrdersController _orderCont= new OrdersController();

            //Act
            IEnumerable<OrderHeader> OrderHeaders = _orderCont.GetOrderHeaders();

            //Assert
            Assert.IsTrue(OrderHeaders.Count() > 0);
        }

        [TestMethod]
        public void CreateNewOrderHeader()
        {
            //Arange
            OrdersController _orderCont = new OrdersController();

            //Act
           OrderHeader order = _orderCont.CreateNewOrderHeader();

            //Assert
            Assert.AreEqual("OrderNew", order.State.GetType().Name);//Initial state is New
            Assert.AreEqual(0, order.Total);//Initial total is zero

        }

        [TestMethod]
        public void UpsertOrderItem()
        {
            //Arange
            OrdersController _orderCont = new OrdersController();

            //Act
            OrderHeader order = _orderCont.CreateNewOrderHeader();
            order = _orderCont.UpsertOrderItem(order.Id, 4, 1);
            order = _orderCont.UpsertOrderItem(order.Id, 4, 2);
            order = _orderCont.UpsertOrderItem(order.Id, 5, 2);
            order = _orderCont.UpsertOrderItem(order.Id, 3, 1);

            //Assert
            Assert.AreEqual(3, order.OrderItems.Count);
            Assert.AreEqual(920, order.Total);
        }

        [TestMethod]
        public void SubmitOrder()
        {
            //Arange
            OrdersController _orderCont = new OrdersController();

            //Act
            OrderHeader order = _orderCont.CreateNewOrderHeader();
            order = _orderCont.UpsertOrderItem(order.Id, 4, 1);
            order = _orderCont.UpsertOrderItem(order.Id, 4, 2);
            order = _orderCont.SubmitOrder(order.Id);

            //Assert
            Assert.AreEqual("OrderPending", order.State.GetType().Name);// state is changed from New to Pending
        }

        [TestMethod]
        public void ProcessOrder()
        {
            //Arange
            OrdersController _orderCont = new OrdersController();

            //Act
            OrderHeader order = _orderCont.CreateNewOrderHeader();
            order = _orderCont.UpsertOrderItem(order.Id, 5, 1);
            order = _orderCont.UpsertOrderItem(order.Id, 7, 2);
            order = _orderCont.SubmitOrder(order.Id);
            order = _orderCont.ProcessOrder(order.Id);

            //Assert
            Assert.AreEqual("OrderComplete", order.State.GetType().Name);// state is changed from Pending to Complete
        }

        [TestMethod]
        public void DeleteOrderHeaderAndOrderItems()
        {
            //Arange
            OrdersController _orderCont = new OrdersController();

            //Act
            IEnumerable<OrderHeader> orderHeaders = _orderCont.GetOrderHeaders();
            int ordersCount = orderHeaders.Count();
            _orderCont.DeleteOrderHeaderAndOrderItems(40);// try 32, 40
            orderHeaders = _orderCont.GetOrderHeaders();
            //Assert
            Assert.AreEqual(ordersCount-1, orderHeaders.Count());
        }

        [TestMethod]
        public void DeleteOrderItem()
        {
            //Arange
            OrdersController _orderCont = new OrdersController();

            //Act
            OrderHeader order = _orderCont.CreateNewOrderHeader();
            order = _orderCont.UpsertOrderItem(order.Id, 1, 1);
            order = _orderCont.UpsertOrderItem(order.Id, 1, 2);
            order = _orderCont.UpsertOrderItem(order.Id, 4, 2);
            order = _orderCont.UpsertOrderItem(order.Id, 9, 1);

            int orderItemCount = order.OrderItems.Count;

            order = _orderCont.DeleteOrderItem(order.Id, 9);

            //Assert
            Assert.AreEqual(orderItemCount - 1, order.OrderItems.Count);
        }

        [TestMethod]
        public void GetStockItems()
        {
            //Arange
            StockItemsController stockCont = new StockItemsController();

            //Act
            IEnumerable<StockItem> stockItems = stockCont.GetStockItems();

            //Assert
            Assert.IsTrue(stockItems.Count() > 0);
        }
    }
}
