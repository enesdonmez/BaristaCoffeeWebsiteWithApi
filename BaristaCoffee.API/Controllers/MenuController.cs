using BaristaCoffee.API.Repositories.MenuRepositories;
using BaristaCoffee.Dto.MenuDtos;
using Microsoft.AspNetCore.Mvc;

namespace BaristaCoffee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController(IMenuRepository _menuRepository) : ControllerBase
    {
        [HttpGet("GetAllMenu")]
        public async Task<IActionResult> GetAllMenu()
        {
            var menu = await _menuRepository.GetAllMenuAsync();
            return Ok(menu);
        }

        [HttpPost("CreateMenuItem")]
        public async Task<IActionResult> CreateMenuItem(CreateMenuItemDto createMenuItemDto)
        {
            await _menuRepository.CreateMenuItemAsync(createMenuItemDto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("UpdateMenuItem")]
        public async Task<IActionResult> UpdateMenuItem(UpdateMenuDto updateMenuItemDto)
        {
            await _menuRepository.UpdateMenuItemAsync(updateMenuItemDto);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete("DeleteMenuItem/{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            await _menuRepository.DeleteMenuItemAsync(id);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet("GetMenuItemById/{id}")]
        public async Task<IActionResult> GetMenuItemById(int id)
        {
            var menuItem = await _menuRepository.GetMenuItemByIdAsync(id);
            return Ok(menuItem);
        }
    }
}
