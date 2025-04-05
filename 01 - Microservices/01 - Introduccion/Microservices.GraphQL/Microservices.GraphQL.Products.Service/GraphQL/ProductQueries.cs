using HotChocolate;
using Microservices.GraphQL.Products.Service.Data;
using Microservices.GraphQL.Products.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservices.GraphQL.Products.Service.GraphQL
{
    [QueryType]
    public class ProductQueries
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Product> GetProducts([Service] ProductsDbContext db) =>
            db.Products;

        [UseProjection]        
        public Product GetProductById(int id, [Service] ProductsDbContext db) =>
            db.Products.Include(p=>p.Category).FirstOrDefault(p => p.Id == id);
    }
}
