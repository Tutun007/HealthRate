using DigitalBreakthrough.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBreakthrough.ViewModels
{
    public class AppointmentModel
    {
        public int Id { get; set; }
        public string DoctorId { get; set; }
        public string DoctorName { get; set; }
        public DateTime Time { get; set; }
        public EventStatus Status { get; set; }
    }
}
