﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBreakthrough.Areas.Identity.Data
{
    public class AnalyseType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Comment { get; set; }
    }
}
