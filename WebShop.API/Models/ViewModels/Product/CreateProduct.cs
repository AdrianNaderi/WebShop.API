using System.ComponentModel.DataAnnotations;

namespace WebShop.API.Models.ViewModels.Product
{
    public class CreateProduct
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal? SalePrice { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Required]
        public bool OnSale { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Rating { get; set; } = 0;
        [Required]
        public string ImagePath { get; set; }

    }
}
