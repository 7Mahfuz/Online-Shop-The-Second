using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopping_Application.Models
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Image")]
        public string ImagePath { get; set; }
       public string Address { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }

    }
}