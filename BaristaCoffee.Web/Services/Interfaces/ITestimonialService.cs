using BaristaCoffee.Dto.TestimonialDtos;

namespace BaristaCoffee.Web.Services.Interfaces
{
    public interface ITestimonialService
    {
        Task<List<GetAllTestimonialDto>> GetAllTestimonialsAsync();
    }
}
