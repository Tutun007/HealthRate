using DigitalBreakthrough.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBreakthrough.Areas.Identity.Data
{
    public class Analyse
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }

        [Required]
        public AnalyseType Type { get; set; }

        [Required]
        public Appointment ParentAppointment { get; set; }

        public EventStatus Status { get; set; }
    }
}
