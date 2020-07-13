using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTracker.Models
{
    public class AssessmentViewModel
    {
        public List<Question> Questions { get; set; } 
        public List<Answer> Answers { get; set; }
    }
}
