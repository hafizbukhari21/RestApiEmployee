﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Account
    {
        [Key]
        [Required]
        [ForeignKey("NIK")]
        public string NIK { set; get; }
        
        [Required]
        public string password { set; get; } 



        public Employee employee { set; get; }
        public Profiling profiling { set; get; }
    }
}
