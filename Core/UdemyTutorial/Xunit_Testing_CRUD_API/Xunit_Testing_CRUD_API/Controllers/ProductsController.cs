using Microsoft.AspNetCore.Mvc;
using Xunit_Testing_CRUD_API.DTOs;
using Xunit_Testing_CRUD_API.Models;
using Xunit_Testing_CRUD_API.Repositories;

namespace Xunit_Testing_CRUD_API.Controllers
{
    [Route("api/products")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            var products = _repository.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid product ID."); // Handle negative/zero ID cases

            var product = _repository.GetById(id);

            if (product == null)
                return NotFound($"Product with ID {id} not found."); // More descriptive response

            return Ok(product);
        }
        [HttpPost]
        public ActionResult Add([FromBody] ProductDTO? productDTO)
        {
            if (string.IsNullOrWhiteSpace(productDTO?.Name) || productDTO.Price <= 0)
                return BadRequest("Invalid product details.");

            var newProduct = new Product { Name = productDTO.Name, Price = productDTO.Price };
            _repository.Add(newProduct);
            return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] ProductDTO productDTO)
        {
            var existing = _repository.GetById(id);
            if (existing == null) return NotFound();

            existing.Name = productDTO.Name;
            existing.Price = productDTO.Price;
            _repository.Update(id, existing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            // Attempt to delete and validate result
            if (!_repository.Delete(id)) return NotFound();

            return NoContent();
        }

    }
}
