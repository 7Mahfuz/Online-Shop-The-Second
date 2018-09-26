using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopping_Application.Models
{
    public class UserCartListShowViewModel
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public double Quantity { get; set; }
        public string Cost { get; set; }

    }
}