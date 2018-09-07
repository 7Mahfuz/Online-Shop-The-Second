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
        public string UserId { get; set; }
        public int CartToDeliverId { get; set; }
        public int PaymentId { get; set; }

        public bool IsDone { get; set; }
        public bool IsActive { get; set; }
        public string DeliveryAddress { get; set; }
    }
}