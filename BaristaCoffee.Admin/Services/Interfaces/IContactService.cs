using BaristaCoffee.Dto.ContactDtos;

namespace BaristaCoffee.Web.Services.Interfaces
{
    public interface IContactService
    {
        Task CreateContact(CreateContactDto createContactDto);
    }
}
