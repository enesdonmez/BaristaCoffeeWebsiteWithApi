using BaristaCoffee.Dto.AboutDtos;

namespace BaristaCoffee.Admin.Services.Interfaces
{
    public interface IAboutService
    {
        Task<List<GetAboutDto>> GetAboutListAsync();
    }
}
