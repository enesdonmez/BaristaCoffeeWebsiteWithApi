using BaristaCoffee.API.Dtos.BaristaDtos;

namespace BaristaCoffee.API.Repositories.BaristaRepositories
{
    public interface IBaristaRepository
    {
        Task<List<GetAllBaristaDto>> GetAllBaristaAsync();
    }
}
