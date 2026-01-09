using Microsoft.AspNetCore.Mvc;
using SomeCrud.Models;
using SomeCrud.Services;

namespace SomeCrud.Controllers;
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    [HttpGet]
    [Route("ProductList")]
    public async Task<IActionResult> Index()
    {
        var productList = await _productService.getProductList();
        return Ok(productList);
    }

    [HttpPost]
    [Route("InsertProduct")]
    public async Task<IActionResult> InsertProduct(ProductModel model)
    {
        int result = await _productService.AddProduct(model);
        if (result > 0)
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpGet]
    [Route("EditTemplate")]
    public async Task<IActionResult> EditProduct(int Id)
    {
        var productById = await _productService.getProductById(Id);
        return Ok(productById);
    }
    
    [HttpPost]
    [Route("UpdateTemplate")]
    public async Task<IActionResult> UpdateProduct(ProductModel model)
    {
        int result = await _productService.UpdateProduct(model);
        if (result > 0)
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }
    
    [HttpDelete]
    [Route("DeleteTemplate")]
    public async Task<IActionResult> DeleteProduct(int Id)
    {
        int deleteProduct = await _productService.deleteProductById(Id);
        return Ok(deleteProduct);
    }

}