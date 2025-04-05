using HotChocolate;
using Microservices.GraphQL.Orders.Service.Data;
using Microservices.GraphQL.Orders.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservices.GraphQL.Orders.Service.GraphQL
{
    [QueryType]
    public class OrderQueries
    {        
        [UseFiltering]
        [UseSorting]
        public IQueryable<Order> GetOrders([Service] OrdersDbContext dbContext) =>
            dbContext.Orders;
    }
}
