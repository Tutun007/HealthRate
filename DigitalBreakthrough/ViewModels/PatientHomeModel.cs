﻿using DigitalBreakthrough.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBreakthrough.ViewModels
{
    public class PatientHomeModel
    {
        public string UserId { get; set; }
        public List<AppointmentModel> Appointments { get; set; }
        public List<Treatment> Treatments { get; set; }
    }
}
