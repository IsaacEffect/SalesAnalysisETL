using Microsoft.Data.SqlClient;
using SalesAnalysisETL.Domain.Entities;

namespace SalesAnalysisETL.Persistence.Repositories
{
    public class VentaRepository
    {

        public void Insert(SqlConnection connection, Venta venta)
        {
            var query = @"INSERT INTO Ventas (IdCliente, IdProducto, Cantidad, Precio, Fecha, IdFuente)
                  VALUES (@IdCliente, @IdProducto, @Cantidad, @Precio, @Fecha, @IdFuente)";
            using (var cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@IdCliente", venta.IdCliente);
                cmd.Parameters.AddWithValue("@IdProducto", venta.IdProducto);
                cmd.Parameters.AddWithValue("@Cantidad", venta.Cantidad);
                cmd.Parameters.AddWithValue("@Precio", venta.Precio);
                cmd.Parameters.AddWithValue("@Fecha", venta.Fecha);

                cmd.Parameters.AddWithValue("@IdFuente", 1); // <- valor fijo
                cmd.ExecuteNonQuery();
            }
        }


    }
}
