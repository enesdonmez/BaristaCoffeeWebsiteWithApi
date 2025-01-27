using BaristaCoffee.Admin.Services.Interfaces;
using BaristaCoffee.Dto.AboutDtos;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BaristaCoffee.Admin.Pages
{
    public class AboutModel : PageModel
    {
        private readonly IAboutService _aboutService;

        public required List<GetAboutDto> AboutList { get; set; }

        public AboutModel(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task OnGetAsync()
        {
            AboutList = await _aboutService.GetAboutListAsync();
        }
    }
}
