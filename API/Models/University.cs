using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class University
    {
        [Key]
        [Required]
        [ForeignKey("id")]
        public int id { set; get; }
        public string nama { set; get; }

        public ICollection<Education> educations {set;get;}

        
    }
}
