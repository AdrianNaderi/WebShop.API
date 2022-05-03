using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebShop.API.Models.Entities
{
    public class ColorEntity
    {
        [Key]
        public string Color { get; set; }

        [ValidateNever]
        public ICollection<ProductEntity> Products { get; set; }
    }
}
