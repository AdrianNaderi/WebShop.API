using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebShop.API.Models.Entities
{
        public class ProductEntity
        {
                [Key]
                public int Id { get; set; }
                [Required]
                public string Name { get; set; }
                public string Description { get; set; }
                [Required]
                [Column(TypeName = "money")]
                public decimal Price { get; set; }
                [Column(TypeName = "money")]
                public decimal? SalePrice { get; set; }


                [Required]
                public string Category { get; set; }
                [ValidateNever]
                public CategoryEntity CategoryEntity { get; set; }

                [Required]
                public string Color { get; set; }
                [ValidateNever]
                public ColorEntity ColorEntity { get; set; }
                
                [Required]
                public string Size { get; set; }
                public SizeEntity SizeEntity { get; set; }

                [Required]
                public string BrandId { get; set; }
                public BrandEntity BrandEntity { get; set; }


                [Required]
                public bool OnSale { get; set; }
                [Required]
                public int Quantity { get; set; }
                [Required]
                public int Rating { get; set; } = 0;
        }
}
