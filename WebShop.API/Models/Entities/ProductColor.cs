using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.API.Models.Entities
{
    public class ProductColor
    {
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }

        
        [ForeignKey("Color")]
        public string ColorName { get; set; }
        public ColorEntity Color { get; set; }
    }
}
