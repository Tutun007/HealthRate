using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DigitalBreakthrough.Areas.Identity.Data;
using DigitalBreakthrough.Models;
using DigitalBreakthrough.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalBreakthrough.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        DigitalBreakthroughContext _context;

        public AppointmentController(DigitalBreakthroughContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Route("get")]
        [HttpGet]
        public IEnumerable<AppointmentModel> GetAppointments(string userId = null, DateTime? date = null)
        {
            IQueryable<Appointment> result = _context.Appointments.Include(x=> x.Doctor).Include(x=>x.Patient);

            if (date != null)
            {
                result = result.Where(a => a.Time.Date == date.Value.Date);
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
        [HttpPost]
        public ActionResult SignIntoAppointment(string userId, int appointmentId)
        {
            _context.Appointments.Find(appointmentId).Patient = _context.Users.Find(userId);
            _context.SaveChanges();
            return Ok();
        }
    }
}