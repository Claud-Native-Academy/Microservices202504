using Microservices.Archicture.SOA.Orders.Service.Client;
using Microservices.Archicture.SOA.Orders.Service.Data;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<OrdersDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("OrdersConnection")));
builder.Services.AddHttpClient<ProductApiClient>(client =>{client.BaseAddress = new Uri(builder.Configuration["ProductApiUrl"]); });


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
    var db = scope.ServiceProvider.GetRequiredService<OrdersDbContext>();
    db.Database.EnsureCreated();
}

app.UseCors("AllowAll");
app.MapControllers();
app.Run();
