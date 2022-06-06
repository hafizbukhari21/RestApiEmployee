using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Role
    {
        [Key]
        public int idRole { set; get; }
        public string nama_role { set; get; }

        public ICollection<AccountRole> accountRole { set; get; } 
    }
}
