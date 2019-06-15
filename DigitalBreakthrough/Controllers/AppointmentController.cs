using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DigitalBreakthrough.Models;
using DigitalBreakthrough.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var result = _context.Appointments.AsQueryable();
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

            return _mapper.Map<List<AppointmentModel>>(result.ToList());
        }
    }
}