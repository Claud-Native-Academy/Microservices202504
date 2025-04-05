using Microservices.GraphQL.Orders.Service.Client;
using Microservices.GraphQL.Orders.Service.Data;
using Microservices.GraphQL.Orders.Service.GraphQL;
using Microservices.GraphQL.Orders.Service.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(new ProductApiClient(builder.Configuration["ProductApi:GraphQLEndpoint"]));

builder.Services
    .AddDbContext<OrdersDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("OrdersConnection")))
    .AddGraphQLServer()
    .AddTypes()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

//builder.Services
//    .AddDbContext<OrdersDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("OrdersConnection")))
//    .AddGraphQLServer()    
//    .AddQueryType(d => d.Name("Query"))
//    .AddType<OrderQueries>()
//    .AddMutationType(d => d.Name("Mutation"))
//    .AddType<OrderMutations>()    
//    .AddProjections()
//    .AddFiltering()
//    .AddSorting();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<OrdersDbContext>();
    db.Database.Migrate();

    if (!db.Orders.Any())
    {
        db.Orders.AddRange(
            new Order { Id = 1, ProductId = 1, Quantity = 2, TotalPrice = 2400, Status = "Created" },
            new Order { Id = 2, ProductId = 2, Quantity = 1, TotalPrice = 800, Status = "Created" },
            new Order { Id = 3, ProductId = 3, Quantity = 3, TotalPrice = 1800, Status = "Created" }
        );
        db.SaveChanges();
    }
}

app.MapGraphQL();
//app.Run();
app.RunWithGraphQLCommands(args);