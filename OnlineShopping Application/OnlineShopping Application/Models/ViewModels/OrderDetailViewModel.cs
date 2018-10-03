using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopping_Application.Models
{
    public class OrderDetailViewModel
    {
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Display(Name = "Address")]
        public string CustomerAddress { get; set; }
        [Display(Name = "Customer Phone Number")]
        public string CustomerPhn { get; set; }
        [Display(Name = "Payment Seial Id")]
        public int  PaymentId { get; set; }
        [Display(Name = "Payment Type")]
        public string PaymentType { get; set; }
        [Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; }
        [Display(Name = "Order Id")]
        public int OrderId { get; set; }
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
    }
}