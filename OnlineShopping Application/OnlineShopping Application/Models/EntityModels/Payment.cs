using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopping_Application.Models
{
    public class Payment
    {[Key]
        public int Id { get; set; }
        public string CreditCardNumber { get; set; }
        public string BkashNumber { get; set; }
        public bool IsActive { get; set; }

        public string UserId { get; set; }
    }
}