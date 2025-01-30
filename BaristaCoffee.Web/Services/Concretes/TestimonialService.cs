using BaristaCoffee.Dto.TestimonialDtos;
using BaristaCoffee.Web.Services.Interfaces;

namespace BaristaCoffee.Web.Services.Concretes
{
    public class TestimonialService : ITestimonialService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<GetAllTestimonialDto>> GetAllTestimonialsAsync()
        {
           var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7066/api/testimonial/GetAllTestimonial");
            if (response.IsSuccessStatusCode)
            {
                var testimonials = await response.Content.ReadFromJsonAsync<List<GetAllTestimonialDto>>();
                return testimonials!;
            }

            return new List<GetAllTestimonialDto>();
        }
    }
}
