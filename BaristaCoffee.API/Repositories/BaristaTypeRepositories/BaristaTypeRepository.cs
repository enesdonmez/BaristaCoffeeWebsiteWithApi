using BaristaCoffee.Dto.BaristaTypeDtos;
using Dapper;
using System.Data;

namespace BaristaCoffee.API.Repositories.BaristaTypeRepositories
{
    public class BaristaTypeRepository(IDbConnection _dbConnection) : IBaristaTypeRepository
    {
        public async Task CreateBaristaTypeAsync(CreateBaristaTypeDto createBaristaTypeDto)
        {
            var sql = "INSERT INTO BaristaType(TypeName) VALUES(@TypeName)";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("TypeName", createBaristaTypeDto.TypeName);
            await _dbConnection.ExecuteAsync(sql, parameters);
        }

        public async Task DeleteBaristaTypeAsync(int id)
        {
            var sql = "DELETE FROM BaristaType WHERE Id = @Id";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id);
            await _dbConnection.ExecuteAsync(sql, parameters);
        }

        public async Task<List<GetAllBaristaTypeDto>> GetAllBaristaTypeAsync()
        {
             var sql = "SELECT * FROM BaristaType";
            var types = await _dbConnection.QueryAsync<GetAllBaristaTypeDto>(sql);
            return types.ToList();
        }

        public async Task<GetByIdBaristaTypeDto> GetBaristaTypeByIdAsync(int id)
        {
            var sql = "SELECT * FROM BaristaType WHERE Id = @Id";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id);
            var type = await _dbConnection.QueryFirstOrDefaultAsync<GetByIdBaristaTypeDto>(sql, parameters)!;
            return type;
        }

        public async Task UpdateBaristaTypeAsync(UpdateBaristaTypeDto updateBaristaTypeDto)
        {
            var sql = "UPDATE BaristaType SET TypeName = @TypeName WHERE Id = @Id";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", updateBaristaTypeDto.Id);
            parameters.Add("TypeName", updateBaristaTypeDto.TypeName);
            await _dbConnection.ExecuteAsync(sql, parameters);
        }
    }
}
