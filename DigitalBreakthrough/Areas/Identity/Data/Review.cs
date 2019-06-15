using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBreakthrough.Areas.Identity.Data
{
    public class Review
    {
        public int Id { get; set; }

        public string Text { get; set; }

        [Required]
        public Appointment Appointment { get; set; }
    }
}
