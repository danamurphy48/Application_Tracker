using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("Application")]
        public int ApplicationId { get; set; }
        public Application Application { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [ForeignKey("HiringManager")]
        public int HiringManagerId { get; set; }
        public HiringManager HiringManager { get; set; }

        [ForeignKey("CompanyNotes")]
        public int CompanyNotesId { get; set; }
        public CompanyNotes CompanyNotes { get; set; }
    }
}
