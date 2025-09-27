using SalesAnalysisETL.Application.Interfaces;
using SalesAnalysisETL.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace SalesAnalysisETL.Application.Services
{
    public class OrderTransformer : ITransformador<Order>
    {
        private readonly HashSet<int> _validCustomerIds;

        public OrderTransformer(string connectionString)
        {
            _validCustomerIds = new HashSet<int>();

            using var connection = new SqlConnection(connectionString);
            connection.Open();

            using var cmd = new SqlCommand("SELECT CustomerID FROM Customers", connection);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                _validCustomerIds.Add(reader.GetInt32(0));
            }
        }

        public IEnumerable<Order> Transformar(IEnumerable<Order> orders)
        {
            // Solo pasar pedidos con CustomerID válido
            return orders.Where(o => _validCustomerIds.Contains(o.CustomerID));
        }
    }
}
