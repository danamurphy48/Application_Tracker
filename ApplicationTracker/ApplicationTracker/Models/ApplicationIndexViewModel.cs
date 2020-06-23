using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTracker.Models
{
    public class ApplicationIndexViewModel
    {
        public List<Application> UpcomingApplications { get; set; }
        public List<Interview> UpcomingInterviews { get; set; }
    }
}
