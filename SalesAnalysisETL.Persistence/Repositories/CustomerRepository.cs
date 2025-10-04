using Microsoft.Data.SqlClient;
using SalesAnalysisETL.Domain.Entities;

namespace SalesAnalysisETL.Persistence.Repositories
{
    public class CustomerRepository
    {
        public static void Insert(SqlConnection connection, Customer c)
        {
            using var cmd = new SqlCommand("InsertCustomerCompat", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CustomerID", c.CustomerID);
            cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
            cmd.Parameters.AddWithValue("@LastName", c.LastName);
            cmd.Parameters.AddWithValue("@Email", c.Email);
            cmd.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(c.Phone) ? (object)DBNull.Value : c.Phone);
            cmd.Parameters.AddWithValue("@City", string.IsNullOrEmpty(c.City) ? (object)DBNull.Value : c.City);
            cmd.Parameters.AddWithValue("@Country", string.IsNullOrEmpty(c.Country) ? (object)DBNull.Value : c.Country);

            cmd.ExecuteNonQuery();
        }
    }
}
