using BaristaCoffee.Dto.AboutDtos;

namespace BaristaCoffee.Web.Services.Interfaces
{
    public interface IAboutService
    {
        Task<List<GetAboutDto>> GetAboutListAsync();
    }
}
