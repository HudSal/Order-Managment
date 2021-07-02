using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class StockItemsController
    {
        /// <summary>
        ///  Get all StockItem objects
        /// </summary>
        /// <returns>return list of StockItem objects</returns>
        public IEnumerable<StockItem> GetStockItems()
        {
            StockItemsRepo stockItemsRepo = new StockItemsRepo();
            IEnumerable<StockItem> stockItems = stockItemsRepo.GetStockItems();
            return stockItems;
        }
    }
}
