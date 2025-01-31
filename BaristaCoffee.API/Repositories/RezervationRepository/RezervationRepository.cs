using BaristaCoffee.Dto.RezervationDtos;
using Dapper;
using System.Data;

namespace BaristaCoffee.API.Repositories.RezervationRepository
{
    public class RezervationRepository : IRezervationRepository
    {
        private readonly IDbConnection _connection;

        public RezervationRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task CreateRezervationAsync(CreateRezervationDto createRezervationDto)
        {
            var sql = "SP_INSERT_REZERVATION";
            DynamicParameters parameters = new();
            parameters.Add("@fullName", createRezervationDto.FullName);
            parameters.Add("@phone", createRezervationDto.Phone);
            parameters.Add("@rezervationTime", createRezervationDto.RezervationTime);
            parameters.Add("@rezervationDate", createRezervationDto.RezervationDate,DbType.Date);
            parameters.Add("@numberOfPeople", createRezervationDto.NumberOfPeople);
            parameters.Add("@comment", createRezervationDto.Comment);
            parameters.Add("@isActive", createRezervationDto.IsActive);

            await _connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
        }

        public Task DeleteRezervationAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetAllRezervationDto>> GetAllRezervationAsync()
        {
            string sql = "SP_SELECT_REZERVATION";
            var result = await _connection.QueryAsync<GetAllRezervationDto>(sql,CommandType.StoredProcedure);
            return result.ToList();
        }

        public Task<GetByIdRezervationDto> GetRezervationByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRezervationAsync(UpdateRezervationDto updateRezervationDto)
        {
            throw new NotImplementedException();
        }
    }
}
