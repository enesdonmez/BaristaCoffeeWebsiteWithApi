using BaristaCoffee.API.Repositories.MenuRepositories;
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
    }
}
