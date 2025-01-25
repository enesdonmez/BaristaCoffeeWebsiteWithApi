using BaristaCoffee.Dto.TestimonialDtos;

namespace BaristaCoffee.API.Repositories.TestimonialRepositories
{
    public interface ITestimonialRepository
    {
        Task<List<GetAllTestimonialDto>> GetAllTestimonialAsync();

        Task CreateTestimonial(CreateTestimonialDto createTestimonialDto);
    }
}
