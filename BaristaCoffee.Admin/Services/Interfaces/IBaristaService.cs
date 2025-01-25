using BaristaCoffee.Dto.BaristaDtos;

namespace BaristaCoffee.Admin.Services.Interfaces
{
    public interface IBaristaService
    {
        Task<List<GetAllBaristaDto>> GetAllBaristaAsync();
    }
}
