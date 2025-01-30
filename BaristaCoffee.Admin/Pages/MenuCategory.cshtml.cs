using BaristaCoffee.Admin.Services.Interfaces;
using BaristaCoffee.Dto.MenuCategoryDtos;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BaristaCoffee.Admin.Pages
{
    public class MenuCategoryModel : PageModel
    {
        private readonly IMenuCategoryService _menuCategoryService;

        public required List<GetAllMenuCategoryDto> MenuCategories { get; set; }


        public MenuCategoryModel(IMenuCategoryService menuCategoryService)
        {
            _menuCategoryService = menuCategoryService;
        }

        public async Task OnGet()
        {
            MenuCategories = await _menuCategoryService.GetAllMenuCategoryAsync();
        }
    }
}
