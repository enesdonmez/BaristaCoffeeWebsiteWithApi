using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaCoffee.Dto.RezervationDtos
{
    public class GetByIdRezervationDto
    {
        public int Id { get; set; }

        public string? FullName { get; set; }

        public string? Phone { get; set; }

        public TimeSpan RezervationTime { get; set; }

        public DateOnly RezervationDate { get; set; }

        public Int16 NumberOfPeople { get; set; }

        public string? Comment { get; set; }

        public bool IsActive { get; set; }
    }
}
