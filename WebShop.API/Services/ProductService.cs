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

                public async Task CreateProductAsync(CreateProduct product)
                {
                        var productEntity = new Product
                        {
                            Name = product.Name,
                            Price = product.Price,
                            Description = product.Description,
                            Color = product.Color,
                            Size = product.Size,
                            Brand = product.Brand,
                            Category = product.Category,
                            OnSale = product.OnSale,
                            Quantity = product.Quantity,
                            Rating = product.Rating,
                            
                        };

                        await _db.Products.AddAsync(productEntity);
                        await _db.SaveChangesAsync();

                        new Product
                        {
                            Name = productEntity.Name,
                            Price = productEntity.Price,
                            Description = productEntity.Description,
                            Color = productEntity.Color,
                            Size = productEntity.Size,
                            Brand = productEntity.Brand,
                            Category = productEntity.Category,
                            OnSale = productEntity.OnSale,
                            Quantity = productEntity.Quantity,
                            Rating = productEntity.Rating,
                            

                        };
                

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
