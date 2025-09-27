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

            // -------------------------
            // Customers Pipeline
            // -------------------------
            var customerExtractor = new CsvExtractor<Customer>(cols => new Customer
            {
                CustomerID = int.Parse(cols[0]),
                FirstName = cols[1].Trim(),
                LastName = cols[2].Trim(),
                Email = cols[3].Trim(),
                Phone = cols[4].Trim(),
                City = cols[5].Trim(),
                Country = cols[6].Trim()
            });
            var customerPipeline = new Pipeline<Customer>(
                customerExtractor,
                new CustomerTransformer(),
                new DataLoader<Customer>(connectionString, (conn, c) => CustomerRepository.Insert(conn, c))
            );
            customerPipeline.Ejecutar("customers.csv");

            // -------------------------
            // Products Pipeline
            // -------------------------
            var productExtractor = new CsvExtractor<Product>(cols => new Product
            {
                ProductID = int.Parse(cols[0]),
                ProductName = cols[1].Trim(),
                Category = cols[2].Trim(),
                Price = decimal.Parse(cols[3]),
                Stock = int.Parse(cols[4])
            });
            var productPipeline = new Pipeline<Product>(
                productExtractor,
                new DataTransformer<Product>(),
                new DataLoader<Product>(connectionString, (conn, p) => ProductRepository.Insert(conn, p))
            );
            productPipeline.Ejecutar("products.csv");

            // -------------------------
            // Orders Pipeline
            // -------------------------
            var orderExtractor = new CsvExtractor<Order>(cols => new Order
            {
                OrderID = int.Parse(cols[0]),
                CustomerID = int.Parse(cols[1]),
                OrderDate = DateTime.Parse(cols[2]),
                Status = cols[3].Trim(),
                DataSourceID = 1
            });
            var orderPipeline = new Pipeline<Order>(
                orderExtractor,
                new OrderTransformer(connectionString),
                new DataLoader<Order>(connectionString, (conn, o) => OrderRepository.Insert(conn, o))
            );
            orderPipeline.Ejecutar("orders.csv");

            // -------------------------
            // OrderDetails Pipeline
            // -------------------------
            var orderDetailExtractor = new CsvExtractor<OrderDetail>(cols => new OrderDetail
            {
                OrderID = int.Parse(cols[0]),
                ProductID = int.Parse(cols[1]),
                Quantity = int.Parse(cols[2]),
                Price = decimal.Parse(cols[3])
            });
            var orderDetailPipeline = new Pipeline<OrderDetail>(
                orderDetailExtractor,
                new OrderDetailTransformer(connectionString),
                new DataLoader<OrderDetail>(connectionString, (conn, od) => OrderDetailRepository.Insert(conn, od))
            );
            orderDetailPipeline.Ejecutar("order_details.csv");

            Console.WriteLine("ETL completado satisfactoriamente.");
        }
    }
}
