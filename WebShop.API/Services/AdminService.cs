using AutoMapper;
using WebShop.API.Data;
using WebShop.API.Models.Entities;
using WebShop.API.Models.ViewModels.Product;

namespace WebShop.API.Services
{
    public class AdminService : IAdminService
    {
         private readonly AppDbContext _db;
        public AdminService(AppDbContext db)
        {
            _db = db;
        }

        public async Task CreateBrandAsync(CreateBrand brand)
        {
            var brandEntity = new BrandEntity()
            {
                BrandName = brand.BrandName,
                Description = brand.BrandDescription
            };

            await _db.AddAsync(brandEntity);
            await _db.SaveChangesAsync();
        }

        public async Task CreateCategoryAsync(CreateCategory category)
        {
            var categoryEntity = new CategoryEntity()
            {
                Category = category.CategoryName
            };

            await _db.AddAsync(categoryEntity);
            await _db.SaveChangesAsync();
        }

        public async Task CreateColorAsync(CreateColor color)
        {
            var colorEntity = new ColorEntity()
            {
                Color = color.ColorName,
                Hex = color.Hex
            };

            await _db.AddAsync(colorEntity);
            await _db.SaveChangesAsync();
        }

        public async Task CreateProductColorAsync(CreateProductColor productColor)
        {
            var entity = new ProductColor()
            {
                ProductId = productColor.Product,
                ColorName = productColor.Color
            };
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task CreateSizeAsync(CreateSize size)
        {
            var sizeEntity = new SizeEntity()
            {
                Size = size.SizeName,
            };
            await _db.AddAsync(sizeEntity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateColorAsync(string color, string hex)
        {
            var colorResult =_db.Colors.FirstOrDefault(x => x.Color == color);
            colorResult.Hex = hex;
            _db.Colors.Update(colorResult);
            await _db.SaveChangesAsync();
        }
    }
}
