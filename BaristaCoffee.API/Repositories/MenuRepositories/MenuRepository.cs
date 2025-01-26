using BaristaCoffee.Dto.MenuDtos;
using Dapper;
using System.Data;

namespace BaristaCoffee.API.Repositories.MenuRepositories
{
    public class MenuRepository(IDbConnection _dbConnection) : IMenuRepository
    {
        public async Task CreateMenuItemAsync(CreateMenuItemDto createMenuItemDto)
        {
            string sql = "SP_INSERT_MENU";
            var param = new DynamicParameters();
            param.Add("productName", createMenuItemDto.ProductName);
            param.Add("@description", createMenuItemDto.Description);
            param.Add("@price", createMenuItemDto.Price);

            await _dbConnection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
        }

        public Task DeleteMenuItem(int id)
        {
            var sql = "DELETE FROM Menu WHERE Id = @Id";
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", id);
            return _dbConnection.ExecuteAsync(sql, param);
        }

        public Task DeleteMenuItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetAllMenuDto>> GetAllMenuAsync()
        {
            var sql = "SELECT * FROM Menu";
            var result = await _dbConnection.QueryAsync<GetAllMenuDto>(sql);
            return result.ToList();
        }

        public Task UpdateMenuItem(UpdateMenuDto updateMenuItemDto)
        {
            var sql = "SP_UPDATE_MENU";
            var param = new DynamicParameters();
            param.Add("@Id", updateMenuItemDto.Id);
            param.Add("@productName", updateMenuItemDto.ProductName);
            param.Add("@description", updateMenuItemDto.Description);
            param.Add("@price", updateMenuItemDto.Price);
            return _dbConnection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
        }

        public Task UpdateMenuItemAsync(UpdateMenuDto updateMenuItemDto)
        {
            throw new NotImplementedException();
        }
    }
}
