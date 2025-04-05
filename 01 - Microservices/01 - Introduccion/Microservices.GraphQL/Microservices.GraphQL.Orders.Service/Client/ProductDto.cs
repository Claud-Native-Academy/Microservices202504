namespace Microservices.GraphQL.Orders.Service.Client
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public double Price { get; set; }
    }

}
