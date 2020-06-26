using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTracker.Models
{
    public class Assessment
    {
        [Key]
        public int AssessmentId { get; set; }
        public string AssessmentName { get; set; }
        public double Score { get; set; }
      
        [ForeignKey("Applicant")]
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
}
