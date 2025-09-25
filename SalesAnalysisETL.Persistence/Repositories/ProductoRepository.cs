using Microsoft.Data.SqlClient;
using SalesAnalysisETL.Domain.Entities;

namespace SalesAnalysisETL.Persistence.Repositories
{
    public class ProductoRepository
    {
        public void Insert(SqlConnection connection, Producto producto)
        {
            var query = "INSERT INTO Productos (Nombre, Categoria, Precio) VALUES (@Nombre, @Categoria, @Precio)";
            using (var cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@Categoria", producto.Categoria ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
