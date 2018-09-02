using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopping_Application.Models
{
    public class CartToDeliver
    {        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public string UserId { get; set; }
       
        
    }
}