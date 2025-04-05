using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace Microservices.GraphQL.Orders.Service.Client
{
    public class ProductApiClient
    {
        private readonly GraphQLHttpClient _client;

        public ProductApiClient(string graphqlEndpoint)
        {
            _client = new GraphQLHttpClient(graphqlEndpoint, new SystemTextJsonSerializer());
        }

        public async Task<ProductDto?> GetProductByIdAsync(int productId)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                query($id: Int!) {
                  productById(id: $id) {
                    id
                    name
                    price
                  }
                }",
                Variables = new { id = productId }
            };

            var response = await _client.SendQueryAsync<ProductByIdResponse>(query);
            return response.Data?.ProductById;
        }
    }
}
