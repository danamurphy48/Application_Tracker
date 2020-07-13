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

            var assessment = _context.Assessments.Where(a => a.AssessmentId == id).SingleOrDefault();

            if (assessment == null)
            {
                return NotFound();
            }
            //var score = _context.Assessments.Select(s => s.Score).ToArray();
            //if (score == null)
            //{
            //    return NotFound();
            //}

            return View("ScoreChart", assessment);
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
        public ActionResult Quiz(int? id)
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

            var assessment = _context.Assessments.Where(a => a.AssessmentId == id).SingleOrDefault();

            if (assessment == null)
            {
                return NotFound();
            }

            var quiz = _context.Questions.Where(a => a.AssessmentId == assessment.AssessmentId).ToList();
            if (quiz == null)
            {
                return NotFound();
            }
            // var question = _context.Answers.Where(q => q.Question.Answers == quiz.Answers);
           // var question = _context.Questions.Where(q => q.Answers == quiz.);
            //foreach (var question in quiz)
            //{
            //    _context.Questions.Where(a => a.QuestionId == question.QuestionId).ToList();
            //    //foreach (var answer in question)
            //    //{
            //    //    _context.Answers.Where(a => a.AnswerId == question.Answers.AnswerId);
            //    //}
            //}
            foreach (var answer in quiz)
            {
                _context.Answers.Where(a => a.QuestionId == answer.QuestionId).ToList(); 
            }

            //var choice = _context.Answers.Where(a => a.QuestionId == quiz.QuestionId).ToArray();
            //if (choice == null)
            //{
            //    return NotFound();
            //}
            ViewData["AnswerId"] = new SelectList(_context.Answers, "AnswerQuestion", "AnswerQuestion", quiz);
            return View("QuizTest", quiz);

        }

        // POST: AssessmentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Quiz(int? id, Answer answer)
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

        //GET: AssessmentsController/Delete/5
        //public IActionResult QuizStart(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var applicant = _context.Applicants.Where(a => a.IdentityUserId == userId).SingleOrDefault();

        //    if (applicant == null)
        //    {
        //        return NotFound();
        //    }

        //    AssessmentViewModel assessmentViewModel = new AssessmentViewModel();

        //    var assessment = _context.Assessments.Where(a => a.AssessmentId == id).SingleOrDefault();

        //    if (assessment == null)
        //    {
        //        return NotFound();
        //    }

        //    var question = _context.Questions.Where(q => q.AssessmentId == assessment.AssessmentId).ToList();
        //    if (question == null)
        //    {
        //        return NotFound();
        //    }

        //    foreach (var answer in question)
        //    {
        //        _context.Answers.Where(a => a.Question.QuestionId == answer.QuestionId).ToList();
        //    }
        //    assessmentViewModel.Questions = question;

        //    var answers = _context.Answers.Where(a => a.AnswerId == question.AnswerId).ToList();
        //    var answers = _context.Assessments.Where(a => a.AssessmentId == assessment.AssessmentId)
        //    var answers = _context.Answers.Where(a => a.Question.Assessment.AssessmentId == id).ToList();
        //    .Include(a => a.)
        //    assessmentViewModel.Answers = answers;


        //    return View(assessmentViewModel);
        //}

        //POST: AssessmentsController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult QuizStart(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

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
        
        // GET
        public ActionResult Score(int id)
        {
            return View();
        }

        // POST: AssessmentsController/Score/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Score(int id, IFormCollection collection)
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
