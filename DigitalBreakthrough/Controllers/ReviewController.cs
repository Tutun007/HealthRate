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
    public class ReviewController : ControllerBase
    {
        private readonly IMapper _mapper;
        DigitalBreakthroughContext _context;

        public ReviewController(DigitalBreakthroughContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Route("create")]
        [HttpPost]
        public IActionResult CreateReview([FromBody] ReviewFormModel request)
        {
            var appointment = _context.Appointments.Find(request.AppointmentId);
            var review = _mapper.Map<Review>(request);
            review.Appointment = appointment;
            if(_context.Reviews.Any(r=> r.Appointment.Id == appointment.Id))
            {
                return BadRequest();
            }
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return Ok();
        }
    }
}