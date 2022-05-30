using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    interface IEmployeeRepository
    {
        IEnumerable<Employee> Get();
        Employee Get(string NIK);

        Employee GetFirstOrDefault(string NIK);
        Employee GetFirst(string NIK);
        Employee GetLastOrDefault(string NIK);
        Employee GetLast(string NIK);

        Employee GetSingle(string parameternama);
        Employee GetSingleOrDefault(string parameternama);




        IEnumerable<Employee> GetWithWhere(string parameterNama);
        int Insert(Employee employee);
        int Update(Employee employee);
        int Delete(string NIK);
    }
}
