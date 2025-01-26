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

        public async Task CreateBaristaAsync(CreateBaristaDto createBaristaDto)
        {
            var sql = "INSERT INTO Barista (BaristaName, ImageUrl, Type) VALUES (@Name, @Image, @Type)";
            DynamicParameters parameters = new();
            parameters.Add("@Name", createBaristaDto.Name);
            parameters.Add("@Image", createBaristaDto.Image);
            parameters.Add("@Type", createBaristaDto.Type);
            await _connection.ExecuteAsync(sql, parameters);

        }

        public Task DeleteBaristaAsync(int id)
        {
            var sql = "DELETE FROM Barista WHERE Id = @Id";
            DynamicParameters parameters = new();
            parameters.Add("@Id", id);
            return _connection.ExecuteAsync(sql, parameters);
        }

        public async Task<List<GetAllBaristaDto>> GetAllBaristaAsync()
        {
            var sql = "SELECT * FROM Barista";
            var result = await _connection.QueryAsync<GetAllBaristaDto>(sql);
            return result.ToList();
        }

        public Task UpdateBaristaAsync(UpdateBaristaDto updateBaristaDto)
        {
            var sql = "UPDATE Barista SET BaristaName = @Name, ImageUrl = @Image, Type = @Type WHERE Id = @Id";
            DynamicParameters parameters = new();
            parameters.Add("@Id", updateBaristaDto.Id);
            parameters.Add("@Name", updateBaristaDto.Name);
            parameters.Add("@Image", updateBaristaDto.Image);
            parameters.Add("@Type", updateBaristaDto.Type);
            return _connection.ExecuteAsync(sql, parameters);

        }
    }
}
