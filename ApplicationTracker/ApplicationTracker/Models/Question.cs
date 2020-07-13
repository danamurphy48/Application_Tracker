using Microsoft.CodeAnalysis.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTracker.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        [Display(Name = "Question")]
        public string QuestionPrompt { get; set; }

        [ForeignKey("Assessment")]
        public int AssessmentId { get; set; }
        public Assessment Assessment { get; set; }

        [NotMapped]
        public List<Answer> Answers { get; set; }
    }
}
