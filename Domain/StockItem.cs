using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class StockItem
    {
        public int Id { get; set; }
        public int InStock { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public StockItem(int id, int inStock, string name, decimal price)
        {
            Id = id;
            InStock = inStock;
            Name = name;
            Price = price;
        }
    }
}
