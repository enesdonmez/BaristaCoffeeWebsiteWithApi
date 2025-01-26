using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaCoffee.Dto.AboutDtos;

public class UpdateAboutDto
{
    public int Id { get; set; }
    public string Content { get; set; }
    public string VideoUrl { get; set; }
}
