using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.API.Models.Entities
{
        public class OrderDetailEntity
        {
                [Key]
                public int Id { get; set; }
                public int Quantity { get; set; }
                [Column(TypeName = "money")]
                public double UnitPrice { get; set; }


                public string Name { get; set; }
                public string? Description { get; set; }
                public decimal Price { get; set; }
                public string Category { get; set; }
                public string Color { get; set; }
                public string Size { get; set; }
                public string Brand { get; set; }


                [Required]
                public int OrderId { get; set; }
                [ForeignKey("OrderId")]
                [ValidateNever]
                public OrderEntity Order { get; set; }


        }
}
