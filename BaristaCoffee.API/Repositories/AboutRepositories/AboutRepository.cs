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

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto, CancellationToken cancellationToken)
        {
            string sql = "INSERT INTO About(Content, VideoUrl) VALUES(@content, @videoUrl)";
            DynamicParameters parameters = new();
            parameters.Add("@content", createAboutDto.Content);
            parameters.Add("@videoUrl", createAboutDto.VideoUrl);

            var command = new CommandDefinition(sql, parameters, cancellationToken: cancellationToken);
            await _dbConnection.ExecuteAsync(command);
        }

        public async Task DeleteAboutAsync(int id, CancellationToken cancellationToken)
        {
            var sql = "Delete from About Where Id = @id";
            DynamicParameters parameters = new();
            parameters.Add("@id", id);

            await _dbConnection.ExecuteAsync(sql,parameters);
        }

        public async Task<List<GetAboutDto>> GetAboutAsync(CancellationToken cancellationToken)
        {
            var sql = "SELECT * FROM About";
            var command = new CommandDefinition(sql, cancellationToken: cancellationToken);
            var result = await _dbConnection.QueryAsync<GetAboutDto>(command);
            return result.ToList();
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto, CancellationToken cancellationToken)
        {
            var sql = "Update About set Content = @content , VideoUrl = @url where Id= @id";
            DynamicParameters parameters = new();
            parameters.Add("@id", updateAboutDto.Id);
            parameters.Add("@content", updateAboutDto.Content);
            parameters.Add("@url", updateAboutDto.VideoUrl);

            await _dbConnection.ExecuteAsync(sql, parameters);
        }
    }

}
