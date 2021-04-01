using HealthRate.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthRate.Areas.Identity.Data
{
    public class Appointment
    {
        public int Id { get; set; }
        
        public User Doctor { get; set; }

        public User Patient { get; set; }

        public DateTime Time { get; set; }

        public EventStatus Status { get; set; }

        public Appointment PreviousAppointment { get; set; }

        public string DoctorComment { get; set; }

        public string PatientComment { get; set; }

        public IEnumerable<Review> Reviews { get; set; }
    }
}
