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
using Microsoft.EntityFrameworkCore;

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
        public ActionResult CreateInterview(int id)
        {
            Interview interview = new Interview();

            interview.ApplicationId = id;

            return View("CreateInterview", interview);
        }

        // POST: InterviewsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInterviewAsync(int id, Interview interview) //use a view model?, put in a bind
        {
            try
            {
                _context.Interviews.Add(interview);

                UpdateApplicationStatusToInterview(interview.ApplicationId, "Interview");

                await _context.SaveChangesAsync();
                
                return RedirectToAction("Index", "Applicants");
            }
            catch
            {
                return View("CreateInterview");
            }
        }

        public void UpdateApplicationStatusToInterview(int applicationId, string statusToUpdateTo)
        {
            //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var applicant = _context.Applicants.Where(a => a.IdentityUserId == userId).SingleOrDefault();

            // TODO: null check after querying
            var statusChange = _context.Applications.Where(a => a.ApplicationId == applicationId).SingleOrDefault();
            statusChange.ApplicationStatus = statusToUpdateTo;
            // save changes


            //if (statusChange.ApplicationStatus == "Submitted")
            //{
            //    statusChange.ApplicationStatus = "Interview";
            //    _context.Applications.Update(a => a.Applications.ApplicationStatus = );
            //}

            // return statusChange;
        }

        // GET: InterviewsController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var interview = await _context.Interviews.FindAsync(id);
            if (interview == null)
            {
                return NotFound();
            }

            return View(interview);
        }

        // POST: InterviewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Interview interview)
        {
            if(id != interview.InterviewId)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(interview);
                    await _context.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!InterviewExists(interview.InterviewId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Applicants");
            }
            return View(interview);
        }
        private bool InterviewExists(int id)
        {
            //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var applicant = _context.Applicants.Where(a => a.IdentityUserId == userId).SingleOrDefault();
            //var interviews = _context.Interviews.Where(i => i.Application.Applicant.ApplicantId == applicant.ApplicantId);

            return _context.Interviews.Any(i => i.InterviewId == id);
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
