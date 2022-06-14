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
        public University()
        {
            educations = new HashSet<Education>();
        }
        [Key]
        [Required]
        [ForeignKey("id")]
        public int id { set; get; }
        public string nama { set; get; }

        public virtual ICollection<Education> educations {set;get;}

        
    }
}
