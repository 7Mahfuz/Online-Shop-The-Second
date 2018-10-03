using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopping_Application.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Select Product")]
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }

    }
}