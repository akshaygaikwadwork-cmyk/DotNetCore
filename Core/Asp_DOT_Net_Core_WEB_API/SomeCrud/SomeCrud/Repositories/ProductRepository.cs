using Microsoft.EntityFrameworkCore;
using SomeCrud.Configurations;
using SomeCrud.Models;

namespace SomeCrud.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _dbContext;

    public ProductRepository(ProductDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProductModel>> getProductList()
    {
        return await _dbContext.tblProducts.ToListAsync();
    }

    public async Task<int> AddProduct(ProductModel model)
    {
        await _dbContext.tblProducts.AddAsync(model);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<ProductModel> getProductById(int id)
    {
        // return await _dbContext.tblProducts.Where(AkshayDonkey => AkshayDonkey.Id == id).FirstOrDefaultAsync();
        return await _dbContext.tblProducts.FindAsync(id);
    }

    public async Task<int> UpdateProduct(ProductModel model)
    {
        _dbContext.tblProducts.Update(model);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> deleteProductById(int id)
    {
        var akshayDeleted = _dbContext.tblProducts.Find(id);
        _dbContext.tblProducts.Remove(akshayDeleted);
       return await _dbContext.SaveChangesAsync();
    }
}