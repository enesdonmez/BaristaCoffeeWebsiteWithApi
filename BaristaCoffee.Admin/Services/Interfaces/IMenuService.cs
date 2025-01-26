using BaristaCoffee.Dto.MenuDtos;

namespace BaristaCoffee.Admin.Services.Interfaces
{
    public interface IMenuService
    {
        Task<List<GetAllMenuDto>> GetAllMenuAsync();
    }
}
