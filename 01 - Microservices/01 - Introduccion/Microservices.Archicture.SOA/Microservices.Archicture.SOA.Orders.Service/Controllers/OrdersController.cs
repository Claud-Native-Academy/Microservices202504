using Microservices.Archicture.SOA.Orders.Service.Client;
using Microservices.Archicture.SOA.Orders.Service.Data;
using Microservices.Archicture.SOA.Orders.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Microservices.Archicture.SOA.Orders.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController(OrdersDbContext db, ProductApiClient products) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get() =>
            await db.Orders.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Order>> Create(Order order)
        {
            var product = await products.GetProductById(order.ProductId);
            if (product == null)
                return BadRequest($"Product with ID {order.ProductId} not found.");

            order.TotalPrice = product.Price * order.Quantity;

            db.Orders.Add(order);
            await db.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), new { id = order.Id }, order);
        }
    }
}
