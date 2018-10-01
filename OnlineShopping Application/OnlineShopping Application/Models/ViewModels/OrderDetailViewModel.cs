using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopping_Application.Models
{
    public class OrderDetailViewModel
    {
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhn { get; set; }
        public int  PaymentId { get; set; }

        public string PaymentType { get; set; }
        public DateTime PaymentDate { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}