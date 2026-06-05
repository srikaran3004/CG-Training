namespace ProducerAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public int Quantity { get; set; }
    }
}