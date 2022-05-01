using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.API.Models.Entities
{
    public class Order
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

        //public string? OrderStatus { get; set; }
        //public string? PaymentStatus { get; set; }

        [ValidateNever]
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}