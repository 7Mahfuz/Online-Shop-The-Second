using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopping_Application.Models
{
    public class OrderListViewModel
    {
        public int SL { get; set; }
        public int OrderId { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }
        public int PaymentId { get; set; }
        public string Address { get; set; }
    }
}