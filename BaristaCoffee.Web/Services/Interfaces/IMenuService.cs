using BaristaCoffee.Dto.MenuDtos;

namespace BaristaCoffee.Web.Services.Interfaces
{
    public interface IMenuService
    {
        Task<List<GetAllMenuDto>> GetAllMenuAsync();
    }
}
