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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            if(applicantapplications.Count == 0) //do i need applicant.application.ApplicationId to find only applications tied to that applicant
            {
                //return RedirectToAction("CreateApplication");
                //return RedirectToAction("Index", "Interviews");
                return RedirectToAction(nameof(CreateApplication)); //change to redirecttoAction CreateApplication or 'go apply for jobs'
            }
            //Company company = new Company();
            //company.CompanyName = applicationViewModel.Company.CompanyName;
            //var companyName = _context.Companies.Where(c => c.CompanyName == app
            //var companyAddress = _context.Applications.Include("Company").ThenInclude("Address")
            //var upcomingInterveiws = final all interviews I want to display
            //var upcomingapplications = find all applications I want to display
            //applicationViewModel.UpcomingInterviews = //that query

            ApplicationIndexViewModel applicationViewModel = new ApplicationIndexViewModel();
            var UpcomingApplications = _context.Applications //do I want to rename UpcomingApplications here so that I can use it for UpcomingInterviews?
                .Where(a => a.ApplicantId == applicant.ApplicantId)
                .Include(a => a.JobInformation)
                .Include(a => a.Company)
                    .ThenInclude(a => a.CompanyNote)
                .ToList();
            applicationViewModel.UpcomingApplications = UpcomingApplications;
            var UpcomingInterviews = _context.Interviews
                .Where(i => i.Application.ApplicantId == applicant.ApplicantId)
                .Include(i => i.Interviewer)
                .Include(i => i.HiringManager)
                .Include(i => i.Application)
                    .ThenInclude(i => i.Company)
                    .ThenInclude(i => i.CompanyNote)
                .Include("Application.Company.Address") //works. could use cascading/multiple queries or other options as below
                .ToList();
            //UpcomingInterviews = _context.Interviews.Include("Application.Company.Address").ToList(); //works
            //UpcomingInterviews = _context.Interviews.Include(i => i.Application.Company.Address).ToList(); //works
            //foreach (var item in UpcomingInterviews) //works
            //{
            //    _context.Interviews.Include(i => i.Application.Company.Address).ToList();
            //}
            applicationViewModel.UpcomingInterviews = UpcomingInterviews;

            return View(applicationViewModel/*, applicantapplications*/);
        }

        //private bool ApplicationsExist(List<Application> applications)
        //{
        //    if(applications == null)
        //    {
        //        return false;
        //    }
        //    return true;
        //    //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    //var applicant1 = _context.Applicants.Where(a => a.IdentityUserId == userId).SingleOrDefault();
        //    //return _context.Applications.Any(a => a.ApplicationId == id);
        //    //_context.Applications.Where(a => a.ApplicantId == applicant1.ApplicantId);
        //    //return applicant1;
        //}
        private bool ApplicationsExist(int id)
        {
            return _context.Applications.Any(a => a.ApplicationId == id);
        }

        //GET
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
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var applicant = _context.Applicants.Where(a => a.IdentityUserId == userId).SingleOrDefault();
            
            if (applicant == null)
            {
                return NotFound();
            }
            
            return View(applicant);
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

        public async Task<IActionResult> EditApplication(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicant = await _context.Applicants.FindAsync(id);

            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }

        public async Task<IActionResult> EditApplication(int id, [Bind("ApplicantId,FirstName,LastName,Industry,Email,IdentityUserId")] Application application)
        {

            if (id != application.ApplicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(application);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationsExist(application.ApplicationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(application);
        }

        //private bool ApplicantExists(int id)
        //{
        //    return _context.Applicants.Any(a => a.ApplicantId == id);
        //}
        // GET: ApplicantsController/Delete/5
        public ActionResult Delete(int id)
        {
            var applicant = _context.Applicants.Where(i => i.ApplicantId == id).FirstOrDefault();
            return View(applicant);
        }

        // POST: ApplicantsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Applicant applicant)
        {
            try
            {
                var applicantDeletion = _context.Applicants.Where(i => i.ApplicantId == id).FirstOrDefault();
                _context.Applicants.Remove(applicantDeletion);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
