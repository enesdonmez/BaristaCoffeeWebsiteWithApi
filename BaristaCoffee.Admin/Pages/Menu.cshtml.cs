using BaristaCoffee.Admin.Services.Interfaces;
using BaristaCoffee.Dto.MenuDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BaristaCoffee.Admin.Pages
{
    public class MenuModel : PageModel
    {
        private readonly IMenuService _menuService;

        public required List<GetAllMenuDto> MenuList { get; set; }

        public MenuModel(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public async Task OnGetAsync()
        {
           MenuList =  await _menuService.GetAllMenuAsync();
        }
    }
}
