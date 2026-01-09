using Application.Commands;
using Application.DTOs;
using Application.Handlers.CommandsHandlers;
using Application.Handlers.QueriesHandlers;
using Application.Queries;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AddProductCommandHandler _addProductHandler;
        private readonly UpdateProductCommandHandler _updateProductHandler;
        private readonly DeleteProductCommandHandler _deleteProductHandler;
        private readonly GetProductByIdQueryHandler _getProductByIdHandler;
        private readonly GetAllProductsQueryHandler _getAllProductsHandler;

        public ProductController(
            AddProductCommandHandler addProductHandler,
            UpdateProductCommandHandler updateProductHandler,
            DeleteProductCommandHandler deleteProductHandler,
            GetProductByIdQueryHandler getProductByIdHandler,
            GetAllProductsQueryHandler getAllProductsHandler)
        {
            _addProductHandler = addProductHandler;
            _updateProductHandler = updateProductHandler;
            _deleteProductHandler = deleteProductHandler;
            _getProductByIdHandler = getProductByIdHandler;
            _getAllProductsHandler = getAllProductsHandler;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _getAllProductsHandler.Handle(new GetAllProductsQuery());
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto productDto)
        {
            if(productDto.Id <= 0)
            {
                var product = new Product
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    StockQuantity = productDto.StockQuantity,
                    Description = productDto.Description
                };
                await _addProductHandler.Handle(new AddProductCommand { Product = product });

                return Ok("Data Inserted Successfully!!!");

            }
            else
            {
                return BadRequest("Don't Pass Id");
            }
            
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _getProductByIdHandler.Handle(new GetProductByIdQuery { Id = id });
            return Ok(product);
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductDto productDto)
        {
            var product = new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Price = productDto.Price,
                StockQuantity = productDto.StockQuantity,
                Description = productDto.Description
            };
            await _updateProductHandler.Handle(new UpdateProductCommand { Product = product });

            return Ok("Data Updated Successfully!!!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteProductHandler.Handle(new DeleteProductCommand { Id = id });
            return Ok("Data Deleted Successfully!!!");
        }
    }
}
