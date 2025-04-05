using Microservices.Architecture.Monolithic.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<MonolithDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MonolithConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MonolithDbContext>();
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

app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();

app.Run();
