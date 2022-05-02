using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.API.Models.Entities
{
    public class ReviewEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ReviewStars { get; set; } 
        [Required]
        public string Comment { get; set; }
        [Required]
        public string VoterName { get; set; }
        [Required]
        public string VoterEmail { get; set; }


        [ForeignKey("product")] //this part can be changed if need be guys :)
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
    }
}
