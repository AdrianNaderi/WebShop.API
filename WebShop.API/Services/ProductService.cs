using Microsoft.EntityFrameworkCore;
using WebShop.API.Data;
using WebShop.API.Models.Entities;
using WebShop.API.Models.ViewModels;

namespace WebShop.API.Services
{
        public class ProductService : IProductService
        {

                private readonly AppDbContext _db;

                public ProductService(AppDbContext db)
                {
                        _db = db;
                }

                public Task CreateProductAsync(CreateProduct product)
                {
                        throw new NotImplementedException();
                }

                public Task DeleteProductAsync(Product product)
                {
                        throw new NotImplementedException();
                }

                public async Task<IEnumerable<Product>> ReadAllProductsAsync()
                {
                        var products = await _db.Products.ToListAsync();
                        return products;
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
