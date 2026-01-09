using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositorys;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositorys
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        //From System.Data  - IDbConnection
        //From System.Data.SqlClient - SqlConnection
        private IDbConnection Connection => new SqlConnection(_connectionString);


        //Get Product By ID
        public async Task<Product> GetByIdAsync(int id)
        {
            using (var dbConnection = Connection)
            {
                var query = "SELECT * FROM Products WHERE Id = @Id";
                return await dbConnection.QueryFirstOrDefaultAsync<Product>(query, new { Id = id });
            }
        }

        //Get All Product Details
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            using (var dbConnection = Connection)
            {
                var query = "SELECT * FROM Products";
                return await dbConnection.QueryAsync<Product>(query);
            }
        }

        //Add Product 
        public async Task AddAsync(Product product)
        {
            using (var dbConnection = Connection)
            {
                var query = "INSERT INTO Products (Name, Price, StockQuantity, Description) VALUES (@Name, @Price, @StockQuantity, @Description)";
                await dbConnection.ExecuteAsync(query, product);
            }
        }

        //Update Product
        public async Task UpdateAsync(Product product)
        {
            using (var dbConnection = Connection)
            {
                var Data = await dbConnection.QueryFirstOrDefaultAsync<Product>("SELECT * FROM Products WHERE Id = @Id", new { Id = product.Id });
                if (Data != null)
                {
                    Data.Name = string.IsNullOrEmpty(product.Name) || product.Name == Data.Name ? Data.Name : product.Name;
                    Data.Price = product.Price <= 0 || product.Price == Data.Price ? Data.Price : product.Price;
                    Data.StockQuantity = product.StockQuantity < 0 || product.StockQuantity == Data.StockQuantity ? Data.StockQuantity : product.StockQuantity;
                    Data.Description = string.IsNullOrEmpty(product.Description) || product.Description == Data.Description ? Data.Description : product.Description;
                    var query = "UPDATE Products SET Name = @Name, Price = @Price, StockQuantity = @StockQuantity, Description = @Description WHERE Id = @Id";
                    await dbConnection.ExecuteAsync(query, product);
                }
            }
        }

        //Delete Product
        public async Task DeleteAsync(int id)
        {
            using (var dbConnection = Connection)
            {
                var query = "DELETE FROM Products WHERE Id = @Id";
                await dbConnection.ExecuteAsync(query, new { Id = id });
            }
        }

    }
}
