using BaristaCoffee.API.Repositories.BaristaRepositories;
using BaristaCoffee.Dto.BaristaDtos;
using Microsoft.AspNetCore.Mvc;

namespace BaristaCoffee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaristaController : ControllerBase
    {
        private readonly IBaristaRepository _baristaRepository;

        public BaristaController(IBaristaRepository baristaRepository)
        {
            _baristaRepository = baristaRepository;
        }

        [HttpGet("GetAllBarista")]
        public async Task<IActionResult> GetAllBarista()
        {
            var barista = await _baristaRepository.GetAllBaristaAsync();
            return Ok(barista);
        }

        [HttpPost("CreateBarista")]
        public async Task<IActionResult> CreateBarista(CreateBaristaDto createBaristaDto)
        {
            await _baristaRepository.CreateBarista(createBaristaDto);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
