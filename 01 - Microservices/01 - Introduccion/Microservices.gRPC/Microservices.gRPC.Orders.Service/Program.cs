using Microservices.gRPC.Orders.Service.Protos;
using Microservices.gRPC.Orders.Service.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
        });
});

// Add services to the container.
builder.Services.AddGrpc().AddJsonTranscoding();


var app = builder.Build();

app.UseGrpcWeb();
app.UseCors("AllowAll");
app.MapGrpcService<OrdersServiceImpl>().EnableGrpcWeb().RequireCors("AllowAll");

app.Run();
