using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopping_Application.Models
{
    public class FeedBack
    {[Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
        public DateTime Date { get; set; }

    }
}