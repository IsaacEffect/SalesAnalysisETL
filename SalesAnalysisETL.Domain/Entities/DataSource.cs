namespace SalesAnalysisETL.Domain.Entities
{
    public class DataSource
    {
        public int DataSourceID { get; set; }
        public string SourceType { get; set; } = string.Empty;
        public DateTime LoadDate { get; set; }
    }
}
