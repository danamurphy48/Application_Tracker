using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTracker.Models
{
    public class Interview
    {
        [Key]
        public int InterviewId { get; set; }
        [Display(Name = "Date & Time of Interview")]
        public DateTime DateTime { get; set; }
        //public string InterviewDate { get; set; }
        //public string InterviewTime { get; set; }
        [Display(Name ="Interview Type")]
        public string InterviewType { get; set; }
        [Display(Name = "Interview Location")]
        public string InterviewLocation { get; set; }
        [Display(Name = "Interview Round")]
        public int? InterviewRound { get; set; }
        [Display(Name = "Thank you notes sent?")]
        public bool ThankYouNote { get; set; }
        [Display(Name = "Questions to Ask during Interview / Notes")]
        public string Notes { get; set; }

        [ForeignKey("Application")]
        public int ApplicationId { get; set; }
        public Application Application { get; set; }

        [ForeignKey("HiringManager")]
        public int? HiringManagerId { get; set; }
        public HiringManager HiringManager { get; set; }
        
        [ForeignKey("Interviewer")]
        public int? InterviewerId { get; set; }
        public Interviewer Interviewer { get; set; }
    }
}
