using SomeCrud.Models;
using SomeCrud.Repositories;

namespace SomeCrud.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductModel>> getProductList()
    {
        return await _productRepository.getProductList();
    }

    public async Task<int> AddProduct(ProductModel model)
    {
        return await _productRepository.AddProduct(model);
    }

    public async Task<ProductModel> getProductById(int id)
    {
        return await _productRepository.getProductById(id);
    }

    public async Task<int> UpdateProduct(ProductModel model)
    {
        return await _productRepository.UpdateProduct(model);
    }

    public async Task<int> deleteProductById(int id)
    {
        return await _productRepository.deleteProductById(id);
    }
}