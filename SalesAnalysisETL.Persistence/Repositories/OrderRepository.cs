using Microsoft.Data.SqlClient;
using SalesAnalysisETL.Domain.Entities;

namespace SalesAnalysisETL.Persistence.Repositories
{
    public class OrderRepository
    {

        public static void Insert(SqlConnection connection, Order o)
        {
            var query = @"INSERT INTO Orders (OrderID, CustomerID, OrderDate, Status, DataSourceID)
                          VALUES (@OrderID, @CustomerID, @OrderDate, @Status, @DataSourceID)";
            using var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@OrderID", o.OrderID);
            cmd.Parameters.AddWithValue("@CustomerID", o.CustomerID);
            cmd.Parameters.AddWithValue("@OrderDate", o.OrderDate);
            cmd.Parameters.AddWithValue("@Status", o.Status);
            cmd.Parameters.AddWithValue("@DataSourceID", o.DataSourceID);
            cmd.ExecuteNonQuery();
        }
    }
}
