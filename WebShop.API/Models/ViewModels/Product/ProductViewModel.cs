namespace WebShop.API.Models.ViewModels.Product
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {

        }
        public ProductViewModel(int id, string name, string? description, decimal price, decimal? salePrice, string category, string color, string size, string brand, bool onSale, int quantity, int rating)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            SalePrice = salePrice;
            Category = category;
            Color = color;
            Size = size;
            Brand = brand;
            OnSale = onSale;
            Quantity = quantity;
            Rating = rating;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? SalePrice { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Brand { get; set; }
        public bool OnSale { get; set; }
        public int Quantity { get; set; }
        public int Rating { get; set; } = 0;
    }
}
