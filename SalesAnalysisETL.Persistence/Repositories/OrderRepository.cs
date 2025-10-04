using Microsoft.Data.SqlClient;
using SalesAnalysisETL.Domain.Entities;

namespace SalesAnalysisETL.Persistence.Repositories
{
    public class OrderRepository
    {
        public static void Insert(SqlConnection connection, Order o)
        {
            using var cmd = new SqlCommand("InsertOrderCompat", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OrderID", o.OrderID);
            cmd.Parameters.AddWithValue("@CustomerID", o.CustomerID);
            cmd.Parameters.AddWithValue("@OrderDate", o.OrderDate);
            cmd.Parameters.AddWithValue("@Status", o.Status);
            // Como en tu CSV no tienes SourceType, puedes hardcodear por ahora:
            cmd.Parameters.AddWithValue("@DataSource", "CSV");

            cmd.ExecuteNonQuery();
        }
    }
}
