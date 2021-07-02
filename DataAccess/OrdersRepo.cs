using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrdersRepo
    {
        private string _connectionString = @"Data Source=DESKTOP-E4R8AFA\SQLEXPRESS;Initial Catalog=OrderManagementDb;Integrated Security=True";
        /// <summary>
        /// Create Insert in the database new Order Header by generate new unique Id and capture the date and time with "New" state 
        /// </summary>
        /// <returns>return the new order header object</returns>
        public OrderHeader InsertOrderHeader()
        {
            //get the generated order header id
            //connection object
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();

            //command object
            //create comm obj - #3
            SqlCommand command = new SqlCommand("sp_InsertOrderHeader", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            ////excute coomand--#4
            int newId = Convert.ToInt32(command.ExecuteScalar());

            //get the details of the new order header - search by id
            OrderHeader newOrderHeader = GetOrderHeader(newId);
            connection.Close();
            //return the order details
            return newOrderHeader;
        }

        /// <summary>
        /// Search by id to get the OrderHeader details
        /// </summary>
        /// <param name="id">order header Id- integer</param>
        /// <returns>return the order header details</returns>
        public OrderHeader GetOrderHeader(int id)
        {
            //connection object
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();

            //command object
            SqlCommand command = new SqlCommand("sp_SelectOrderHeaderById", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@id", id));

            SqlDataReader reader = command.ExecuteReader();
            OrderHeader orderHeader = null;
            if (reader.HasRows)
            {
                while (reader.Read()) 
                {
                    if (orderHeader == null) 
                    { 
                        int orderStateId = reader.GetInt32(1);
                        DateTime dateTime = reader.GetDateTime(2);
                        orderHeader = new OrderHeader(id, dateTime, orderStateId);
                    }
                    if (orderHeader != null && !reader.IsDBNull(3))
                    {
                        int stockItemId = reader.GetInt32(3);
                        string desc = reader.GetString(4);
                        decimal price = reader.GetDecimal(5);
                        int quantity = reader.GetInt32(6);
                        orderHeader.AddOrderItem(stockItemId, price, desc, quantity);
                    }
                }
            }
            //return the order details
            connection.Close();
            return orderHeader;
        }

        /// <summary>
        /// Get the details for all OrderHeaders objects from the database
        /// </summary>
        /// <returns>return list of OrderHeaders</returns>
        public IEnumerable<OrderHeader> GetOrderHeaders()
        {
            //create conn obj
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();

            //create comm obj - #3
            SqlCommand command = new SqlCommand("sp_SelectOrderHeaders", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            //execute comm - #4
            SqlDataReader reader = command.ExecuteReader();

            //handle results - #5
            List<OrderHeader> orderHeaders = new List<OrderHeader>();
            OrderHeader orderHeader = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    if (orderHeader == null || orderHeader.Id != id)
                    {
                        int orderStateId = reader.GetInt32(1);
                        DateTime dateTime = reader.GetDateTime(2);
                        orderHeader = new OrderHeader(id, dateTime, orderStateId);
                        orderHeaders.Add(orderHeader);
                    }
                    if (orderHeader != null && !reader.IsDBNull(3))
                    {
                        int stockItemId = reader.GetInt32(3);
                        string desc = reader.GetString(4);
                        decimal price = reader.GetDecimal(5);
                        int quantity = reader.GetInt32(6);
                        orderHeader.AddOrderItem(stockItemId, price, desc, quantity);
                    }
                }
            }
            connection.Close();
            return orderHeaders;
        }

        /// <summary>
        /// Update the quantity of the orderitem or insert new Order Item in Order Header
        /// </summary>
        /// <param name="orderItem">Order Item object</param>
        public void UpsertOrderItem(OrderItem orderItem)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();

            //create comm obj - #3
            SqlCommand command = new SqlCommand("sp_UpsertOrderItem", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@orderHeaderId", orderItem.OrderHeader.Id));
            command.Parameters.Add(new SqlParameter("@stockItemId", orderItem.StockItemId));
            command.Parameters.Add(new SqlParameter("@description", orderItem.Description));
            command.Parameters.Add(new SqlParameter("@price", orderItem.Price));
            command.Parameters.Add(new SqlParameter("@quantity", orderItem.Quantity));
            //execute comm - #4
            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Update the status of the OrderHeader 
        /// </summary>
        /// <param name="order">OrderHeader object</param>
        public void UpdateOrderState(OrderHeader order)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
    
            //create comm obj - #3
            SqlCommand command = new SqlCommand("sp_UpdateOrderState", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@orderHeaderId", order.Id));
            command.Parameters.Add(new SqlParameter("@stateId",(int)order.State.State));

            //execute comm - #4
            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Delete OrderHeader from database and delete all the OrderItems which is included under the OrderHeader
        /// </summary>
        /// <param name="orderHeaderId">OrderHeader Id - integer</param>
        public void DeleteOrderHeaderAndOrderItems(int orderHeaderId)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand("sp_DeleteOrderHeaderAndOrderItems", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@orderHeaderId", orderHeaderId));

            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Delete only one specific OrderItem from the OrderItem list in the database
        /// </summary>
        /// <param name="orderHeaderId">OrderHeader Id - integer</param>
        /// <param name="stockItemId">StockItem Id - integer</param>
        public void DeleteOrderItem(int orderHeaderId, int stockItemId)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand("sp_DeleteOrderItem", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@orderHeaderId", orderHeaderId));
            command.Parameters.Add(new SqlParameter("@stockItemId", stockItemId));

            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}
