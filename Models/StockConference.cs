using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stock_manager.Models
{
    public class StockConference
    {

        public StockConference(int productId,decimal quantity, decimal price)
        {
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        
    }
}