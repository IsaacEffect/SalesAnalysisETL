using SalesAnalysisETL.Application.Services;
using SalesAnalysisETL.Domain.Entities;
using SalesAnalysisETL.Persistence.Repositories;

namespace SalesAnalysisETL.ConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            string connectionString = "Server=DESKTOP-2BRQA3M;Database=AnalisisVentasDB;Trusted_Connection=True;TrustServerCertificate=True;";

            var clienteRepo = new ClienteRepository();
            var productoRepo = new ProductoRepository();
            var ventaRepo = new VentaRepository();

            // -------------------------
            // Pipeline Clientes
            // -------------------------
            var clienteExtractor = new CsvExtractor<Cliente>(cols => new Cliente
            {
                Nombre = cols[0].Trim(),
                Email = cols[1].Trim(),
                Region = cols[2].Trim()
            });


            var clienteTransformador = new DataTransformer<Cliente>();
            var clienteLoader = new DataLoader<Cliente>(
                connectionString,
                (conn, c) => clienteRepo.Insert(conn, c)
            );

            var clientePipeline = new Pipeline<Cliente>(clienteExtractor, clienteTransformador, clienteLoader);
            clientePipeline.Ejecutar("clientes.csv");


            // -------------------------
            // Pipeline Productos
            // -------------------------
            var productoExtractor = new CsvExtractor<Producto>(cols => new Producto
            {
                Nombre = cols[0].Trim(),
                Categoria = cols[1].Trim(),
                Precio = decimal.Parse(cols[2])
            });

            var productoTransformador = new DataTransformer<Producto>();
            var productoLoader = new DataLoader<Producto>(
                connectionString,
                (conn, p) => productoRepo.Insert(conn, p)
            );

            var productoPipeline = new Pipeline<Producto>(productoExtractor, productoTransformador, productoLoader);
            productoPipeline.Ejecutar("productos.csv");


            // -------------------------
            // Pipeline Ventas
            // -------------------------
            var ventaExtractor = new CsvExtractor<Venta>(cols => new Venta
            {
                IdCliente = int.Parse(cols[0]),
                IdProducto = int.Parse(cols[1]),
                Cantidad = int.Parse(cols[2]),
                Precio = decimal.Parse(cols[3]),
                Fecha = DateTime.Parse(cols[4]),
                IdFuente = int.Parse(cols[5])
            });


            var ventaTransformador = new VentaTransformer();
            var ventaLoader = new DataLoader<Venta>(
                connectionString,
                (conn, v) => ventaRepo.Insert(conn, v)
            );

            var ventaPipeline = new Pipeline<Venta>(ventaExtractor, ventaTransformador, ventaLoader);
            ventaPipeline.Ejecutar("ventas.csv");

            Console.WriteLine("ETL completado con éxito.");
        }
    }
}
