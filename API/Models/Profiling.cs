using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Profiling
    {
        [Key]
        [Required]
        [ForeignKey("NIK")]
        public string NIK { set; get; }

       

        public Account account { set; get; }
        public Education education { set; get; }

    }
}
