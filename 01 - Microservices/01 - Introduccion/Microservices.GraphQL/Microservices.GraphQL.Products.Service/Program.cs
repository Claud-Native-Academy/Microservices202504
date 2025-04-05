using Microservices.GraphQL.Products.Service.Data;
using Microservices.GraphQL.Products.Service.GraphQL;
using Microservices.GraphQL.Products.Service.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContext<ProductsDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ProductsConnection")))
    .AddGraphQLServer()
    .AddTypes()
    .AddProjections()
    .AddFiltering()
    .AddSorting();


//builder.Services
//    .AddDbContext<ProductsDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ProductsConnection")))
//    .AddGraphQLServer()
//    .AddApolloFederation(FederationVersion.Federation20)
//    .AddQueryType(d => d.Name("Query"))
//    .AddType<ProductQueries>()    
//    .AddType<CategoryQueries>()
//    .AddProjections()
//    .AddFiltering()
//    .AddSorting();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ProductsDbContext>();

    db.Database.Migrate();

    if (!db.Products.Any())
    {
        var electronics = new Category { Id = 1, Name = "Electronics" };
        var peripherals = new Category { Id = 2, Name = "Peripherals" };     

        db.Categories.AddRange(electronics, peripherals);

        db.Products.AddRange(
            new Product { Id = 1, Name = "Laptop", Price = 1200, CategoryId = electronics.Id },
            new Product { Id = 2, Name = "Phone", Price = 800, CategoryId = electronics.Id },
            new Product { Id = 3, Name = "Tablet", Price = 600, CategoryId = electronics.Id },
            new Product { Id = 4, Name = "Monitor", Price = 300, CategoryId = peripherals.Id },
            new Product { Id = 5, Name = "Keyboard", Price = 100, CategoryId = peripherals.Id }
        );
        db.SaveChanges();
    }
}

app.MapGraphQL();
//app.Run();
app.RunWithGraphQLCommands(args);