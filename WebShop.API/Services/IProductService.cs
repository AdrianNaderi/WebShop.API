﻿using WebShop.API.Models.Entities;
using WebShop.API.Models.ViewModels;

namespace WebShop.API.Services
{
    public interface IProductService
    {
        Task CreateProductAsync(CreateProduct product);
        Task<IEnumerable<ProductEntity>> ReadAllProductsAsync();
        Task<ProductEntity> ReadSingleProductAsync(int id);
        Task DeleteProductAsync(Product product);
        Task UpdateProductAsync(UpdateProduct product);
        Task<bool> GetProductByName(string productName);

    }
}
