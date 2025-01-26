using BaristaCoffee.Dto.TestimonialDtos;

namespace BaristaCoffee.Admin.Services.Interfaces
{
    public interface ITestimonialService
    {
        Task<List<GetAllTestimonialDto>> GetAllTestimonialsAsync();
    }
}
