using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApplicationTracker.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationTracker.Controllers
{
    //[Authorize(Roles = "Applicant")]
    public class AssessmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AssessmentsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: AssessmentsController
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var applicant = _context.Applicants.Where(a => a.IdentityUserId == userId).SingleOrDefault();
            var applicantAssessments = _context.Assessments.Where(q => q.ApplicantId == applicant.ApplicantId).ToList();
            return View(applicantAssessments);
        }

        // GET: AssessmentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AssessmentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssessmentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: AssessmentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AssessmentsController/Edit/5
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

        // GET: AssessmentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AssessmentsController/Delete/5
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
