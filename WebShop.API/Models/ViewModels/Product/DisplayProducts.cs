namespace WebShop.API.Models.ViewModels.Product
{
    public class DisplayProducts
    {
        public ICollection<ProductViewModel> Products { get; set; }
        public int TotalPages { get; set; }

    }
}
