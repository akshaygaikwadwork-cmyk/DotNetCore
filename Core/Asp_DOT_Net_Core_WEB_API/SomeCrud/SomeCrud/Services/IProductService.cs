using SomeCrud.Models;

namespace SomeCrud.Services;

public interface IProductService
{
    Task<List<ProductModel>> getProductList();
    Task<int> AddProduct(ProductModel model);
    Task<ProductModel> getProductById(int id);
    Task<int> UpdateProduct(ProductModel model);
    Task<int> deleteProductById(int id);
}