using Microsoft.Data.SqlClient;
using SalesAnalysisETL.Application.Interfaces;


namespace SalesAnalysisETL.Application.Services
{
    public class DataLoader<T> : ILoader<T>
    {
        private readonly string _connectionString;
        private readonly Action<SqlConnection, T> _insertFunc;

        public DataLoader(string connectionString, Action<SqlConnection, T> insertFunc)
        {
            _connectionString = connectionString;
            _insertFunc = insertFunc;
        }

        public void Cargar(IEnumerable<T> datos)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            foreach (var item in datos)
            {
                _insertFunc(connection, item);
            }
        }
    }
}
