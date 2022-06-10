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

       

        public virtual Account account { set; get; }
        public virtual Education education { set; get; }

    }
}
