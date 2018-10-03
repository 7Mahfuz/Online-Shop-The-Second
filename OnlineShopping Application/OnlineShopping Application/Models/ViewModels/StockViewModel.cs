using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopping_Application.Models
{    [Serializable]
    public class StockViewModel
    {
        [Display(Name = "Select Product")]
        public int CategoryId { get; set; }
        [Display(Name = "Select Product")]
        public int ProductId { get; set; }
        [Display(Name = "Stock Quantity")]
        public decimal AvailableQuantity { get; set; }
        [Display(Name = "Add Quantity")]
        [Range(0,1000,ErrorMessage = "Qantity Can not negative")]
        public decimal Quantity { get; set; }
        
    }
}