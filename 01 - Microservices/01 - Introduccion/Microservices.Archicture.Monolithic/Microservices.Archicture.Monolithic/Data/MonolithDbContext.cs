using Microservices.Architecture.Monolithic.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Microservices.Architecture.Monolithic.Data
{

    public class MonolithDbContext : DbContext
    {
        public MonolithDbContext(DbContextOptions<MonolithDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
    }
}
