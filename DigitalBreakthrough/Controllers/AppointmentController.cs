using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthRate.Areas.Identity.Data;
using HealthRate.Models;
using HealthRate.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthRate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        HealthRateContext _context;

        public AppointmentController(HealthRateContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Route("get")]
        [HttpGet]
        public IEnumerable<AppointmentModel> GetAppointments(string userId = null, string date = null)
        {
            DateTime? dateVar = null;
            if (date != String.Empty)
            {
                dateVar = DateTime.ParseExact(date, "dd.MM.yyyy", null);
            }
            IQueryable<Appointment> result = _context.Appointments.Include(x=> x.Doctor).Include(x=>x.Patient);

            if (dateVar != null)
            {
                result = result.Where(a => a.Time.Date == dateVar.Value.Date);
            }

            if (string.IsNullOrEmpty(userId))
            {
                result = result.Where(a => a.Patient == null);
            }
            else
            {
                result = result.Where(a => a.Patient != null && a.Patient.Id == userId);
            }

            return _mapper.Map<List<AppointmentModel>>(result);
        }

        [Route("signInto")]
        [HttpGet]
        public ActionResult SignIntoAppointment(string userId,int appointmentId)
        {
            _context.Appointments.Find(appointmentId).Patient = _context.Users.Find(userId);
            _context.SaveChanges();
            return Ok();
        }
    }
}