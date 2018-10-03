using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopping_Application.Models
{
    public class OrderListViewModel
    {
        [Display(Name = "Seral No")]
        public int SL { get; set; }
        [Display(Name = "Order Id")]
        public int OrderId { get; set; }
        [Display(Name = "Customer Name")]
        public string UserId { get; set; }
        [Display(Name = "Customer Name")]
        public string UserName { get; set; }
        [Display(Name = "Payment Id")]
        public int PaymentId { get; set; }
        [Display(Name = "Customer Address")]
        public string Address { get; set; }
        public DateTime Date { get; set; }
    }
}