﻿using WebShop.API.Models.Entities;
using WebShop.API.Models.ViewModels;
using WebShop.API.Models.ViewModels.FilterData;
using WebShop.API.Models.ViewModels.Product;

namespace WebShop.API.Services
{
    public interface IProductService
    {
        Task CreateProductAsync(CreateProduct product);
        Task<DisplayProducts> ReadAllProductsAsync(DisplayOptions options);
        Task<ProductViewModel> ReadSingleProductAsync(int id);
        Task DeleteProductAsync(ProductEntity product);
        Task UpdateProductAsync(UpdateProduct product);
        Task<bool> GetProductByName(string productName);
        Task<IEnumerable<ProductEntity>> GetFilteredProductsAsync(Filter filter);

        Task<FilterViewModel> GetFilterData();
    }
}
