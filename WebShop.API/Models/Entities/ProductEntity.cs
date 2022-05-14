using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.API.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Column(TypeName = "money")]
        public decimal? SalePrice { get; set; }


        [Required]
        [ForeignKey("CategoryEntity")]
        public string Category { get; set; }
        [ValidateNever]
        public CategoryEntity CategoryEntity { get; set; }

        [Required]
        [ForeignKey("ColorEntity")]
        public string Color { get; set; }
        [ValidateNever]
        public ColorEntity ColorEntity { get; set; }

        [Required]
        [ForeignKey("SizeEntity")]
        public string Size { get; set; }
        [ValidateNever]
        public SizeEntity SizeEntity { get; set; }

        [Required]
        [ForeignKey("BrandEntity")]
        public int BrandId { get; set; }
        [ValidateNever]
        public BrandEntity BrandEntity { get; set; }


        [Required]
        public bool OnSale { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Rating { get; set; } = 0;
    }
}
