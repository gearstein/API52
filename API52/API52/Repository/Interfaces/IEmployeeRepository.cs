using API52.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API52.Repository.Interfaces
{
    interface IEmployeeRepository
    {
        IEnumerable<Employee> Get(); //Sama seperti List (menampung banyak data tabel employee)
        Employee Get(string nik); //hanya dapat menampung satu data tabel employee
        int Insert(Employee e);
        int Update(Employee e, string nik);
        int Delete(string nik);
    }
}
