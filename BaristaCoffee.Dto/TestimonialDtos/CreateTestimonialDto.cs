﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaCoffee.Dto.TestimonialDtos
{
    public class CreateTestimonialDto
    {
        public string TestimonialName { get; set; }

        public string Comment { get; set; }

        public string Image { get; set; }

        public decimal Rating { get; set; }
    }
}
