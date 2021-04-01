using HealthRate.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthRate.ViewModels
{
    public class ReviewFormModel
    {
        public int AppointmentId { get; set; }

        public string Text { get; set; }
        public Rating SpeedReview { get; set; }

        public Rating QualityReview { get; set; }

        public Rating PolitenessReview { get; set; }

        public Rating CleannessReview { get; set; }

        public Rating ErgonomicsReview { get; set; }
    }
}
