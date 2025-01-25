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

        public async Task<List<GetAllBaristaDto>> GetAllBaristaAsync()
        {
            var sql = "SELECT * FROM Barista";
            var result = await _connection.QueryAsync<GetAllBaristaDto>(sql);
            return result.ToList();
        }
    }
}
