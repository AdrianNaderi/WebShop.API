using WebShop.API.Models.Entities;
using WebShop.API.Models.ViewModels;

namespace WebShop.API.Services
{
        public class ProductService : IProductService
        {
                public Task CreateProductAsync(CreateProduct product)
                {
                        throw new NotImplementedException();
                }

                public Task DeleteProductAsync(Product product)
                {
                        throw new NotImplementedException();
                }

                public Task<IEnumerable<Product>> ReadAllProductsAsync()
                {
                        throw new NotImplementedException();
                }

                public Task<Product> ReadSingleProductAsync(int id)
                {
                        throw new NotImplementedException();
                }

                public Task UpdateProductAsync(UpdateProduct product)
                {
                        throw new NotImplementedException();
                }
        }
}
