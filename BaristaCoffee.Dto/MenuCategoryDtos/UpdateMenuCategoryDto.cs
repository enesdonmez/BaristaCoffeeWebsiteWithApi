using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaCoffee.Dto.MenuCategoryDtos
{
    public class UpdateMenuCategoryDto
    {
        public int Id { get; set; }

        public string? CategoryName { get; set; }
    }
}
