using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShopping_Application.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "There must be an image")]
        public string ImageUrl { get; set; }
        [NotMapped]
        public  HttpPostedFileBase ImageFile { get; set; }
        public int CategoryId { get; set; }
       [NotMapped]
        public string categoryName { get; set; }
    }
}