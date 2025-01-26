using BaristaCoffee.Dto.BaristaTypeDtos;

namespace BaristaCoffee.API.Repositories.BaristaTypeRepositories
{
    public interface IBaristaTypeRepository
    {
        Task<List<GetAllBaristaTypeDto>> GetAllBaristaTypeAsync();

        Task<GetByIdBaristaTypeDto> GetBaristaTypeByIdAsync(int id);

        Task CreateBaristaTypeAsync(CreateBaristaTypeDto createBaristaTypeDto);

        Task UpdateBaristaTypeAsync(UpdateBaristaTypeDto updateBaristaTypeDto);

        Task DeleteBaristaTypeAsync(int id);
    }
}
