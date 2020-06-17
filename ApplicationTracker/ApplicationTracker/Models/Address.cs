using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTracker.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        [Display(Name ="Street Address")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name ="Zip Code")]
        public int? ZipCode { get; set; }
    }
}
