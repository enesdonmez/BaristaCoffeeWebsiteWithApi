using BaristaCoffee.Dto.AboutDtos;

namespace BaristaCoffee.API.Repositories.AboutRepositories
{
    public interface IAboutRepository
    {
        Task<List<GetAboutDto>> GetAbout();
    }
}
