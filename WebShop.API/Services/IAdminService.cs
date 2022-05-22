using WebShop.API.Models.ViewModels.Product;

namespace WebShop.API.Services
{
    public interface IAdminService
    {
        Task CreateCategoryAsync(CreateCategory category);
        Task CreateColorAsync(CreateColor color);
        Task UpdateColorAsync(string color, string hex);
        Task CreateBrandAsync(CreateBrand brand);
        Task CreateSizeAsync(CreateSize size);
        Task CreateProductColorAsync(CreateProductColor productColor);
    }
}
