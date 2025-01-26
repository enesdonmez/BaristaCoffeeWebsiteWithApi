using BaristaCoffee.Dto.AboutDtos;
using BaristaCoffee.Admin.Services.Interfaces;
using Newtonsoft.Json;

namespace BaristaCoffee.Admin.Services.Concretes
{
    public class AboutService : IAboutService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<GetAboutDto>> GetAboutListAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessageAbout = await client.GetAsync("https://localhost:7066/api/About/GetAbout");

            if (responseMessageAbout.IsSuccessStatusCode)
            {
                var jsonDataAbout = await responseMessageAbout.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<GetAboutDto>>(jsonDataAbout)!;
            }

            return new List<GetAboutDto>();

        }
    }
}
