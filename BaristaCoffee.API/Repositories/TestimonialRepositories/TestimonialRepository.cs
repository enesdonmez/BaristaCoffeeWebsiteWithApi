using BaristaCoffee.Dto.TestimonialDtos;
using Dapper;
using System.Data;

namespace BaristaCoffee.API.Repositories.TestimonialRepositories
{
    public class TestimonialRepository(IDbConnection _dbConnection) : ITestimonialRepository
    {
        public async Task<List<GetAllTestimonialDto>> GetAllTestimonialAsync()
        {
            string sql = "SELECT * FROM Testimonial";
            var result = await _dbConnection.QueryAsync<GetAllTestimonialDto>(sql);
            return result.ToList();
        }
    }
}
