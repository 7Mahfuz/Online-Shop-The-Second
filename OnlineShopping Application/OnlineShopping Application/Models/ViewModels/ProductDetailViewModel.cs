using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopping_Application.Models
{
    public class ProductDetailViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Product")]
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        public int Qunatity { get; set; }
    }
}