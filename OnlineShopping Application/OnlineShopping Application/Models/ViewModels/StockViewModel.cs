using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopping_Application.Models
{    [Serializable]
    public class StockViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int StockId { get; set; }
        public decimal AvailableQuantity { get; set; }
        public decimal Quantity { get; set; }
        
    }
}