using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.API.Controllers;
using WebShop.API.Models.ViewModels;
using WebShop.API.Models.ViewModels.Product;
using WebShop.API.Services;
using WebShop.Tests.UnitTests.Fixtures;
using Xunit;

namespace WebShop.Tests.UnitTests.Controllers
{
    public class ProductsController_Should
    {
        [Fact]
        public async Task GetProduct_OnSuccess_Return_Product()
        {
            // Arrange
            var id = 2;
            var mockProductService = new Mock<IProductService>();
            var mockMapper = new Mock<IMapper>();
            mockProductService.Setup(s => s.ReadSingleProductAsync(id))
                .ReturnsAsync(await ProductFixtures.ReadSingleProductAsync(id));

            var sut = new ProductsController(mockProductService.Object, mockMapper.Object);

            // Act
            var actionResult = await sut.GetProduct(id);
            var result = actionResult.Result as OkObjectResult;

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>();
            result.Value.Should().BeOfType<ProductViewModel>();
        }

        [Fact]
        public async Task Create_OnSuccess_Return_StatusCode200()
        {
            // Arrange
            CreateProduct model = new CreateProduct
            {
                Name = "Nike",
                Description = "Snabba skor",
                Price = 300,
                SalePrice = 200,
                Category = "Shoes",
                Size = "43",
                BrandId = 3,
                OnSale = true,
                Quantity = 1,
                Rating = 5,
            };

            var mockProductService = new Mock<IProductService>();
            var mockMapper = new Mock<IMapper>();
            mockProductService.Setup(s => s.CreateProductAsync(model));

            var sut = new ProductsController(mockProductService.Object, mockMapper.Object);

            // Act
            var result = (OkResult)await sut.Create(model);

            // Assert
            result.Should().NotBeOfType<BadRequestResult>();
            result.Should().BeOfType<OkResult>();
        }

        [Fact]
        public async Task Filtered_Should_Return_Ok()
        {
            var productServiceMock = new Mock<IProductService>();
            var imapperMock = new Mock<IMapper>();
            var sut = new ProductsController(productServiceMock.Object, imapperMock.Object);
            var result = await sut.GetFilterData();
            result.Should().BeOfType<OkObjectResult>();
        }
    }
}
