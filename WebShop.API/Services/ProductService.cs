using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebShop.API.Data;
using WebShop.API.Models.Entities;
using WebShop.API.Models.ViewModels;

namespace WebShop.API.Services
{
        public class ProductService : IProductService
        {

                private readonly AppDbContext _db;
                private readonly IMapper _mapper;

                public ProductService(AppDbContext db, IMapper mapper)
                {
                        _db = db;
                        _mapper = mapper;
                }

                public async Task CreateProductAsync(CreateProduct product)
                {
                        var productEntity = _mapper.Map<Product>(product);                   
                        await _db.Products.AddAsync(productEntity);
                        await _db.SaveChangesAsync();
                }

                public async Task DeleteProductAsync(Product product)
                {
                        _db.Remove(product);
                        await _db.SaveChangesAsync();
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

                public async Task UpdateProductAsync(UpdateProduct product)
                {
                        
	                   var productEntity = _mapper.Map<UpdateProduct>(product);                   
                       await _db.Products.Update(productEntity);
                       await _db.SaveChangesAsync();

                }
        }
}
