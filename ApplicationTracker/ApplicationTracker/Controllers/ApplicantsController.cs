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

namespace ApplicationTracker.Controllers
{        
    [Authorize(Roles ="Applicant")]
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
            return View(applicant);
        }

        // GET: ApplicantsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApplicantsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicantsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Applicant applicant)
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApplicantsController/Edit/5
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
