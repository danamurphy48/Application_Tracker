using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTracker.Models
{
    public class JobInformation
    {
        [Key]
        public int JobInfoId { get; set; }
        [Display(Name = "First, Second, or Third Shift?")]
        public string Shift { get; set; }
        [Display(Name = "Full-Time or Part-Time")]
        public string FullTime { get; set; }
        [Display(Name ="Contract or Contract to Hire?")]
        public string Contract { get; set; }
        [Display(Name ="Do you know the position's salary (range)?")]
        public string JobSalary { get; set; }
        [Display(Name ="Summary of Position")]
        public string PositionSummary { get; set; }
    }
}
