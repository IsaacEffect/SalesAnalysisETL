namespace SalesAnalysisETL.Domain.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public int DataSourceID { get; set; } = 1;

        public Customer Customer { get; set; } = null!;
        public DataSource DataSource { get; set; } = null!;
        public List<OrderDetail> OrderDetails { get; set; } = new();
    }
}
