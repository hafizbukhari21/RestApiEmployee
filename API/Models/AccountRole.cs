using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class AccountRole
    {
    
        [Key]
        public int id { set; get; }

        public int idRole { set; get; }

        public string nik { set; get; }

        public virtual Account account { set; get; }
        public virtual Role role { set; get; }
        





       
    }
}
