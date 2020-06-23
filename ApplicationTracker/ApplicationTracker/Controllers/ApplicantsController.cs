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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ApplicationTracker.Controllers
{        
    //[Authorize(Roles ="Applicant")]
    public class ApplicantsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ApplicantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ApplicantsController
        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var applicant = _context.Applicants.Where(a => a.IdentityUserId == userId).SingleOrDefault();
            var applicantapplications = _context.Applications.Where(a => a.ApplicantId == applicant.ApplicantId).ToList();
            if(applicantapplications == null) //do i need applicant.application.ApplicationId to find only applications tied to that applicant
            {
                //return RedirectToAction("CreateApplication");
                //return RedirectToAction("Index", "Interviews");
                return RedirectToAction(nameof(CreateApplication)); //change to redirecttoAction CreateApplication or 'go apply for jobs'
            }
            return View(applicantapplications);
        }

        private bool ApplicationsExist(List<Application> applications)
        {
            if(applications == null)
            {
                return false;
            }
            return true;
            //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var applicant1 = _context.Applicants.Where(a => a.IdentityUserId == userId).SingleOrDefault();
            //return _context.Applications.Any(a => a.ApplicationId == id);
            //_context.Applications.Where(a => a.ApplicantId == applicant1.ApplicantId);
            //return applicant1;
        }

        public IActionResult CreateApplication()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateApplicationAsync(Application application)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var applicant = _context.Applicants.Where(a => a.IdentityUserId == userId).SingleOrDefault();
            //if (!ApplicationsExist(application.ApplicantId/*, applicant*/))
            //{
                application.ApplicantId = applicant.ApplicantId;
                _context.Applications.Add(application);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //return View("CreateApplication", application);
        }

        // GET: ApplicantsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApplicantsController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApplicantsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync([Bind("ApplicantId,FirstName,LastName,Industry,Email")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                applicant.IdentityUserId = userId;
                _context.Add(applicant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", applicant.IdentityUserId);
            return View("Create", applicant);
        }

        // GET: ApplicantsController/Edit/5
        public IActionResult Edit(int id)
        {
            var applicant = _context.Applicants.Where(i => i.ApplicantId == id).SingleOrDefault();
            return View(applicant);
        }
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var applicant = await _context.Applicants.FindAsync(id);

        //    if (applicant == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(applicant);
        //}
        // POST: ApplicantsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Applicant applicant)
        {
            try
            {
                _context.Applicants.Where(i => i.ApplicantId == id).SingleOrDefault();
                _context.Applicants.Update(applicant);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //public async Task<IActionResult> Edit(int id, [Bind("ApplicantId,FirstName,LastName,Industry,Email,IdentityUserId")] Applicant applicant)
        //{

        //    if (id != applicant.ApplicantId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(applicant);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ApplicantExists(applicant.ApplicantId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(applicant);
        //}

        //private bool ApplicantExists(int id)
        //{
        //    return _context.Applicants.Any(a => a.ApplicantId == id);
        //}
        // GET: ApplicantsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApplicantsController/Delete/5
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
