using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.API.Models.Entities
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ReviewStars { get; set; } 
        [Required]
        public string Comment { get; set; } = null!;
        [Required]
        public string VoterName { get; set; } = null!;
        [Required]
        public string VoterEmail { get; set; } = null!;


        [ForeignKey("product")] //this part can be changed if need be guys :)
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
