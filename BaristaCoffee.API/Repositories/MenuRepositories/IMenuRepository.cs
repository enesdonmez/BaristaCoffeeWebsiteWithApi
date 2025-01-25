using BaristaCoffee.Dto.MenuDtos;

namespace BaristaCoffee.API.Repositories.MenuRepositories
{
    public interface IMenuRepository
    {
        Task<List<GetAllMenuDto>> GetAllMenuAsync();

        Task CreateMenuItem(CreateMenuItemDto createMenuItemDto);
    }
}
