using Grpc.Core;
using Microservices.gRPC.Products.Service.Protos;
using static Microservices.gRPC.Products.Service.Protos.ProductsService;

namespace Microservices.gRPC.Products.Service.Services
{
    public class ProductsServiceImpl : ProductsServiceBase
    {
        private readonly Dictionary<string, ProductResponse> _products = new()
        {
            { "1", new ProductResponse { ProductId = "1", Name = "Laptop", Stock = 10, Price = 999.99 } },
            { "2", new ProductResponse { ProductId = "2", Name = "Mouse", Stock = 25, Price = 19.99 } },
            { "3", new ProductResponse { ProductId = "3", Name = "Keyboard", Stock = 15, Price = 49.99 } }
        };

        public override Task<ProductResponse> GetProduct(ProductRequest request, ServerCallContext context)
        {
            if (_products.TryGetValue(request.ProductId, out var product))
            {
                return Task.FromResult(product);
            }

            throw new RpcException(new Status(StatusCode.NotFound, "Product not found"));
        }
    }
}
