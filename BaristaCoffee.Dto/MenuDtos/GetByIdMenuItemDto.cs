﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaCoffee.Dto.MenuDtos
{
    public class GetByIdMenuItemDto
    {
        public int Id { get; set; }

        public string? ProductName { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; }
    }
}
