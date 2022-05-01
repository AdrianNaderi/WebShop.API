﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebShop.API.Models.Entities
{
        public class ColorEntity
        {
                [Key]
                public string Color { get; set; }

                [ValidateNever]
                public ICollection<Product> Products { get; set; }
        }
}
