using BaristaCoffee.Dto.MenuCategoryDtos;
using Dapper;
using System.Data;

namespace BaristaCoffee.API.Repositories.MenuCategoryRepositories
{
    public class MenuCategoryRepository : IMenuCategoryRepository
    {
        private readonly IDbConnection _dbConnection;

        public MenuCategoryRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task CreateMenuCategoryAsync(CreateMenuCategoryDto menuCategory)
        {
            string sql = "INSERT INTO MenuCategory(CategoryName) VALUES(@categoryName)";
            DynamicParameters parameters = new();
            parameters.Add("@categoryName", menuCategory.CategoryName);
            await _dbConnection.ExecuteAsync(sql, parameters);
        }

        public async Task DeleteMenuCategoryAsync(int id)
        {
            var sql = "DELETE FROM MenuCategory WHERE Id = @id";
            DynamicParameters parameters = new();
            parameters.Add("@id", id);
            await _dbConnection.ExecuteAsync(sql, parameters);
        }

        public async Task<List<GetAllMenuCategoryDto>> GetAllMenuCategoryAsync()
        {
            var sql = "SELECT * FROM MenuCategory";
            var menuCategories = await _dbConnection.QueryAsync<GetAllMenuCategoryDto>(sql);
            return menuCategories.ToList();
        }

        public Task<GetByIdMenuCategoryDto> GetMenuCategoryByIdAsync(int id)
        {
            var sql = "SELECT * FROM MenuCategory WHERE Id = @id";
            DynamicParameters parameters = new();
            parameters.Add("@id", id);
            var menuCategory = _dbConnection.QueryFirstOrDefaultAsync<GetByIdMenuCategoryDto>(sql, parameters);
            return menuCategory!;
        }

        public Task UpdateMenuCategoryAsync(UpdateMenuCategoryDto menuCategory)
        {
            throw new NotImplementedException();
        }
    }
}
