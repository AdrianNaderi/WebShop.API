using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebShop.API.Models.Entities
{
        public class CategoryEntity
        {
                [Key]
                public string Category { get; set; }
                
                [ValidateNever]
                public ICollection<ProductEntity> Products { get; set; }
        }
}
