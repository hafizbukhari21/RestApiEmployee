using API.Contex;
using API.Models;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class EmployeeRepositoryOld : IEmployeeRepository
    {
        private readonly MyContext contex;
        public EmployeeRepositoryOld(MyContext contex)
        {
            this.contex = contex;
        }
        public int Delete(string NIK)
        {
            var entity = contex.Employees.Find(NIK);
            contex.Remove(entity);
            return contex.SaveChanges();
        }

        public IEnumerable<Employee> Get()
        {
            return contex.Employees.ToList();
        }


        public Employee Get(string NIK)
        {
            return contex.Employees.Find(NIK);
        }

        public Employee GetFirst(string paramternama)
        {
            return contex.Employees.First(emp => emp.FirstName == paramternama);
        }

        public Employee GetFirstOrDefault(string paramternama)
        {
            return contex.Employees.FirstOrDefault(emp => emp.FirstName == paramternama);
        }

        public Employee GetLast(string paramternama)
        {
            return contex.Employees.ToList().Last(emp => emp.FirstName == paramternama);
        }

        public Employee GetLastOrDefault(string paramternama)
        {
            return contex.Employees.ToList().LastOrDefault(emp => emp.FirstName == paramternama);
        }

        public Employee GetFind(string parameternama)
        {
            return contex.Employees.Find(parameternama);
        }

        public IEnumerable<Employee> GetWithWhere(string parameterNama)
        {
            return contex.Employees.Where(emp => emp.FirstName.Contains(parameterNama)).ToList();
        }

        public Employee GetSingle(string parameternama)
        {
            return contex.Employees.ToList().Single(emp => emp.FirstName == parameternama);
        }


        public Employee GetSingleOrDefault(string parameternama) {
            return contex.Employees.SingleOrDefault(emp => emp.FirstName == parameternama);
        }

        public int Insert(Employee employee)
        {
                contex.Employees.Add(employee);
                var result = contex.SaveChanges();
                return result;
            
        }

        public int Update(Employee employee )
        {

            contex.Entry(employee).State = EntityState.Modified;
            return contex.SaveChanges();
        }


    }
}
