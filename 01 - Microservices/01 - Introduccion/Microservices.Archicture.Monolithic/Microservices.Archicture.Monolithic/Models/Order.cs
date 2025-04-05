namespace Microservices.Architecture.Monolithic.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public Product? Product { get; set; }
    }
}
