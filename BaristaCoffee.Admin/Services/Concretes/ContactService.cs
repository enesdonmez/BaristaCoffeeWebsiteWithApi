using BaristaCoffee.Dto.ContactDtos;
using System.Net;
using BaristaCoffee.Admin.Services.Interfaces;
using BaristaCoffee.Dto.BaristaDtos;
using Newtonsoft.Json;

namespace BaristaCoffee.Admin.Services.Concretes
{
    public class ContactService : IContactService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task CreateContact(CreateContactDto createContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7066/api/contact/CreateContact", createContactDto);
            if (response.StatusCode == HttpStatusCode.Created)
            {
               
            }

        }

        public async Task<List<GetAllContactDto>> GetAllContactAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7066/api/Contact/GetAllContact");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<GetAllContactDto>>(result)!;
            }

            return new List<GetAllContactDto>();
        }
    }
}
