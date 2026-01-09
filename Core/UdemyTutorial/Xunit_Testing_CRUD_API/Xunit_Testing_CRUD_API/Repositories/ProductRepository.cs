using Xunit_Testing_CRUD_API.Models;

namespace Xunit_Testing_CRUD_API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public ProductRepository()
        {
            // Hardcoded product list
            _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 50000 },
            new Product { Id = 2, Name = "Mouse", Price = 1500 },
            new Product { Id = 3, Name = "Keyboard", Price = 2500 }
        };
        }
        public IEnumerable<Product> GetAll() => _products;

        public Product GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            product.Id = _products.Count + 1; // Auto-increment ID
            _products.Add(product);
        }

        public void Update(int id, Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            var existing = _products.FirstOrDefault(p => p.Id == id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
            }
        }

        public bool Delete(int id)
        {
            if (id <= 0) throw new ArgumentException("Invalid ID");

            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
                return true;
            }
            return false;
        }
    }

}
