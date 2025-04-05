using Microservices.Archicture.SOA.Products.Service.Data;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ProductsDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ProductsConnection")));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ProductsDbContext>();
    db.Database.EnsureCreated();
    if (!db.Products.Any())
    {
        db.Products.AddRange(
            new() { Name = "Laptop", Price = 1200 },
            new() { Name = "Mouse", Price = 25 },
            new() { Name = "Keyboard", Price = 50 },
            new() { Name = "Monitor", Price = 300 },
            new() { Name = "Headphones", Price = 100 }
        );
        db.SaveChanges();
    }
}

app.UseCors("AllowAll");
app.MapControllers();
app.Run();
