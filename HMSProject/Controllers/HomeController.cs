using System.Diagnostics;
using HMSProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HMSProject.Controllers
{
    public class AppointmentController : Controller
    {
        private HospitalDbContext db = new HospitalDbContext();

        public ActionResult Index()
        {
            var appointments = db.Appointments.Include(a => a.Patient).Include(a => a.Doctor).ToList();
            return View(appointments);
        }

        public ActionResult Create()
        {
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name");
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appointment);
        }
}

        public IActionResult Index()
        {
            return View();
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
