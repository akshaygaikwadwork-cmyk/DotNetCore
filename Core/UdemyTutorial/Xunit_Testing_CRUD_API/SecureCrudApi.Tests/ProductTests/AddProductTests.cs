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
    public class AddProductTests
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly ProductsController _controller;

        public AddProductTests()
        {
            _mockRepo = new Mock<IProductRepository>(); // Mock repository
            _controller = new ProductsController(_mockRepo.Object); // Inject mock
        }

        [Fact]
        public void Add_ShouldReturn_BadRequest_IfProductIsNull()
        {
            // Act
            var result = _controller.Add(null);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void Add_ShouldReturn_BadRequest_IfProductHasInvalidData()
        {
            // Arrange
            var product = new ProductDTO { Name = "", Price = -100 };

            // Act
            var result = _controller.Add(product);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void Add_ShouldCallRepository_Once()
        {
            // Arrange
            var product = new ProductDTO { Name = "Laptop", Price = 50000 };

            _mockRepo.Setup(repo => repo.Add(It.IsAny<Product>()))
                     .Callback<Product>(p => { /* Simulating method call */ });

            // Act
            _controller.Add(product);

            // Assert
            _mockRepo.Verify(repo => repo.Add(It.IsAny<Product>()), Times.Once);
        }
    }
}
