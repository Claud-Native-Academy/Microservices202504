
using Microservices.GraphQL.Products.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservices.GraphQL.Products.Service.Data
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options) { }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
    }

}
