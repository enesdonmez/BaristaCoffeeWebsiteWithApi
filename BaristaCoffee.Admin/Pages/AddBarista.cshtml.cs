using BaristaCoffee.Admin.Services.Interfaces;
using BaristaCoffee.Dto.BaristaDtos;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BaristaCoffee.Admin.Pages
{
    public class AddBaristaModel : PageModel
    {
        private readonly IBaristaService _baristaService;

        public AddBaristaModel(IBaristaService baristaService)
        {
            _baristaService = baristaService;
        }

        public void OnGet()
        {
        }

        public async Task OnPostAsync(CreateBaristaDto createBaristaDto)
        {
            await _baristaService.CreateBaristaAsync(createBaristaDto);
        }
    }
}
