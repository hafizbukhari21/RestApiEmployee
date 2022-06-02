using API.Contex;
using API.Models;
using API.ViewModel;
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<MyContext,Employee,string>
    {
        public MyContext context;
        
        public EmployeeRepository(MyContext myContext) : base(myContext)
        {
            this.context = myContext;
        }

        public int GetRegister(RegisterPegawaiVM registerPegawaiVM)
        {

            UniversityRepository universityRepository = new UniversityRepository(context);
            Employee emp = new Employee
            {
                NIK =DateTime.Now.ToString("MMddyyyy")+" "+ GetAutoIncrementConvertString(),
                FirstName = registerPegawaiVM.FirstName,
                LastName = registerPegawaiVM.LastName,
                Phone = registerPegawaiVM.Phone,
                BirthDate = registerPegawaiVM.BirthDate,
                Salary = registerPegawaiVM.Salary,
                Email = registerPegawaiVM.Email,
                Gender = registerPegawaiVM.Gender == 1 ? Models.Gender.Female : Models.Gender.Male,
                account = new Account
                {
                    password = BCryptHasing(registerPegawaiVM.password),
                    profiling = new Profiling
                    {
                        education = new Education
                        {
                            degree = CheckDegree(registerPegawaiVM.Degree),
                            GPA = registerPegawaiVM.gpa,
                            university = universityRepository.GetUniversityById(registerPegawaiVM.univeristyId)
                        }
                    }
                }
            };

            context.Add(emp);
            return context.SaveChanges();
        }

        public string BCryptHasing(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }

        public bool EmailIsUsed(string Email)
        {
            Employee emp = context.Employees.FirstOrDefault(emp => emp.Email == Email);
            return emp != null; 
        }

        public bool PhoneIsUsed(string phone)
        {
            Employee emp = context.Employees.FirstOrDefault(emp => emp.Phone == phone);
            return emp != null;
        }

        public string GetAutoIncrementConvertString()
        {
            Employee emp = context.Employees.ToList().LastOrDefault();
            if(emp == null) return "0000";

            string currentString = emp.NIK.Substring(emp.NIK.Length - 4);
            int currentNIK = Int32.Parse(currentString);

            currentNIK++;
            if (currentNIK >= 1 && currentNIK <= 9) return "000" + currentNIK.ToString();
            else if(currentNIK >= 10 && currentNIK <= 99) return "00" + currentNIK.ToString();
            else if (currentNIK >= 100 && currentNIK <= 999) return "0" + currentNIK.ToString();
            return  currentNIK.ToString();


            
        }


        public static Models.Degree CheckDegree(int degree)
        {
            switch (degree)
            {
                case 1:
                    return Models.Degree.D3; break;

                case 2:
                    return Models.Degree.D4; break;
                case 3:
                    return Models.Degree.S1; break;
                case 4:
                    return Models.Degree.S2; break;
                case 5:
                    return Models.Degree.S3; break;
                default:
                    return 0;

            }
        }







    }
}
