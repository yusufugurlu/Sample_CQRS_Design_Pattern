using Application.SampleCQRS.Handlers;
using Application.SampleCQRS.Queries;
using Core.SampleCQRS.Entities;
using Core.SampleCQRS.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.SampleCQRS.UnitTests.QueryTests
{
    public class ProductQueryHandlerTests
    {
        [Fact]
        public async Task GetProductById_Should_Return_Product()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Test Product", Price = 100m };
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(u => u.Products.GetByIdAsync(1)).ReturnsAsync(product);
            var handler = new ProductQueryHandler(unitOfWorkMock.Object);
            var query = new GetProductByIdQuery { Id = 1 };

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.Equal(product, result);
        }
    }
}
