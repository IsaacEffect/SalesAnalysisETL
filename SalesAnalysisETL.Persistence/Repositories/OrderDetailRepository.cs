using Microsoft.Data.SqlClient;
using SalesAnalysisETL.Domain.Entities;

namespace SalesAnalysisETL.Persistence.Repositories
{
    public class OrderDetailRepository
    {
        public static void Insert(SqlConnection connection, OrderDetail od)
        {
            using var cmd = new SqlCommand("InsertOrderDetailCompat", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OrderID", od.OrderID);
            cmd.Parameters.AddWithValue("@ProductID", od.ProductID);
            cmd.Parameters.AddWithValue("@Quantity", od.Quantity);
            cmd.Parameters.AddWithValue("@Price", od.Price);

            cmd.ExecuteNonQuery();
        }
    }
}
