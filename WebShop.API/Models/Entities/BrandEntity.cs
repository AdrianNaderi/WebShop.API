using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebShop.API.Models.Entities
{
    public class BrandEntity
    {
        [Key]
        public int BrandId { get; set; }
        [Required]
        public string BrandName { get; set; }
        public string Description { get; set; }

        [ValidateNever]
        public ICollection<ProductEntity> Products { get; set; }
    }
}
