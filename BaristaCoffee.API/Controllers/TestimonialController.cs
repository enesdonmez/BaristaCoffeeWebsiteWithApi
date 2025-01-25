using BaristaCoffee.API.Repositories.TestimonialRepositories;
using BaristaCoffee.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaristaCoffee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController(ITestimonialRepository _testimonialRepository) : ControllerBase
    {
        [HttpGet("GetAllTestimonial")]
        public async Task<IActionResult> GetAllTestimonial()
        {
            var testimonials = await _testimonialRepository.GetAllTestimonialAsync();
            return Ok(testimonials);
        }

        [HttpPost("CreateTestimonial")]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            await _testimonialRepository.CreateTestimonial(createTestimonialDto);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
