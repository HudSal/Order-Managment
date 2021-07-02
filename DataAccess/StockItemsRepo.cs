using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class StockItemsRepo
    {
        private string _connectionString = @"Data Source=DESKTOP-E4R8AFA\SQLEXPRESS;Initial Catalog=OrderManagementDb;Integrated Security=True";
        
        /// <summary>
        /// Get all StockItems from the database
        /// </summary>
        /// <returns>return list of StockItem objects</returns>
        public IEnumerable<StockItem> GetStockItems(){
            
            //create conn obj
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();

            //create comm obj - #3
            SqlCommand command = new SqlCommand("sp_SelectStockItems", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            //execute comm - #4
            SqlDataReader reader = command.ExecuteReader();

            //handle results - #5
            List<StockItem> stocks = new List<StockItem>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    decimal price = reader.GetDecimal(2);
                    int inStock = reader.GetInt32(3);
                    stocks.Add(new StockItem(id, inStock, name, price));
                }
            }
            connection.Close();
            return stocks;
        }

        /// <summary>
        /// Search in the database and get Only one specific StockItem by using the Id number
        /// </summary>
        /// <param name="id">Stock Item Id- integer</param>
        /// <returns>return the found StockItem object</returns>
        public StockItem GetStockItem(int id)
        {
            
            //create conn obj
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();

            //create comm obj - #3
            SqlCommand command = new SqlCommand("sp_SelectStockItemById", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@id", id));

            //execute comm - #4
            SqlDataReader reader = command.ExecuteReader();

            //hundle the result- #5
            StockItem stockItem = null;
            if (reader.HasRows)
            {
                reader.Read();
                string name = reader.GetString(1);
                decimal price = reader.GetDecimal(2);
                int inStock = reader.GetInt32(3);
                stockItem = new StockItem(id, inStock, name, price);
            }

            connection.Close();
            return stockItem;
        }

        /// <summary>
        /// Update the ammount of the stockItem in the database
        /// </summary>
        /// <param name="order">OrderHeader object</param>
        public void UpdateStockItemAmount(OrderHeader order)
        {
           // iterate through each item in the orderItems list & reduce the quantity of each item by calling the sproc

             //List<OrderItem> orderItems = GetOrderItem(order);

            List<OrderItem> orderItems = order.OrderItems;

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            SqlCommand command = new SqlCommand("sp_UpdateStockItemAmount", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (var item in orderItems)
            {
              
                command.Parameters.Add(new SqlParameter("@id", item.StockItemId));
                command.Parameters.Add(new SqlParameter("@amount", -item.Quantity));
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }

            connection.Close();

        }

        //public void UpdateStockItemAmount(OrderHeader order)
        //{
        //    SqlConnection connection = new SqlConnection(_connectionString);
        //    connection.Open();
        //    SqlCommand command = new SqlCommand("sp_UpdateStockItemAmount", connection);
        //    command.CommandType = System.Data.CommandType.StoredProcedure;
        //    var transaction = connection.BeginTransaction("UpdateStockAmountTransaction");
        //    command.Transaction = transaction;
        //    try
        //    {
        //        foreach (var oi in order.OrderItems)
        //        {
        //            command.Parameters.Add(new SqlParameter("@id", oi.StockItemId));
        //            command.Parameters.Add(new SqlParameter("@amount", -oi.Quantity));
        //            command.ExecuteNonQuery();
        //            command.Parameters.Clear();
        //        }
        //        transaction.Commit();
        //    }
        //    catch (SqlException ex)
        //    {
        //        transaction.Rollback();
        //        throw ex;
        //    }
        //    connection.Close();
         //   }


        //public List<OrderItem> GetOrderItem (OrderHeader order)
        //{
        //    //create conn obj
        //    SqlConnection connection = new SqlConnection();
        //    connection.ConnectionString = _connectionString;
        //    connection.Open();
        //    SqlCommand command = new SqlCommand("sp_SelectOrderHeaderById", connection);
        //    command.CommandType = System.Data.CommandType.StoredProcedure;
        //    command.Parameters.Add(new SqlParameter("@id", order.Id));

        //    SqlDataReader reader = command.ExecuteReader();
        //    //List<int> stockItemsId = new List<int>();
        //    //List<int> quatities = new List<int>();
        //    List<OrderItem> orderItems = new List<OrderItem>();
        //    if (reader.HasRows)
        //    {
        //        while (reader.Read())
        //        {
        //            //int orderHeaderId = reader.GetInt32(0);
        //            int stockItemId = reader.GetInt32(3);
        //            string descrption = reader.GetString(4);
        //            decimal price = reader.GetDecimal(5);
        //            int quantity = reader.GetInt32(6);
        //            //stockItemsId.Add(stockItemId);
        //            //quatities.Add(quantity);
        //            orderItems.Add(new OrderItem(descrption, order, price, quantity, stockItemId));
        //        }
        //    }
        //    connection.Close();
        //    return orderItems;
        //}
    }
}
