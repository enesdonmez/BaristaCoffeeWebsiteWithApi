using BaristaCoffee.Dto.ContactDtos;
using BaristaCoffee.API.Repositories.ContactRepositories;
using Microsoft.AspNetCore.Mvc;

namespace BaristaCoffee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController(IContactRepository _contactRepository) : ControllerBase
    {
        
        [HttpPost("CreateContact")]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            await _contactRepository.CreateContactAsync(createContactDto);
            return Ok("eklendi.");
        }
    }
}
