using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTracker.Models
{
    public class HiringManager
    {
        [Key]
        public int HiringManagerId { get; set; }
        public string Name { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public EmailAddressAttribute Email { get; set; }
    }
}