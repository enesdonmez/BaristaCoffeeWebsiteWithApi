using BaristaCoffee.Dto.ContactDtos;
using BaristaCoffee.Web.Services.Interfaces;
using System.Net;

namespace BaristaCoffee.Web.Services.Concretes
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
    }
}
