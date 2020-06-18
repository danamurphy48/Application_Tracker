﻿using System;
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
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
       // [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}