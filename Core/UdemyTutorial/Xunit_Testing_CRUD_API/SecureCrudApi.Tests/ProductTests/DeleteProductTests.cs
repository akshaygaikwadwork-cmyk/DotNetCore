using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit_Testing_CRUD_API.Controllers;
using Xunit_Testing_CRUD_API.Repositories;

namespace SecureCrudApi.Tests.ProductTests
{
    public class DeleteProductTests
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly ProductsController _controller;

        public DeleteProductTests()
        {
            _mockRepo = new Mock<IProductRepository>();
            _controller = new ProductsController(_mockRepo.Object);
        }
        [Fact]
        public void Delete_ShouldReturn_BadRequest_IfIdIsZeroOrNegative()
        {
            // Act
            var resultZero = _controller.Delete(0);
            var resultNegative = _controller.Delete(-3);

            // Assert
            resultZero.Should().BeOfType<BadRequestObjectResult>();
            resultNegative.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void Delete_ShouldReturn_NotFound_IfProductDoesNotExist()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.Delete(99)).Returns(false);

            // Act
            var result = _controller.Delete(99);

            // Assert
            result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Fact]
        public void Delete_ShouldCallRepository_AndReturn_NoContent()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.Delete(1)).Returns(true);

            // Act
            var result = _controller.Delete(1);

            // Assert
            result.Should().BeOfType<NoContentResult>();
            _mockRepo.Verify(repo => repo.Delete(1), Times.Once);
        }
    }
}
