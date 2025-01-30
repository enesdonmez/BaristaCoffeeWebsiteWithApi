using BaristaCoffee.Admin.Services.Interfaces;
using BaristaCoffee.Dto.MenuCategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BaristaCoffee.Admin.Pages
{
    public class CreateMenuCategoryModel : PageModel
    {
        private readonly IMenuCategoryService _menuCategoryService;

        public CreateMenuCategoryModel(IMenuCategoryService menuCategoryService)
        {
            _menuCategoryService = menuCategoryService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(CreateMenuCategoryDto createMenuCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _menuCategoryService.CreateMenuCategoryAsync(createMenuCategoryDto);
            return RedirectToPage("MenuCategory");
        }
    }
}
