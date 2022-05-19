namespace WebShop.API.Models.ViewModels
{
    public class Filter
    {
        public string Category { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Brand { get; set; }
        public string OnSale { get; set; }
        public string InStock { get; set; }
        public bool OrderByAsc { get; set; }
    }
}
