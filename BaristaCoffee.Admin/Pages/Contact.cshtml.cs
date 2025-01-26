using BaristaCoffee.Admin.Services.Interfaces;
using BaristaCoffee.Dto.ContactDtos;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BaristaCoffee.Admin.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IContactService _contactService;

        public required List<GetAllContactDto> Contacts { get; set; }

        public ContactModel(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task OnGetAsync()
        {
           Contacts = await _contactService.GetAllContactAsync();
        }
    }
}
