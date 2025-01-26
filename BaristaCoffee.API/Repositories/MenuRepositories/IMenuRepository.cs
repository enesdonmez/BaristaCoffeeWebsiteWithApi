using BaristaCoffee.Dto.MenuDtos;

namespace BaristaCoffee.API.Repositories.MenuRepositories
{
    public interface IMenuRepository
    {
        Task<List<GetAllMenuDto>> GetAllMenuAsync();

        Task CreateMenuItemAsync(CreateMenuItemDto createMenuItemDto);

        Task UpdateMenuItemAsync(UpdateMenuDto updateMenuItemDto);

        Task DeleteMenuItemAsync(int id);
    }
}
