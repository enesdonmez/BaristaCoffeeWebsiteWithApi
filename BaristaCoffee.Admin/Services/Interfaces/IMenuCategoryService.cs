using BaristaCoffee.Dto.MenuCategoryDtos;

namespace BaristaCoffee.Admin.Services.Interfaces
{
    public interface IMenuCategoryService
    {
        Task<List<GetAllMenuCategoryDto>> GetAllMenuCategoryAsync();

        Task CreateMenuCategoryAsync(CreateMenuCategoryDto createMenuCategoryDto);
    }
}
