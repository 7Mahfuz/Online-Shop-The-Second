using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopping_Application.Models
{
    public class PaymentPageViewModel
    {
        [Display(Name = "Credit Card Number")]
        public string CreditCardNumber { get; set; }
        [Display(Name = "Bkash Number")]
        public string Bkash { get; set; }
        [Display(Name = "Transaction Number")]
        public string TrxNo { get; set; }
        [Required]
        public string Address { get; set; }
        [Display(Name = "Cash on Delivery")]
        public bool CashOnDelivery { get; set; }

    }
}