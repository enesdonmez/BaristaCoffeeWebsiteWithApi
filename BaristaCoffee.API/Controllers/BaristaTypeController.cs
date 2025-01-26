using Microsoft.AspNetCore.Mvc;
using BaristaCoffee.API.Repositories.BaristaTypeRepositories;
using BaristaCoffee.Dto.BaristaTypeDtos;


namespace BaristaCoffee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaristaTypeController : ControllerBase
    {
        private readonly IBaristaTypeRepository _baristaTypeRepository;

        public BaristaTypeController(IBaristaTypeRepository baristaTypeRepository)
        {
            _baristaTypeRepository = baristaTypeRepository;
        }

        [HttpGet("GetAllBaristaTypes")]
        public async Task<IActionResult> GetAllBaristaTypes()
        {
            var baristaTypes = await _baristaTypeRepository.GetAllBaristaTypeAsync();
            return Ok(baristaTypes);
        }

        [HttpPost("CreateBaristaType")]
        public async Task<IActionResult> CreateBaristaType(CreateBaristaTypeDto createBaristaTypeDto)
        {
            await _baristaTypeRepository.CreateBaristaTypeAsync(createBaristaTypeDto);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
