using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.API.Models.ViewModels.Product;
using WebShop.API.Services;
using WebShop.Tests.UnitTests.Fixtures;
using Xunit;

namespace WebShop.Tests.UnitTests.Services
{
    public class ProductService_Should
    {
        [Fact]
        public async Task ReadSingleProductAsync_Returns_Product()
        {
            // Arrange
            var id = 2;
            var sut = new Mock<IProductService>();
            sut.Setup(s => s.ReadSingleProductAsync(id))
                .ReturnsAsync(await ProductFixtures.ReadSingleProductAsync(id));

            // Act
            var result = await sut.Object.ReadSingleProductAsync(id);

            // Assert
            result.Should().BeOfType<ProductViewModel>();
            result.Id.Should().Be(id);
        }
    }
}
