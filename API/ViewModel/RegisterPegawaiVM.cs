using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModel
{
    public class RegisterPegawaiVM
    {
      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public DateTime BirthDate{ get; set; }
        public int Salary { get; set; }

        public string Email { get; set; }

        public string Gender { set; get; }
        public string gpa { set; get; }

        public int Degree { set; get; }
 
        public string password { set; get; }

        public bool isDeleted { set; get; }
        public int univeristyId { set; get; }



        //public Employee GetEmployee()
        //{
        //    return new Employee()
        //    {
        //        NIK = "",
        //        FirstName = this.FirstName,
        //        LastName = this.LastName,
        //        Phone = this.Phone,
        //        BirthDate = this.BirthDate,
        //        Salary = this.Salary,
        //        Email = this.Email,
        //        Gender = this.Gender == 1 ? Models.Gender.Female : Models.Gender.Male,
                


        //    };
        //}

        //public Profiling GetProfiling()
        //{
        //    return new Profiling
        //    {
        //        NIK = "",

        //    };
        //}

        //public Education GetEducation()
        //{
        //    return new Education
        //    {

        //    };
        //}

        //public Account GetAccount()
        //{
        //    return new Account()
        //    {
        //        NIK = "",
        //        password = this.password,

        //    };
        //}



        //public static Models.Degree CheckDegree(int degree)
        //{
        //    switch (degree)
        //    {
        //        case 0:
        //            return Models.Degree.D3; break;

        //        case 1:
        //            return Models.Degree.D4; break;
        //        case 2:
        //            return Models.Degree.S1; break;
        //        case 3:
        //            return Models.Degree.S2; break;
        //        case 4:
        //            return Models.Degree.S3; break;
        //        default:
        //            return 0;

        //    }
        //}




    }
}
