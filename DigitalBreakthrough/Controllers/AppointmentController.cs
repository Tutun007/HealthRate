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
        // GET: api/Appointment
        [HttpGet("{userId}", Name = "Get")]
        public IEnumerable<AppointmentModel> Get(string userId)
        {
            var result = _context.Appointments.Where(a => a.Patient != null && a.Patient.Id == userId).ToList();
            
            return _mapper.Map<List<AppointmentModel>>(result);
        }

        [HttpGet("{date}", Name = "Get")]
        public IEnumerable<AppointmentModel> Get(DateTime date)
        {
            var result = _context.Appointments.Where(a => a.Time.Date == date.Date && a.Patient == null).ToList();
            return _mapper.Map<List<AppointmentModel>>(result);
        }

        // GET: api/Appointment/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Appointment
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Appointment/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
