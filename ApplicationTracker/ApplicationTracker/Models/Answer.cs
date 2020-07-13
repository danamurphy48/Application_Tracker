using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTracker.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        [Display(Name = "Answer")]
        public string AnswerQuestion { get; set; }
        [Display(Name = "Correct")]
        public bool IsCorrect { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
