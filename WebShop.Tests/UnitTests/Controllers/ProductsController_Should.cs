using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.API.Controllers;
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
    }
}
