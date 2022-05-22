namespace WebShop.API.Models.ViewModels.FilterData
{
    public class FilterViewModel
    {
        public ICollection<CategoryFilterOption> Categories { get; set; }
        public ICollection<ColorFilterOption> Colors { get; set; }
        public ICollection<SizeFilterOption> Sizes { get; set; }
    }
}
