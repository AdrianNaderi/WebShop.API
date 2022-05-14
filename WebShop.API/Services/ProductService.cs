using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebShop.API.Data;
using WebShop.API.Models.Entities;
using WebShop.API.Models.ViewModels.Product;

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

        public async Task<bool> GetProductByName(string productName)
        {
            if (await _db.Products.AnyAsync(x => x.Name == productName))
                return true;
            else return false;
        }

        public async Task CreateProductAsync(CreateProduct product)
        {
            var productEntity = _mapper.Map<ProductEntity>(product);
            await _db.Products.AddAsync(productEntity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(ProductEntity product)
        {
            _db.Remove(product);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductEntity>> ReadAllProductsAsync()
        {
            var products = await _db.Products.ToListAsync();
            return products;
        }

        public async Task<ProductViewModel> ReadSingleProductAsync(int id)
        {
            var productEntity = await _db.Products.Include(x => x.BrandEntity).FirstOrDefaultAsync();
            return _mapper.Map<ProductViewModel>(productEntity);
        }

        public async Task UpdateProductAsync(UpdateProduct product)
        {
            var productEntity = _mapper.Map<UpdateProduct>(product);
            _db.Update(productEntity);
            await _db.SaveChangesAsync();

        }
    }
}
