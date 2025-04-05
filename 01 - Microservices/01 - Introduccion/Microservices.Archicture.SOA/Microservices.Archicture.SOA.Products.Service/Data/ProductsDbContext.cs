using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microservices.Archicture.SOA.Products.Service;
using Microservices.Archicture.SOA.Products.Service.Models;

namespace Microservices.Archicture.SOA.Products.Service.Data
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options) { }
        public DbSet<Product> Products => Set<Product>();        
    }

}
