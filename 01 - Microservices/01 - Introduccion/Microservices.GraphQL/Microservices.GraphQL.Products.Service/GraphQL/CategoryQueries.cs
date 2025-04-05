using Microservices.GraphQL.Products.Service.Data;
using Microservices.GraphQL.Products.Service.Models;

namespace Microservices.GraphQL.Products.Service.GraphQL
{
    [QueryType]
    public class CategoryQueries
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Category> GetCategories([Service] ProductsDbContext context) =>
            context.Categories;
    }

}
