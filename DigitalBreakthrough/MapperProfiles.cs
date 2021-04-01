using AutoMapper;
using HealthRate.Areas.Identity.Data;
using HealthRate.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthRate
{
    public class MapperProfiles : Profile
    {        
        public MapperProfiles()
        {
            CreateMap<Appointment, AppointmentModel>()
                .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.Doctor == null ? "" : src.Doctor.Id))
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor == null ? "" : src.Doctor.FullName))
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time.ToString("dd/MM/yyyy HH:mm")));

            CreateMap<ReviewFormModel, Review>();


        }
    }

}
