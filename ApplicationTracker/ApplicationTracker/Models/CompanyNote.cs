using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTracker.Models
{
    public class CompanyNote
    {
        [Key]
        public int CompanyNotesId { get; set; }
        public string Description { get; set; }
        public string Product { get; set; }
        public string Culture { get; set; }
        [Display(Name ="Recent News")]
        public string RecentNews { get; set; }
        public string Charity { get; set; }
    }
}
