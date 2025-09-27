using Microsoft.Data.SqlClient;
using SalesAnalysisETL.Domain.Entities;

namespace SalesAnalysisETL.Persistence.Repositories
{
    public class OrderDetailRepository
    {
        public static void Insert(SqlConnection connection, OrderDetail od)
        {
            var query = @"INSERT INTO OrderDetails (OrderID, ProductID, Quantity, Price)
                          VALUES (@OrderID, @ProductID, @Quantity, @Price)";
            using var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@OrderID", od.OrderID);
            cmd.Parameters.AddWithValue("@ProductID", od.ProductID);
            cmd.Parameters.AddWithValue("@Quantity", od.Quantity);
            cmd.Parameters.AddWithValue("@Price", od.Price);
            cmd.ExecuteNonQuery();
        }
    }
}
