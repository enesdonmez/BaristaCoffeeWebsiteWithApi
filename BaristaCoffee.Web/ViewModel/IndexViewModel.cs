using BaristaCoffee.Dto.AboutDtos;
using BaristaCoffee.Dto.BaristaDtos;
using BaristaCoffee.Dto.ContactDtos;
using BaristaCoffee.Dto.MenuDtos;
using BaristaCoffee.Dto.TestimonialDtos;

namespace BaristaCoffee.Web.ViewModel
{
    public class IndexViewModel
    {
        public List<GetAboutDto> About { get; set; } = default!;

        public List<GetAllMenuDto> Menu { get; set; } = default!;

        public List<GetAllTestimonialDto> Testimonial { get; set; } = default!;

        public List<GetAllBaristaDto> Barista { get; set; } = default!;

        public CreateContactDto Contact { get; set; } = default!;
    }
}
