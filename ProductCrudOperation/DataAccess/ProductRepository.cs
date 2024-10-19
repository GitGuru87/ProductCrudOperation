using Dapper;
using Microsoft.Data.SqlClient;
using ProductCrudOperation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductCrudOperation.DataAccess
{
    public class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            using var connection = new SqlConnection(_connectionString);
            var products = await connection.QueryAsync<Product>("SELECT * FROM Products");
            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Product>("SELECT * FROM Products WHERE Id = @Id", new { Id = id });
        }

        public async Task<int> AddProduct(Product product)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "INSERT INTO Products (Name, Description, Price, CreatedDate) VALUES (@Name, @Description, @Price, GETDATE())";
            return await connection.ExecuteAsync(sql, product);
        }

        public async Task<int> UpdateProduct(Product product)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "UPDATE Products SET Name = @Name, Description = @Description, Price = @Price WHERE Id = @Id";
            return await connection.ExecuteAsync(sql, product);
        }

        public async Task<int> DeleteProduct(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "DELETE FROM Products WHERE Id = @Id";
            return await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
