using Microservices.Archicture.SOA.Orders.Service.Dtos;

namespace Microservices.Archicture.SOA.Orders.Service.Client
{

    public class ProductApiClient(HttpClient http)
    {
        private readonly HttpClient _http = http;

        public async Task<ProductDto?> GetProductById(int id)
        {
            try
            {
                return await _http.GetFromJsonAsync<ProductDto>($"api/products/{id}");
            }
            catch
            {
                return null;
            }
        }
    }

}
