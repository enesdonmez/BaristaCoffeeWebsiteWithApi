using BaristaCoffee.Dto.ContactDtos;

namespace BaristaCoffee.Admin.Services.Interfaces
{
    public interface IContactService
    {
        Task CreateContact(CreateContactDto createContactDto);

        Task<List<GetAllContactDto>> GetAllContactAsync();
    }
}
