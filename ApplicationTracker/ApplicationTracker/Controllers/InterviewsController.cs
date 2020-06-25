using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApplicationTracker.Data;
using ApplicationTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationTracker.Controllers
{
   // [Authorize(Roles = "Applicant")]
    public class InterviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InterviewsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: InterviewsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: InterviewsController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var applicant = _context.Applicants.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            if (applicant == null)
            {
                return NotFound();
            }
            return View();
        }

        // GET: InterviewsController/Create
        public ActionResult Create()
        {
            return View("CreateInterview");
        }

        // POST: InterviewsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInterviewAsync(Interview interview) //use a view model?, put in a bind
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var applicant = _context.Applicants.Where(a => a.IdentityUserId == userId).SingleOrDefault();

                interview.Application.ApplicantId = applicant.ApplicantId;
                _context.Interviews.Add(interview);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Applicants");
            }
            catch
            {
                return View("CreateInterview");
            }
        }

        // GET: InterviewsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InterviewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InterviewsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InterviewsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
