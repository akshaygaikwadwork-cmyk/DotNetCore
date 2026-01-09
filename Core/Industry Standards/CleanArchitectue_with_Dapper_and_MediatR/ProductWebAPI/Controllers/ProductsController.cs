using Application.Requests;
using Core.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ProductWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _mediator.Send(new ProductServiceRequest
            {
                Operation = ProductServiceOperation.GetAll
            });
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDto productDto)
        {
            if (productDto.Id <= 0)
            {
                ProductServiceRequest result = new ProductServiceRequest();
                await _mediator.Send(new ProductServiceRequest
                {
                    ProductDto = productDto,
                    Operation = ProductServiceOperation.Add
                });
                if (result.resultCount > 0)
                {
                    return Ok("Data Inserted Successfully!!!");
                }
                else
                {
                    return BadRequest("Something went wrong");
                }
            }
            else
            {
                return BadRequest("Don't Pass Id");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id is mandatory");
            }
            else
            {
                var product = await _mediator.Send(new ProductServiceRequest
                {
                    Id = id,
                    Operation = ProductServiceOperation.GetById
                });
                return Ok(product);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductDto productDto)
        {
            if (productDto.Id <= 0)
            {
                return BadRequest("Id is mandatory");
            }
            else
            {
                ProductServiceRequest result = new ProductServiceRequest();
                await _mediator.Send(new ProductServiceRequest
                {
                    ProductDto = productDto,
                    Operation = ProductServiceOperation.Update
                });
                if (result.resultCount > 0)
                {
                    return Ok("Product Updated Successfully!!!");
                }
                else
                {
                    return BadRequest("Something went wrong");
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id is mandatory");
            }
            else
            {
                ProductServiceRequest result = new ProductServiceRequest();
                await _mediator.Send(new ProductServiceRequest
                {
                    Id = id,
                    Operation = ProductServiceOperation.Delete
                });
                if (result.resultCount > 0)
                {
                    return Ok("Product Deleted Successfully!!!");
                }
                else
                {
                    return BadRequest("Something went wrong");
                }
            }
        }
    }
}
