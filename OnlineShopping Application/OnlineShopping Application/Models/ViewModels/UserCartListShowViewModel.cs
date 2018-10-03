using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopping_Application.Models
{
    public class UserCartListShowViewModel
    {
        [Display(Name = "Cart Id")]
        public int CartId { get; set; }
        [Display(Name = "Product")]
        public int ProductId { get; set; }
        [Display(Name = "Customer Name")]
        public string UserId { get; set; }
        [Display(Name = "Product")]
        public string ProductName { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        
        public double Quantity { get; set; }

        public string Cost { get; set; }

    }
}