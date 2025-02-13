using BaristaCoffee.Dto.AboutDtos;

namespace BaristaCoffee.API.Repositories.AboutRepositories
{
    public interface IAboutRepository
    {
        Task<List<GetAboutDto>> GetAboutAsync(CancellationToken cancellationToken);

        Task CreateAboutAsync (CreateAboutDto createAboutDto , CancellationToken cancellationToken);

        Task UpdateAboutAsync(UpdateAboutDto updateAboutDto, CancellationToken cancellationToken);

        Task DeleteAboutAsync(int id,CancellationToken cancellationToken);
    }
}
