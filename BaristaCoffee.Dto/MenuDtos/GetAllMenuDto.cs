﻿using BaristaCoffee.Dto.MenuCategoryDtos;

namespace BaristaCoffee.Dto.MenuDtos
{
    public class GetAllMenuDto
    {
        public int Id { get; set; }

        public string? ProductName { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; } = default!;
    }
}
