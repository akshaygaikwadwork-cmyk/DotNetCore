using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit_Testing_CRUD_API.Controllers;
using Xunit_Testing_CRUD_API.DTOs;
using Xunit_Testing_CRUD_API.Models;
using Xunit_Testing_CRUD_API.Repositories;

namespace SecureCrudApi.Tests.ProductTests
{
    public class UpdateProductTests
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly ProductsController _controller;

        public UpdateProductTests()
        {
            _mockRepo = new Mock<IProductRepository>();
            _controller = new ProductsController(_mockRepo.Object);
        }

        [Fact]
        public void Update_ShouldReturn_BadRequest_IfIdIsZeroOrNegative()
        {
            // Arrange
            var product = new ProductDTO { Name = "Laptop Pro", Price = 70000 };

            // Act
            var resultZero = _controller.Update(0, product);
            var resultNegative = _controller.Update(-5, product);

            // Assert
            resultZero.Should().BeOfType<BadRequestObjectResult>();
            resultNegative.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void Update_ShouldReturn_NotFound_IfProductDoesNotExist()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetById(99)).Returns((Product?)null);
            var product = new ProductDTO { Name = "Laptop Pro", Price = 70000 };

            // Act
            var result = _controller.Update(99, product);

            // Assert
            result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Fact]
        public void Update_ShouldCallRepository_AndReturn_NoContent()
        {
            // Arrange
            var existingProduct = new Product { Id = 1, Name = "Laptop", Price = 50000 };
            _mockRepo.Setup(repo => repo.GetById(1)).Returns(existingProduct);
            var updatedProduct = new ProductDTO { Name = "Laptop Pro", Price = 70000 };

            // Act
            var result = _controller.Update(1, updatedProduct);

            // Assert
            result.Should().BeOfType<NoContentResult>();
            existingProduct.Name.Should().Be("Laptop Pro");
            existingProduct.Price.Should().Be(70000);
        }
    }
}
