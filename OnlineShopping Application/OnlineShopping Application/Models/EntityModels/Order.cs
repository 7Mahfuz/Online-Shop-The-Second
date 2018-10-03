using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopping_Application.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "User")]
        public string UserId { get; set; }
        public int CartToDeliverId { get; set; }
        [Display(Name = "Payment Id")]
        public int PaymentId { get; set; }

        public bool IsDone { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Delivery Address")]
        public string DeliveryAddress { get; set; }
        public DateTime Date { get; set; }
    }
}