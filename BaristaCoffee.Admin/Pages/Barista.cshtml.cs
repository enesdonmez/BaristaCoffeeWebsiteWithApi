using BaristaCoffee.Admin.Services.Interfaces;
using BaristaCoffee.Dto.BaristaDtos;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BaristaCoffee.Admin.Pages
{
    public class BaristaModel : PageModel
    {
        private readonly IBaristaService _baristaService;
        public required List<GetAllBaristaDto> Baristas { get; set; }

        public BaristaModel(IBaristaService baristaService)
        {
            _baristaService = baristaService;
        }

        public async Task OnGet()
        {
           Baristas = await _baristaService.GetAllBaristaAsync();
        }
    }
}   
