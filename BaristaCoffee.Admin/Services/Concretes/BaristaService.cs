using BaristaCoffee.Dto.BaristaDtos;
using BaristaCoffee.Admin.Services.Interfaces;
using Newtonsoft.Json;

namespace BaristaCoffee.Admin.Services.Concretes
{
    public class BaristaService : IBaristaService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaristaService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<GetAllBaristaDto>> GetAllBaristaAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7066/api/Barista/GetAllBarista");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<GetAllBaristaDto>>(jsonData);
            }

            return new List<GetAllBaristaDto>();
        }
    }
}
