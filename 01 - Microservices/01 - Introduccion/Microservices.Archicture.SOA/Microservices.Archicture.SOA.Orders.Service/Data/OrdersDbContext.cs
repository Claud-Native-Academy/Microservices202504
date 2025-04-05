using Microservices.Archicture.SOA.Orders.Service.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Microservices.Archicture.SOA.Orders.Service.Data
{
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options) { }
        public DbSet<Order> Orders => Set<Order>();
    }
}
