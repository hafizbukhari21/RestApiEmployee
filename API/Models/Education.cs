using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Education
    {

        public Education()
        {
            profiling = new HashSet<Profiling>();
        }

        [Key]
        public int id { set; get; }

        [Required]
        public Degree  degree { set; get; }

        [Required]
        public string GPA { set; get; }

      

        public  virtual ICollection<Profiling> profiling { set; get; }

        public virtual University university { set; get; }

       



    }

    public enum Degree
    {
        D3,
        D4,
        S1,
        S2,
        S3
    }


}
