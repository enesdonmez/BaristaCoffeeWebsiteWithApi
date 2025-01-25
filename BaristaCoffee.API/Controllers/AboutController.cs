using BaristaCoffee.API.Repositories.AboutRepositories;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("GetAbout")]
        public async Task<IActionResult> GetAbout()
        {
            var about = await _aboutRepository.GetAbout();
            return Ok(about);
        }
    }
}
