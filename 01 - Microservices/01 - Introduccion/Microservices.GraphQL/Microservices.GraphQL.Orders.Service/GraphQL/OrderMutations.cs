using Microservices.GraphQL.Orders.Service.Client;
using Microservices.GraphQL.Orders.Service.Data;
using Microservices.GraphQL.Orders.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservices.GraphQL.Orders.Service.GraphQL
{
    [MutationType]
    public class OrderMutations
    {
        public async Task<Order> CreateOrderAsync(
            int productId,
            int quantity,
            [Service] OrdersDbContext db,
            [Service] ProductApiClient productApiClient)
        {
            var product = await productApiClient.GetProductByIdAsync(productId);

            if (product == null)
            {
                throw new GraphQLException(ErrorBuilder.New()
                    .SetMessage("Producto no encontrado.")
                    .SetCode("PRODUCT_NOT_FOUND")
                .Build());
            }

            var nextId = await db.Orders.AnyAsync() ? await db.Orders.MaxAsync(o => o.Id) + 1 : 1;

            var order = new Order
            {
                Id = nextId,
                ProductId = productId,
                Quantity = quantity,
                TotalPrice = product.Price * quantity,
                Status = "Created"
            };

            db.Orders.Add(order);

            await db.SaveChangesAsync();

            return order;
        }

        public async Task<Order?> UpdateOrderAsync(
            int orderId,
            int productId,
            int quantity,
            [Service] OrdersDbContext db,
            [Service] ProductApiClient productApi)
        {
            var order = await db.Orders.FindAsync(orderId);
            if (order == null)
                throw new GraphQLException("Order not found");

            var product = await productApi.GetProductByIdAsync(productId);

            if (product == null)
            {
                throw new GraphQLException(ErrorBuilder.New()
                    .SetMessage("Producto no encontrado.")
                    .SetCode("PRODUCT_NOT_FOUND")
                .Build());
            }

            order.ProductId = productId;
            order.Quantity = quantity;
            order.TotalPrice = quantity * product.Price;
            order.Status = "Updated";

            await db.SaveChangesAsync();
            return order;
        }

        public async Task<bool> DeleteOrderAsync(int orderId, [Service] OrdersDbContext db)
        {
            var order = await db.Orders.FindAsync(orderId);
            if (order == null)
                return false;

            db.Orders.Remove(order);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
