namespace SalesAnalysisETL.Domain.Entities
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }


        public decimal TotalPrice => Quantity * Price;

        public Order Order { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
