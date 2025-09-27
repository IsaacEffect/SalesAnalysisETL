using Microsoft.Data.SqlClient;
using SalesAnalysisETL.Domain.Entities;

namespace SalesAnalysisETL.Persistence.Repositories
{
    public class CustomerRepository
    {
        public static void Insert(SqlConnection connection, Customer c)
        {
            var query = @"INSERT INTO Customers (CustomerID, FirstName, LastName, Email, Phone, City, Country)
                          VALUES (@CustomerID, @FirstName, @LastName, @Email, @Phone, @City, @Country)";
            using var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CustomerID", c.CustomerID);
            cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
            cmd.Parameters.AddWithValue("@LastName", c.LastName);
            cmd.Parameters.AddWithValue("@Email", c.Email);
            cmd.Parameters.AddWithValue("@Phone", c.Phone ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@City", c.City ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Country", c.Country ?? (object)DBNull.Value);
            cmd.ExecuteNonQuery();
        }
    }
}
