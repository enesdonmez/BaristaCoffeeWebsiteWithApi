using BaristaCoffee.Dto.BaristaDtos;
using Dapper;
using System.Data;

namespace BaristaCoffee.API.Repositories.BaristaRepositories
{
    public class BaristaRepository : IBaristaRepository
    {
        private readonly IDbConnection _connection;

        public BaristaRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task CreateBarista(CreateBaristaDto createBaristaDto)
        {
            var sql = "INSERT INTO Barista (BaristaName, ImageUrl, Type) VALUES (@Name, @Image, @Type)";
            DynamicParameters parameters = new();
            parameters.Add("@Name", createBaristaDto.Name);
            parameters.Add("@Image", createBaristaDto.Image);
            parameters.Add("@Type", createBaristaDto.Type);
            await _connection.ExecuteAsync(sql, parameters);

        }

        public async Task<List<GetAllBaristaDto>> GetAllBaristaAsync()
        {
            var sql = "SELECT * FROM Barista";
            var result = await _connection.QueryAsync<GetAllBaristaDto>(sql);
            return result.ToList();
        }
    }
}
