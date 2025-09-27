using SalesAnalysisETL.Application.Interfaces;
using SalesAnalysisETL.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace SalesAnalysisETL.Application.Services
{
    public class OrderDetailTransformer : ITransformador<OrderDetail>
    {
        private readonly HashSet<int> _validOrderIds;
        private readonly HashSet<int> _validProductIds;

        public OrderDetailTransformer(string connectionString)
        {
            _validOrderIds = new HashSet<int>();
            _validProductIds = new HashSet<int>();

            using var connection = new SqlConnection(connectionString);
            connection.Open();

            // Cargar Orders validos
            using (var cmd = new SqlCommand("SELECT OrderID FROM Orders", connection))
            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                    _validOrderIds.Add(reader.GetInt32(0));

            // Cargar Products validos
            using (var cmd = new SqlCommand("SELECT ProductID FROM Products", connection))
            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                    _validProductIds.Add(reader.GetInt32(0));
        }

        public IEnumerable<OrderDetail> Transformar(IEnumerable<OrderDetail> orderDetails)
        {
            return orderDetails
                .Where(od => od.Quantity > 0 && od.Price > 0)
                .Where(od => _validOrderIds.Contains(od.OrderID))
                .Where(od => _validProductIds.Contains(od.ProductID));
        }
    }
}
