using Microservices.Architecture.Monolithic.Data;
using Microservices.Architecture.Monolithic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Architecture.Monolithic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController(MonolithDbContext db) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Order>> Create(Order order)
        {
            var product = await db.Products.FindAsync(order.ProductId);
            if (product == null)
                return NotFound($"Product with ID {order.ProductId} not found.");

            if (order.Quantity < 0)
                return NotFound($"Product with Quantity {order.Quantity} not permitted.");

            order.Product = product;
            order.TotalPrice = product.Price * order.Quantity;
            
            db.Orders.Add(order);
            await db.SaveChangesAsync();
            return CreatedAtAction(nameof(Create), new { id = order.Id }, order);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get() =>
            await db.Orders.Include(o=>o.Product).ToListAsync();
    }
}
