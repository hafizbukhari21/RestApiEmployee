using API.Contex;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class UniversityRepository : GeneralRepository<MyContext, University, int>
    {
        public MyContext context;
        public UniversityRepository(MyContext myContext) : base(myContext)
        {
            this.context = myContext;
        }


        public University GetUniversityById(int id)
        {
            return context.University.Find(id);
        }
    }
}
