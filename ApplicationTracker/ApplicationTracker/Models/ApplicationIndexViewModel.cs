using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTracker.Models
{
    public class ApplicationIndexViewModel
    {
        //public Address Address { get; set; }
        //public Applicant Applicant { get; set; }
        //public Application Application { get; set; }
        //public Company Company { get; set; }
        //public CompanyNote CompanyNote { get; set; }
        //public HiringManager HiringManager { get; set; }
        //public Interview Interview { get; set; }
        //public Interviewer Interviewer { get; set; }
        //public JobInformation JobInformation { get; set; }
        //public Network Network { get; set; }
        public List<Application> UpcomingApplications { get; set; }
        public List<Interview> UpcomingInterviews { get; set; }
    }
}
