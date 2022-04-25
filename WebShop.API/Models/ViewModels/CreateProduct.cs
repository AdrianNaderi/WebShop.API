using System.ComponentModel.DataAnnotations;

namespace WebShop.API.Models.ViewModels
{
        public class CreateProduct
        {
                public string Name { get; set; }
                public decimal Price { get; set; }
                public string Color { get; set; }
                public string Size { get; set; }
                public string Brand { get; set; }
                public string Category { get; set; }
                public bool OnSale { get; set; }
                public int Quantity { get; set; }
                public int Rating { get; set; } = 0;
        }
}
