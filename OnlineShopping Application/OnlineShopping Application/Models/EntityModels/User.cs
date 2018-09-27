using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopping_Application.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string ImagePath { get; set; }
       public string Address { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }

    }
}