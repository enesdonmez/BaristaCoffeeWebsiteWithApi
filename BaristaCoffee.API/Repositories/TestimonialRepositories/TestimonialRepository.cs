using BaristaCoffee.Dto.MenuDtos;
using BaristaCoffee.Dto.TestimonialDtos;
using Dapper;
using System.Data;

namespace BaristaCoffee.API.Repositories.TestimonialRepositories
{
    public class TestimonialRepository(IDbConnection _dbConnection) : ITestimonialRepository
    {
        public async Task CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            string sql = "SP_INSERT_TESTİMONİAL";
            var param = new DynamicParameters();
            param.Add("@testimonialName", createTestimonialDto.TestimonialName);
            param.Add("@@comment", createTestimonialDto.Comment);
            param.Add("@rating", createTestimonialDto.Rating);
            param.Add("@image", createTestimonialDto.Image);

            await _dbConnection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<GetAllTestimonialDto>> GetAllTestimonialAsync()
        {
            string sql = "SELECT * FROM Testimonial";
            var result = await _dbConnection.QueryAsync<GetAllTestimonialDto>(sql);
            return result.ToList();
        }
    }
}
