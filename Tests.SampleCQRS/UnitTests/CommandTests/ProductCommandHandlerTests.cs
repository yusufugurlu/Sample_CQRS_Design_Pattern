using Application.SampleCQRS.Commands;
using Application.SampleCQRS.Handlers;
using Core.SampleCQRS.Entities;
using Core.SampleCQRS.Interfaces;
using Moq;

using System.Threading.Tasks;
using Xunit;

namespace Tests.SampleCQRS.UnitTests.CommandTests
{
    public class ProductCommandHandlerTests
    {
        [Fact]
        public async Task CreateProduct_Should_Call_Add_And_CompleteAsync()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var handler = new ProductCommandHandler(unitOfWorkMock.Object);
            var command = new CreateProductCommand { Name = "Test Product", Price = 100m };

            // Act
            await handler.Handle(command);

            // Assert
            unitOfWorkMock.Verify(u => u.Products.Add(It.IsAny<Product>()), Times.Once);
            unitOfWorkMock.Verify(u => u.CompleteAsync(), Times.Once);
        }
    }
}
