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
            parameters.Add("@isActive", true);

            await _connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteRezervationAsync(int id)
        {
            var sql = "SP_DELETE_REZERVATION";
            DynamicParameters parameters = new();
            parameters.Add("@id", id);

            await _connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<GetAllRezervationDto>> GetAllRezervationAsync()
        {
            string sql = "SP_SELECT_REZERVATION";
            var result = await _connection.QueryAsync<GetAllRezervationDto>(sql,CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<GetByIdRezervationDto> GetRezervationByIdAsync(int id)
        {
            var sql = "SP_SELECT_REZERVATION_BY_ID";
            DynamicParameters parameters = new();
            parameters.Add("@id", id);

            var result = await _connection.QueryFirstOrDefaultAsync<GetByIdRezervationDto>(sql, parameters, commandType: CommandType.StoredProcedure);
            return result!;
        }

        public async Task UpdateRezervationAsync(UpdateRezervationDto updateRezervationDto)
        {
            var sp = "SP_UPDATE_REZERVATION";
            DynamicParameters parameters = new();
            parameters.Add("@id", updateRezervationDto.Id);
            parameters.Add("@fullName", updateRezervationDto.FullName);
            parameters.Add("@phone", updateRezervationDto.Phone);
            parameters.Add("@rezervationTime", updateRezervationDto.RezervationTime);
            parameters.Add("@rezervationDate", updateRezervationDto.RezervationDate, DbType.Date);
            parameters.Add("@numberOfPeople", updateRezervationDto.NumberOfPeople);
            parameters.Add("@comment", updateRezervationDto.Comment);
            parameters.Add("@active", updateRezervationDto.IsActive);

            await _connection.ExecuteAsync(sp, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
