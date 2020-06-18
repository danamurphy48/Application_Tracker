using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTracker.Models
{
    public class Application
    {
        [Key]
        public int ApplicationId { get; set; }
        [Display(Name ="Position Title")]
        public int PositionTitle { get; set; }
        [Display(Name ="Date Applied")]
        public DateTime DateApplied { get; set; }
        [Display(Name ="Resume Used - File Name")]
        public string ResumeUsed { get; set; }
        [Display(Name ="Cover Letter Used - File Name")]
        public string CoverLetter { get; set; }
        [Display(Name = "Salary Requested")]
        public double? SalaryRequested { get; set; }
        [Display(Name = "Job Requisition Number")]
        public double? RequistionNumber { get; set; }
        [Display(Name ="Link to Job Posting")]
        public string JobUrl { get; set; }
        [Display(Name ="Application Status")]
        public string ApplicationStatus { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        
        [ForeignKey("Network")]
        public int NetworkId { get; set; }
        public Network Network { get; set; }

        [ForeignKey("Applicant")]
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
        
        [ForeignKey("JobInformation")]
        public int JobInfoId { get; set; }
        public JobInformation JobInformation { get; set; }
    }
}
