using Microsoft.Data.SqlClient;
using SalesAnalysisETL.Domain.Entities;

namespace SalesAnalysisETL.Persistence.Repositories
{
    public class ClienteRepository
    {
        public void Insert(SqlConnection connection, Cliente cliente)
        {
            var query = "INSERT INTO Clientes (Nombre, Email, Region) VALUES (@Nombre, @Email, @Region)";
            using (var cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
                cmd.Parameters.AddWithValue("@Region", cliente.Region ?? (object)DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
