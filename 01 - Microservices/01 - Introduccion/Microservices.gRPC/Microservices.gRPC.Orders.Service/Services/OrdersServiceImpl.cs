using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using Microservices.gRPC.Orders.Service.Protos;
using Microservices.gRPC.Products.Service.Protos;
using static Microservices.gRPC.Products.Service.Protos.ProductsService;


namespace Microservices.gRPC.Orders.Service.Services
{
    public class OrdersServiceImpl : OrdersService.OrdersServiceBase
    {
        private readonly IConfiguration _config;
        private readonly ILogger<OrdersServiceImpl> _logger;
        private static readonly Dictionary<string, OrderResponse> _orders = new();

        public OrdersServiceImpl(IConfiguration config, ILogger<OrdersServiceImpl> logger)
        {
            _config = config;
            _logger = logger;
        }

        public override async Task<OrderResponse> CreateOrder(CreateOrderRequest request, ServerCallContext context)
        {
            using var channel = GrpcChannel.ForAddress(_config["Grpc:ProductsServiceUrl"]);
            var client = new ProductsService.ProductsServiceClient(channel);

            var product = await client.GetProductAsync(new ProductRequest { ProductId = request.ProductId });
            var total = product.Price * request.Quantity;

            var order = new OrderResponse
            {
                OrderId = Guid.NewGuid().ToString(),
                Status = "Created",
                ProductName = product.Name,
                TotalPrice = total
            };

            _orders[order.OrderId] = order;
            return order;
        }

        public override Task<OrderResponse> GetOrder(GetOrderRequest request, ServerCallContext context)
        {
            if (_orders.TryGetValue(request.OrderId, out var order))
            {
                return Task.FromResult(order);
            }
            throw new RpcException(new Status(StatusCode.NotFound, "Order not found"));
        }

        public override Task<ListOrdersResponse> ListOrders(EmptyRequest request, ServerCallContext context)
        {
            var response = new ListOrdersResponse();
            response.Orders.AddRange(_orders.Values);
            return Task.FromResult(response);
        }

        public override async Task<OrderResponse> UpdateOrder(UpdateOrderRequest request, ServerCallContext context)
        {
            if (!_orders.ContainsKey(request.OrderId))
                throw new RpcException(new Status(StatusCode.NotFound, "Order not found"));
                        
            using var channel = GrpcChannel.ForAddress(_config["Grpc:ProductsServiceUrl"]);
            var client = new ProductsServiceClient(channel);
            var product = await client.GetProductAsync(new ProductRequest { ProductId = request.ProductId });
                        
            var total = product.Price * request.Quantity;

            var updatedOrder = new OrderResponse
            {
                OrderId = request.OrderId,
                Status = "Updated",
                ProductName = product.Name,
                TotalPrice = total
            };

            _orders[request.OrderId] = updatedOrder;

            return updatedOrder;
        }


        public override Task<DeleteOrderResponse> DeleteOrder(DeleteOrderRequest request, ServerCallContext context)
        {
            var success = _orders.Remove(request.OrderId);

            var response = new DeleteOrderResponse
            {
                Status = success ? "Deleted" : "NotFound"
            };

            return Task.FromResult(response);
        }
    }
}
