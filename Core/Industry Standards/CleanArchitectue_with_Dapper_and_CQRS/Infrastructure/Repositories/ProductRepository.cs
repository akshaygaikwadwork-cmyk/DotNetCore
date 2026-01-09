using Core.Entities;
using Core.I_Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Product>(
                    "SELECT * FROM Products WHERE Id = @Id", new { Id = id });
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Product>("SELECT * FROM Products");
            }
        }

        public async Task AddAsync(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO Products (Name, Price, StockQuantity, Description) VALUES (@Name, @Price, @StockQuantity, @Description)";
                await connection.ExecuteAsync(sql, product);
            }
        }

        public async Task UpdateAsync(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var Data = await connection.QueryFirstOrDefaultAsync<Product>("SELECT * FROM Products WHERE Id = @Id", new { Id = product.Id });
                if (Data != null)
                {
                    Data.Name = string.IsNullOrEmpty(product.Name) || product.Name == Data.Name ? Data.Name : product.Name;
                    Data.Price = product.Price <= 0 || product.Price == Data.Price ? Data.Price : product.Price;
                    Data.StockQuantity = product.StockQuantity <= 0 || product.StockQuantity == Data.StockQuantity ? Data.StockQuantity : product.StockQuantity;
                    Data.Description = string.IsNullOrEmpty(product.Description) || product.Description == Data.Description ? Data.Description : product.Description;
                    var sql = "UPDATE Products SET Name = @Name, Price = @Price, StockQuantity = @StockQuantity, Description = @Description  WHERE Id = @Id";
                    await connection.ExecuteAsync(sql, Data);
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "DELETE FROM Products WHERE Id = @Id";
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }
    }
}
