using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthRate.Areas.Identity.Data
{
    public class Treatment
    {
        public int Id { get; set; }

        public Appointment ParentAppointment { get; set; }

        public DateTime Time { get; set; }

        public string Comment { get; set; }
    }
}
