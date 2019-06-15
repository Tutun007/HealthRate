using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBreakthrough.Areas.Identity.Data
{
    public class Treatment
    {
        public int TreatmentID { get; set; }

        public int ParentAppointmentID { get; set; }

        public Appointment ParentAppointment { get; set; }

        public string Comment { get; set; }
    }
}
