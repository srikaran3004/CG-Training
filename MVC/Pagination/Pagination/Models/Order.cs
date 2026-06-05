namespace Pagination.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Product { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
