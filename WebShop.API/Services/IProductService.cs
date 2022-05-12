using WebShop.API.Models.Entities;
using WebShop.API.Models.ViewModels;

namespace WebShop.API.Services
{
    public interface IProductService
    {
        Task CreateProductAsync(CreateProduct product);
        Task<IEnumerable<ProductEntity>> ReadAllProductsAsync();
        Task<ProductEntity> ReadSingleProductAsync(int id);
        Task DeleteProductAsync(ProductEntity product);
        Task UpdateProductAsync(UpdateProduct product);

    }
}
