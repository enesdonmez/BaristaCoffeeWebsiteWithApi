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
            param.Add("@categoryId", createMenuItemDto.CategoryId);

            await _dbConnection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteMenuItemAsync(int id)
        {
            var sql = "DELETE FROM Menu WHERE Id = @Id";
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", id);
            await _dbConnection.ExecuteAsync(sql, param);
        }

        public async Task<List<GetAllMenuDto>> GetAllMenuAsync()
        {
            var sql = "SELECT m.Id, m.ProductName , m.Description , m.Price , mc.CategoryName FROM Menu m" +
                " inner join MenuCategory mc on mc.Id = m.CategoryId";
            var result = await _dbConnection.QueryAsync<GetAllMenuDto>(sql);
            return result.ToList();
        }

        public async Task<GetByIdMenuItemDto> GetMenuItemByIdAsync(int id)
        {
            var sql = "SELECT m.Id, m.ProductName , m.Description , m.Price , mc.CategoryName FROM Menu m" +
                " inner join MenuCategory mc on mc.Id = m.CategoryId where m.Id = @id";

            var param = new DynamicParameters();
            param.Add("@id", id);

            var result = await _dbConnection.QueryFirstOrDefaultAsync<GetByIdMenuItemDto>(sql,param);
            return result;
        }

        public async Task UpdateMenuItemAsync(UpdateMenuDto updateMenuItemDto)
        {
            var sql = "SP_UPDATE_MENU";
            var param = new DynamicParameters();
            param.Add("@Id", updateMenuItemDto.Id);
            param.Add("@productName", updateMenuItemDto.ProductName);
            param.Add("@description", updateMenuItemDto.Description);
            param.Add("@price", updateMenuItemDto.Price);
            param.Add("@categoryId", updateMenuItemDto.CategoryId);

            await _dbConnection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
        }
    }
}
