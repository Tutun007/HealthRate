using DigitalBreakthrough.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBreakthrough.Areas.Identity.Data
{
    public class Appointment
    {
        public int AppointmentID { get; set; }

        public int DoctorID { get; set; }

        public User Doctor { get; set; }

        public int PatientID { get; set; }

        public User Patient { get; set; }

        public DateTime AppointmentTime { get; set; }

        public AppointmentStatus Status { get; set; }

        public Appointment PreviousAppointment { get; set; }
        
        public int? PreviousAppointmentID { get; set; }

        public string Comment { get; set; }
    }
}
