using Microservices.gRPC.Products.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<ProductsServiceImpl>();

app.Run();
