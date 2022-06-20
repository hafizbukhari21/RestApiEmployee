using API.Contex;
using API.Models;
using API.ViewModel;
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using API.Utils;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<MyContext, Employee, string>
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
                NIK = DateTime.Now.ToString("MMddyyyy") + GetAutoIncrementConvertString(),
                FirstName = registerPegawaiVM.FirstName,
                LastName = registerPegawaiVM.LastName,
                Phone = registerPegawaiVM.Phone,
                BirthDate = registerPegawaiVM.BirthDate,
                Salary = registerPegawaiVM.Salary,
                Email = registerPegawaiVM.Email,
                Gender = (Gender)Enum.Parse(typeof(Gender), registerPegawaiVM.Gender),
                account = new Account
                {
                    password = Tools.BCryptHasing(registerPegawaiVM.password),
                    profiling = new Profiling
                    {
                        education = new Education
                        {
                            degree = (Degree)Enum.Parse(typeof(Degree), registerPegawaiVM.Degree),
                            GPA = registerPegawaiVM.gpa,
                            university = universityRepository.GetUniversityById(registerPegawaiVM.univeristyId)
                        }
                    }
                }
            };

            AccountRole acr = new AccountRole
            {
                nik = emp.NIK,
                idRole = 1
            };
            context.accountRoles.Add(acr);
            context.Add(emp);
            return context.SaveChanges();
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

        //public float Login(LoginPegawaiVM loginPegawaiVM)
        //{
        //    Employee emCkh = context.Employees.Include("account").FirstOrDefault(emp => emp.Email == loginPegawaiVM.email);

        //    if (emCkh.Email != loginPegawaiVM.email) return Variable.EMAIL_NOT_FOUND;// email gk ada
        //    else if (BCrypt.Net.BCrypt.Verify(loginPegawaiVM.password, emCkh.account.password)) return Variable.PASSWORD_NOT_FOUND;//password tidak match

        //    else return 500;

        //}

        public string GetAutoIncrementConvertString()
        {
            Employee emp = context.Employees.ToList().LastOrDefault();
            if (emp == null) return "0000";

            string currentString = emp.NIK.Substring(emp.NIK.Length - 4);
            int currentNIK = Int32.Parse(currentString);

            currentNIK++;
            if (currentNIK >= 1 && currentNIK <= 9) return "000" + currentNIK.ToString();
            else if (currentNIK >= 10 && currentNIK <= 99) return "00" + currentNIK.ToString();
            else if (currentNIK >= 100 && currentNIK <= 999) return "0" + currentNIK.ToString();
            return currentNIK.ToString();



        }



        public Object GetRegisterData()
        {
            return context.Employees.Include(emp => emp.account.profiling.education.university)
                .Select(emp =>
                    new
                    {
                        Nik = emp.NIK,
                        FirstName = emp.FirstName,
                        LastName = emp.LastName,
                        PhoneNumber = emp.Phone,
                        BirthDate = emp.BirthDate,
                        Salary = emp.Salary,
                        Email = emp.Email,
                        Degree = emp.account.profiling.education.degree.ToString(),
                        Gender = emp.Gender.ToString(),
                        GPA = emp.account.profiling.education.GPA,
                        UniveristyName = emp.account.profiling.education.university.nama
                    }
                ).ToList();

        }

        public int UpdateEducation(UpdateUnivVM updateUniv)
        {
            Profiling prof = context.Profilings.Find(updateUniv.nik);

            Education edu = context.Education.Find(prof.education.id);
            edu.GPA = updateUniv.gpa;
            edu.degree = (Degree)Enum.Parse(typeof(Degree), updateUniv.degree);

            context.Education.Update(edu);

            return context.SaveChanges();

        }  


        public int DeleteAlter(string nik)
        {
            AccountRole acr = context.accountRoles.FirstOrDefault(acr => acr.nik == nik);
            context.accountRoles.Remove(acr);

            context.SaveChanges();

            Employee emp = context.Employees.Find(nik);
            context.Employees.Remove(emp);

            return context.SaveChanges();
        }

        
        public static Models.Degree CheckDegree(int degree)
        {
            switch (degree)
            {
                case 1:
                    return Models.Degree.D3;

                case 2:
                    return Models.Degree.D4;
                case 3:
                    return Models.Degree.S1;
                case 4: 
                    return Models.Degree.S2;
                case 5:
                    return Models.Degree.S3;
                default:
                    return 0;

            }
        }







    }
}
