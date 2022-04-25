﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.API.Models.Entities
{
        public class Product
        {
                [Key]
                public int ID { get; set; }
                [Required]
                public string Name { get; set; }
                public string Description { get; set; }
                [Required]
                [Column(TypeName = "money")]
                public decimal Price { get; set; }
                [Required]
                public string Color { get; set; }
                [Required]
                public string Size { get; set; }
                [Required]
                public string Brand { get; set; }
                [Required]
                public string Category { get; set; }
                [Required]
                public bool OnSale { get; set; }
                [Required]
                public int Quantity { get; set; }
                [Required]
                public int Rating { get; set; } = 0;

        }
}
