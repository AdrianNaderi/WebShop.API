using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.API.Data;
using WebShop.API.Models.Entities;
using WebShop.API.Models.ViewModels;
using WebShop.API.Models.ViewModels.Product;
using WebShop.API.Services;
using WebShop.Tests.UnitTests.Fixtures;
using Xunit;

namespace WebShop.Tests.UnitTests.Services
{
    public class ProductService_Filter_Should
    {
        private CategoryEntity Shoes;
        private CategoryEntity Jackets;

        
        
        [Theory]
        [InlineData("Shoes", 3)]
        [InlineData("Hats", 1)]
        [InlineData("Jacket", 0)]

        public async Task GetFilteredProductsAsync_Should_Return_CorrectFilteredData(string category, int expectedCount)
        {
            //Arrange
            var mapper = new Mock<IMapper>();
            var dbOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "temp_db").Options;
            var fixtures = new ProductFilterFixtures();

            
            using (var context = new AppDbContext(dbOptions))
            {
                context.Database.EnsureDeleted();
                context.Add(fixtures.Shoes);
                context.Add(fixtures.Hats);
                context.Add(fixtures.Jackets);
                context.Add(fixtures.Medium);
                context.Add(fixtures.Bexim);
                context.Add(fixtures.Product_One);
                context.Add(fixtures.Product_Two);
                context.Add(fixtures.Product_Three);
                context.Add(fixtures.Product_Four);
                await context.SaveChangesAsync();
            }

            var result = new List<ProductEntity>();

            //Act
            using (var context = new AppDbContext(dbOptions))
            {
                var productService = new ProductService(context, mapper.Object);
                var filter = new Filter() { Category = category };
                result = (List<ProductEntity>)await productService.GetFilteredProductsAsync(filter);
            }
            //Assert
            result.Count.Should().Be(expectedCount);
        }

        [Theory]
        [InlineData("Bexim", 4)]
        [InlineData("Nike", 0)]

        public async Task GetFilteredProductsAsync_Should_Return_CorrectFilteredDataByBrand(string brand, int expectedCount)
        {
            //Arrange
            var mapper = new Mock<IMapper>();
            var dbOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "temp_db").Options;
            var fixtures = new ProductFilterFixtures();

            
            using (var context = new AppDbContext(dbOptions))
            {
                context.Database.EnsureDeleted();
                context.Add(fixtures.Shoes);
                context.Add(fixtures.Hats);
                context.Add(fixtures.Jackets);
                context.Add(fixtures.Medium);
                context.Add(fixtures.Bexim);
                context.Add(fixtures.Product_One);
                context.Add(fixtures.Product_Two);
                context.Add(fixtures.Product_Three);
                context.Add(fixtures.Product_Four);
                await context.SaveChangesAsync();
            }

            var result = new List<ProductEntity>();

            //Act
            using (var context = new AppDbContext(dbOptions))
            {
                var productService = new ProductService(context, mapper.Object);
                var filter = new Filter() { Brand = brand };
                result = (List<ProductEntity>)await productService.GetFilteredProductsAsync(filter);
            }
            //Assert
            result.Count.Should().Be(expectedCount);
        }


    }
}
