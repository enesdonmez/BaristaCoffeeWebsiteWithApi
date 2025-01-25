using BaristaCoffee.Dto.MenuDtos;
using Dapper;
using System.Data;

namespace BaristaCoffee.API.Repositories.MenuRepositories
{
    public class MenuRepository(IDbConnection _dbConnection) : IMenuRepository 
    {
        public async Task CreateMenuItem(CreateMenuItemDto createMenuItemDto)
        {
            string sql = "SP_INSERT_MENU";
            var param = new DynamicParameters();
            param.Add("productName", createMenuItemDto.ProductName);
            param.Add("@description", createMenuItemDto.Description);
            param.Add("@price", createMenuItemDto.Price);

            await _dbConnection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<GetAllMenuDto>> GetAllMenuAsync()
        {
            var sql = "SELECT * FROM Menu";
            var result = await _dbConnection.QueryAsync<GetAllMenuDto>(sql);
            return result.ToList();
        }
    }
}
