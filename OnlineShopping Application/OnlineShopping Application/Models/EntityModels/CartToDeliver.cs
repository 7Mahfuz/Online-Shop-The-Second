﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopping_Application.Models
{
    public class CartToDeliver
    {        [Key]
        public int Id { get; set; }
        [Display(Name = "Product")]
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public int PaymentId { get; set; }

        public string UserId { get; set; }
       
        
    }
}