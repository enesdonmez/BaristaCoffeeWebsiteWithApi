using BaristaCoffee.Dto.MenuDtos;
using BaristaCoffee.Web.Services.Interfaces;
using Newtonsoft.Json;

namespace BaristaCoffee.Web.Services.Concretes
{
    public class MenuService : IMenuService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<GetAllMenuDto>> GetAllMenuAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessageMenu = await client.GetAsync("https://localhost:7066/api/Menu/GetAllMenu");
            if (responseMessageMenu.IsSuccessStatusCode)
            {
                var jsonDataMenu = await responseMessageMenu.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<GetAllMenuDto>>(jsonDataMenu)!;
            }

            return new List<GetAllMenuDto>();
        }
    }
}
