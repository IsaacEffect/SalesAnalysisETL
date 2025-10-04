using Microsoft.Data.SqlClient;
using SalesAnalysisETL.Domain.Entities;

namespace SalesAnalysisETL.Persistence.Repositories
{
    public class ProductRepository
    {
        public static void Insert(SqlConnection connection, Product p)
        {
            using var cmd = new SqlCommand("InsertProductCompat", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductID", p.ProductID);
            cmd.Parameters.AddWithValue("@ProductName", p.ProductName);
            cmd.Parameters.AddWithValue("@Category", string.IsNullOrEmpty(p.Category) ? (object)DBNull.Value : p.Category);
            cmd.Parameters.AddWithValue("@Price", p.Price);
            cmd.Parameters.AddWithValue("@Stock", p.Stock);

            cmd.ExecuteNonQuery();
        }
    }
}
