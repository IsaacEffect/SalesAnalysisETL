using Microsoft.Data.SqlClient;
using SalesAnalysisETL.Domain.Entities;

namespace SalesAnalysisETL.Persistence.Repositories
{
    public class DataSourceRepository
    {
        public static int Insert(SqlConnection connection, DataSource ds)
        {
            using var cmd = new SqlCommand("InsertDataSourceCompat", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SourceType", ds.SourceType);
            cmd.Parameters.AddWithValue("@LoadDate", ds.LoadDate);

            var newId = Convert.ToInt32(cmd.ExecuteScalar());
            return newId;
        }
    }
}
