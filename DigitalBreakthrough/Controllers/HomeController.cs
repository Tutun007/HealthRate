using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DigitalBreakthrough.Models;
using Microsoft.AspNetCore.Authorization;
using DigitalBreakthrough.ViewModels;
using Microsoft.AspNetCore.Identity;
using DigitalBreakthrough.Areas.Identity.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace DigitalBreakthrough.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        DigitalBreakthroughContext _context;
        UserManager<User> _userManager;
        private readonly IMapper _mapper;


        public HomeController(DigitalBreakthroughContext context, UserManager<User> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var data = new PatientHomeModel
            {
                UserId = userId,
                Appointments = _mapper.Map<List<AppointmentModel>>(
                    _context.Appointments
                    .Include(a=> a.Patient)
                    .Include(a=> a.Doctor)
                    .Include(a => a.PreviousAppointment)
                    .Where(a => a.Patient != null && a.Patient.Id == userId)),
                Treatments = _context.Treatments.Where(a => a.ParentAppointment.Patient != null && a.ParentAppointment.Patient.Id == userId).ToList()
            };
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
