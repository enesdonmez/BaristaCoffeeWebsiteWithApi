using BaristaCoffee.Dto.ContactDtos;

namespace BaristaCoffee.API.Repositories.ContactRepositories
{
    public interface IContactRepository
    {
        Task CreateContactAsync(CreateContactDto createContactDto);
    }
}
