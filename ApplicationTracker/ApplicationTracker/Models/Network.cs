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
        [Display(Name ="Name")]
        public string NetworkName { get; set; }
        [Display(Name ="Contact's Job Title")]
        public string NetworkPosition { get; set; }
    }
}
