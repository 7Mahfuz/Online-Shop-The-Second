using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopping_Application.Models
{    [Serializable]
    public class StockViewModel
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
       public decimal AvailableQuantity { get; set; }
        public decimal Quantity { get; set; }
        
    }
}