using BaristaCoffee.API.Repositories.MenuCategoryRepositories;
using BaristaCoffee.Dto.MenuCategoryDtos;
using Microsoft.AspNetCore.Mvc;

namespace BaristaCoffee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuCategoryController : ControllerBase
    {
        private readonly IMenuCategoryRepository _menuCategoryRepository;

        public MenuCategoryController(IMenuCategoryRepository menuCategoryRepository)
        {
            _menuCategoryRepository = menuCategoryRepository;
        }

        [HttpGet("GetAllMenuCategory")]
        public async Task<IActionResult> GetAllMenuCategory()
        {
            var menuCategories = await _menuCategoryRepository.GetAllMenuCategoryAsync();
            return Ok(menuCategories);
        }

        [HttpPost("CreateMenuCategory")]
        public async Task<IActionResult> CreateMenuCategory(CreateMenuCategoryDto menuCategory)
        {
            await _menuCategoryRepository.CreateMenuCategoryAsync(menuCategory);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("UpdateMenuCategory")]
        public async Task<IActionResult> UpdateMenuCategory(UpdateMenuCategoryDto menuCategory)
        {
            await _menuCategoryRepository.UpdateMenuCategoryAsync(menuCategory);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete("DeleteMenuCategory/{id}")]
        public async Task<IActionResult> DeleteMenuCategory(int id)
        {
            await _menuCategoryRepository.DeleteMenuCategoryAsync(id);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet("GetMenuCategoryById/{id}")]
        public async Task<IActionResult> GetMenuCategoryById(int id)
        {
            var menuCategory = await _menuCategoryRepository.GetMenuCategoryByIdAsync(id);
            return Ok(menuCategory);
        }
    }
}
