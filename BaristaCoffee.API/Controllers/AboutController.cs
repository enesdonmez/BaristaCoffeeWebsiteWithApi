using BaristaCoffee.API.Repositories.AboutRepositories;
using BaristaCoffee.Dto.AboutDtos;
using Microsoft.AspNetCore.Mvc;

namespace BaristaCoffee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutRepository _aboutRepository;
        public AboutController(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        [HttpGet("GetAllAbout")]
        public async Task<IActionResult> GetAbout(CancellationToken cancellationToken)
        {
            var about = await _aboutRepository.GetAboutAsync(cancellationToken);
            return Ok(about);
        }

        [HttpPost("CreateAbout")]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto, CancellationToken cancellationToken)
        {
            await _aboutRepository.CreateAboutAsync(createAboutDto ,cancellationToken);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("UpdateAbout")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto, CancellationToken cancellationToken)
        {
            await _aboutRepository.UpdateAboutAsync(updateAboutDto, cancellationToken);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
