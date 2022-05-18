using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.API.Models.Entities;
using WebShop.API.Models.ViewModels.Product;

namespace WebShop.Tests.UnitTests.Fixtures
{
    public static class ProductFixtures
    {
        private static List<ProductViewModel> _products = new List<ProductViewModel>()
        {
            new ProductViewModel{Id= 1, Name="Nike OneRun", Description="track shoes", Price= 599, SalePrice=449, Category="Shoes", Color="Black", Size="41", Brand="Nike", OnSale=true, Quantity=4, Rating=4 },
            new ProductViewModel{Id= 2, Name="Addidas Clifton", Description="track shoes", Price= 699, SalePrice=449, Category="Shoes", Color="Blue", Size="42", Brand="Addidas", OnSale=true, Quantity=3, Rating=3 },
            new ProductViewModel{Id= 3, Name="Puma Bondi", Description="track shoes", Price= 799, SalePrice=549, Category="Shoes", Color="Orange", Size="43", Brand="Puma", OnSale=true, Quantity=5, Rating=3 },
            new ProductViewModel{Id= 4, Name="Craft Triumph", Description="track shoes", Price= 499, SalePrice=349, Category="Shoes", Color="Yellow", Size="44", Brand="Craft", OnSale=true, Quantity=2, Rating=1 },
        };

        public static async Task<ProductViewModel> ReadSingleProductAsync(int id)
        {
            await Task.Delay(800);
            return _products.FirstOrDefault(x => x.Id == id);
        }
    }
}
