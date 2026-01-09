using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit_Testing_CRUD_API.Controllers;
using Xunit_Testing_CRUD_API.Models;
using Xunit_Testing_CRUD_API.Repositories;

namespace SecureCrudApi.Tests.ProductTests
{
    public class GetAllProductsTests
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly ProductsController _controller;

        public GetAllProductsTests()
        {
            _mockRepo = new Mock<IProductRepository>();
            _controller = new ProductsController(_mockRepo.Object);
        }

        [Fact]
        public void GetAll_ShouldReturn_EmptyList_IfNoProducts()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetAll()).Returns(new List<Product>());

            // Act
            var result = _controller.Get();

            // Assert
            var okResult = result;
            okResult.Should().NotBeNull();
            var products = okResult.Value as List<Product>;
            products.Should().BeEmpty();
        }

        [Fact]
        public void GetAll_ShouldReturn_ListOfProducts()
        {
            // Arrange
            var products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 50000 },
            new Product { Id = 2, Name = "Mouse", Price = 1500 }
        };
            _mockRepo.Setup(repo => repo.GetAll()).Returns(products);

            // Act
            var result = _controller.Get();

            // Assert
            var okResult = result;
            okResult.Should().NotBeNull();
            var returnedProducts = okResult.Value as List<Product>;
            returnedProducts.Should().NotBeNull().And.HaveCount(2);
        }
    }
}
