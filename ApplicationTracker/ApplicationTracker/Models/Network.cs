using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTracker.Models
{
    public class Network
    {
        [Key]
        public int NetworkId { get; set; }
        [Display(Name ="First Name")]
        public string NetworkFirstName { get; set; }
        [Display(Name ="Last Name")]
        public string NetworkLastName { get; set; }
        [Display(Name ="Contact's Job Title")]
        public string NetworkPosition { get; set; }
    }
}
