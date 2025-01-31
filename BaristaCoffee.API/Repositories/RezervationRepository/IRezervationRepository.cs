using BaristaCoffee.Dto.RezervationDtos;

namespace BaristaCoffee.API.Repositories.RezervationRepository
{
    public interface IRezervationRepository
    {
        Task<List<GetAllRezervationDto>> GetAllRezervationAsync();
        Task<GetByIdRezervationDto> GetRezervationByIdAsync(int id);
        Task CreateRezervationAsync(CreateRezervationDto createRezervationDto);
        Task UpdateRezervationAsync(UpdateRezervationDto updateRezervationDto);
        Task DeleteRezervationAsync(int id);
    }
}
