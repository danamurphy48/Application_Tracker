using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTracker.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [Display(Name = "Company")]
        public string CompanyName { get; set; }
        [Display(Name ="Office Location")]
        public string OfficeLocation { get; set; }
    }
}
