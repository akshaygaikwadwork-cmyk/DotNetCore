using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit_Testing_CRUD_API.Controllers;
using Xunit_Testing_CRUD_API.Models;
using Xunit_Testing_CRUD_API.Repositories;

namespace SecureCrudApi.Tests.ProductTests
{
    public class GetProductByIdTests
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly ProductsController _controller;

        public GetProductByIdTests()
        {
            _mockRepo = new Mock<IProductRepository>();
            _controller = new ProductsController(_mockRepo.Object);
        }

        [Fact]
        public void GetById_ShouldReturn_BadRequest_IfIdIsZeroOrNegative()
        {
            // Act
            var resultZero = _controller.GetById(0);
            var resultNegative = _controller.GetById(-5);

            // Assert
            resultZero.Should().BeOfType<BadRequestObjectResult>();
            resultNegative.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void GetById_ShouldReturn_NotFound_IfProductDoesNotExist()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetById(99)).Returns((Product?)null);

            // Act
            var result = _controller.GetById(99);

            // Assert
            result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Fact]
        public void GetById_ShouldReturn_Product_IfExists()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Laptop", Price = 50000 };
            _mockRepo.Setup(repo => repo.GetById(1)).Returns(product);

            // Act
            var result = _controller.GetById(1);

            // Assert
            result.Should().NotBeNull();
            var returnedProduct = result.Value as Product;
            returnedProduct.Should().NotBeNull();
            returnedProduct.Name.Should().Be("Laptop");
        }
    }
}
