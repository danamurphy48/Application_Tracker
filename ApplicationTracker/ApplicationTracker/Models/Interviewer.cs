using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTracker.Models
{
    public class Interviewer
    {
        [Key]
        public int InterviewerId { get; set; }
        [Display(Name ="Interviewer - First Name")]
        public string FirstName { get; set; }
        [Display(Name ="Interviewer - Last Name")]
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Display(Name = "Interviewer - Notes")]
        public string Notes { get; set; }
    }
}
