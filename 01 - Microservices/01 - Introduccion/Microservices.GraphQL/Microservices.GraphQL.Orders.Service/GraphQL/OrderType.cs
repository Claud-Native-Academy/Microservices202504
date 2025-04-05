using Microservices.GraphQL.Orders.Service.Models;

namespace Microservices.GraphQL.Orders.Service.GraphQL
{
    [ObjectType<Order>]
    public static partial class OrderType
    {
        static partial void Configure(IObjectTypeDescriptor<Order> descriptor)
        {
            descriptor.Ignore(x => x.ProductId);
        }

        public static Product GetProduct([Parent] Order order)
            => new(order.ProductId);
    }

    public sealed record Product(int Id);
}
