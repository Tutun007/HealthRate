using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalBreakthrough.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DigitalBreakthrough.Models
{
    public class DigitalBreakthroughContext : IdentityDbContext<User>
    {
        public DigitalBreakthroughContext(DbContextOptions<DigitalBreakthroughContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole {
                    Id = Enums.Roles.Doctor.ToString()
                , Name = Enums.Roles.Doctor.ToString()
                ,
                    NormalizedName = Enums.Roles.Doctor.ToString().ToUpper()
                },
                new IdentityRole {
                    Id = Enums.Roles.Patient.ToString(),
                    Name = Enums.Roles.Patient.ToString(),
                    NormalizedName = Enums.Roles.Patient.ToString().ToUpper()
                });

            builder.Entity<AnalyseType>().HasData(
                new AnalyseType { Id=5, Name = "Кровь из вены" , Comment = "Какой-то комментарий"},
                new AnalyseType { Id = 1, Name = "УЗИ"},
                new AnalyseType { Id = 2, Name = "ФЛЮ"},
                new AnalyseType { Id = 3, Name = "Моча" },
                new AnalyseType { Id = 4, Name = "Кал" });

            builder.Entity<TreatmentType>().HasData(
                new TreatmentType { Id = 2, Name = "Медикоментозное лечение", Comment = "Какой-то комментарий" },
                new TreatmentType { Id = 1, Name = "Процедура электрофорез" });
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Analyse> Analyses { get; set; }
        public DbSet<AnalyseType> AnalyseTypes { get; set; }
        public DbSet<TreatmentType> TreatmentTypes { get; set; }
    }
}
