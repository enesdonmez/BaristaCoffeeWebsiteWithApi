using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaCoffee.Dto.BaristaDtos;

public class UpdateBaristaDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public string Type { get; set; }
}
