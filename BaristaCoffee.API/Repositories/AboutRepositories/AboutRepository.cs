using BaristaCoffee.Dto.AboutDtos;
using System.Data;
using Dapper;

namespace BaristaCoffee.API.Repositories.AboutRepositories
{
    public class AboutRepository : IAboutRepository
    {
       private readonly IDbConnection _dbConnection;

        public AboutRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task CreateAbout(CreateAboutDto createAboutDto)
        {
            string sql = "INSERT INTO About(Content, VideoUrl) VALUES(@content, @videoUrl)";
            DynamicParameters parameters = new();
            parameters.Add("@content", createAboutDto.Content);
            parameters.Add("@videoUrl", createAboutDto.VideoUrl);
            await _dbConnection.ExecuteAsync(sql, parameters);
        }

        public async Task<List<GetAboutDto>> GetAbout()
        {
            var sql = "SELECT * FROM About";
            var result = await _dbConnection.QueryAsync<GetAboutDto>(sql);
            return result.ToList();
        }
    }
}
