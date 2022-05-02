using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.API.Models.Entities
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AppUserId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [Required]
        [Column(TypeName = "money")]
        public decimal OrderTotal { get; set; }

        [ValidateNever]
        public ICollection<OrderDetailEntity> OrderDetails { get; set; }
    }
}