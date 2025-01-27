using BaristaCoffee.Admin.Services.Interfaces;
using BaristaCoffee.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BaristaCoffee.Admin.Pages
{
    public class TestimonialModel : PageModel
    {
        private readonly ITestimonialService _testimonialService;

        public required List<GetAllTestimonialDto> TestimonialList { get; set; }

        public TestimonialModel(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task OnGetAsync()
        {
           TestimonialList = await _testimonialService.GetAllTestimonialsAsync();
        }
    }
}
