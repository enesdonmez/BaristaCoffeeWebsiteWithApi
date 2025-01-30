using BaristaCoffee.Dto.MenuCategoryDtos;

namespace BaristaCoffee.API.Repositories.MenuCategoryRepositories
{
    public interface IMenuCategoryRepository
    {
        Task<List<GetAllMenuCategoryDto>> GetAllMenuCategoryAsync();
        Task<GetByIdMenuCategoryDto> GetMenuCategoryByIdAsync(int id);
        Task CreateMenuCategoryAsync(CreateMenuCategoryDto menuCategory);
        Task UpdateMenuCategoryAsync(UpdateMenuCategoryDto menuCategory);
        Task DeleteMenuCategoryAsync(int id);
    }
}
