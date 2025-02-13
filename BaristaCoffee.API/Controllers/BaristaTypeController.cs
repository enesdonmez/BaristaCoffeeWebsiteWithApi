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

        [HttpPut("UpdateBaristaType")]
        public async Task<IActionResult> UpdateBaristaType(UpdateBaristaTypeDto updateBaristaTypeDto)
        {
            await _baristaTypeRepository.UpdateBaristaTypeAsync(updateBaristaTypeDto);
            return Ok();
        }

        [HttpDelete("DeleteBaristaType/{id}")]
        public async Task<IActionResult> DeleteBaristaType(int id)
        {
            await _baristaTypeRepository.DeleteBaristaTypeAsync(id);
            return Ok();
        }

        [HttpGet("GetBaristaTypeById/{id}")]
        public async Task<IActionResult> GetBaristaTypeById(int id)
        {
            var baristaType = await _baristaTypeRepository.GetBaristaTypeByIdAsync(id);
            return Ok(baristaType);
        }
    }
}
