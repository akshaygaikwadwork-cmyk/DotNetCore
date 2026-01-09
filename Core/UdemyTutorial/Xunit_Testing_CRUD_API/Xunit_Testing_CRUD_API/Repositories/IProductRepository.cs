using Xunit_Testing_CRUD_API.Models;

namespace Xunit_Testing_CRUD_API.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        void Add(Product product);
        void Update(int id, Product product);
        bool Delete(int id);

    }
}
