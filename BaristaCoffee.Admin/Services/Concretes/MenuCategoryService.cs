using BaristaCoffee.Admin.Services.Interfaces;
using BaristaCoffee.Dto.ContactDtos;
using BaristaCoffee.Dto.MenuCategoryDtos;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace BaristaCoffee.Admin.Services.Concretes
{
    public class MenuCategoryService : IMenuCategoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuCategoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task CreateMenuCategoryAsync(CreateMenuCategoryDto createMenuCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7066/api/MenuCategory/CreateMenuCategory", createMenuCategoryDto);
            if (response.StatusCode == HttpStatusCode.Created)
            {

            }
        }

        public async Task<List<GetAllMenuCategoryDto>> GetAllMenuCategoryAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7066/api/MenuCategory/GetAllMenuCategory");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<GetAllMenuCategoryDto>>(jsonData)!;
            }

            return new List<GetAllMenuCategoryDto>();
        }
    }
}
