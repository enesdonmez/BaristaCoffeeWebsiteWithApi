using BaristaCoffee.Dto.BaristaDtos;

namespace BaristaCoffee.Web.Services.Interfaces
{
    public interface IBaristaService
    {
        Task<List<GetAllBaristaDto>> GetAllBaristaAsync();
    }
}
