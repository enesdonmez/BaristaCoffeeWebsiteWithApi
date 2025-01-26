using BaristaCoffee.Dto.BaristaDtos;

namespace BaristaCoffee.API.Repositories.BaristaRepositories
{
    public interface IBaristaRepository
    {
        Task<List<GetAllBaristaDto>> GetAllBaristaAsync();

        Task CreateBaristaAsync(CreateBaristaDto createBaristaDto);

        Task DeleteBaristaAsync(int id);

        Task UpdateBaristaAsync(UpdateBaristaDto updateBaristaDto);

    }
}
