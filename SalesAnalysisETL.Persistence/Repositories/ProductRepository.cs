using Microsoft.Data.SqlClient;
using SalesAnalysisETL.Domain.Entities;

namespace SalesAnalysisETL.Persistence.Repositories
{
    public class ProductRepository
    {
        public static void Insert(SqlConnection connection, Product p)
        {
            var query = @"INSERT INTO Products (ProductID, ProductName, Category, Price, Stock)
                          VALUES (@ProductID, @ProductName, @Category, @Price, @Stock)";
            using var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ProductID", p.ProductID);
            cmd.Parameters.AddWithValue("@ProductName", p.ProductName);
            cmd.Parameters.AddWithValue("@Category", p.Category ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Price", p.Price);
            cmd.Parameters.AddWithValue("@Stock", p.Stock);
            cmd.ExecuteNonQuery();
        }
    }
}
