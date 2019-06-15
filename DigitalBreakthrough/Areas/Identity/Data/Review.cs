using DigitalBreakthrough.Enums;
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

        public Rating SpeedReview { get; set; }
        
        public Rating QualityReview { get; set; }

        public Rating PolitenessReview { get; set; }

        public Rating CleannessReview { get; set; }

        public Rating ErgonomicsReview { get; set; }
    }
}
