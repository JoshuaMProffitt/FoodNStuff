using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodNStuff.MVC.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        [Display(Name = "ProductName")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "# In Stock")]
        public int InventoryCount { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        [Display(Name = "It is food")]
        public bool IsFood { get; set; }
    }
}