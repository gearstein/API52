using API52.Context;
using API52.Models;
using API52.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API52.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MyContext myContext;
        public EmployeeRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Delete(string nik)
        {
            var find = myContext.Employees.FirstOrDefault(e => e.NIK == nik);
            if (find == null) return 0;
            myContext.Employees.Remove(find);
            return myContext.SaveChanges();
        }

        public IEnumerable<Employee> Get()
        {
            var employee = myContext.Employees.ToList();
            if (employee == null) return null;
            return employee;
        }

        public Employee Get(string nik)
        {
            return myContext.Employees.Find(nik);
        }

        public int Insert(Employee e)
        {
            myContext.Employees.Add(e);
            var insert = myContext.SaveChanges();
            return insert;
        }

        public int Update(Employee e, string nik)
        {
            var employee = myContext.Employees.Single(e => e.NIK == nik);
            if (employee != null)
            {
                employee.FirstName = e.FirstName;
                employee.LastName = e.LastName;
                employee.Email = e.Email;
                employee.PhoneNumber = e.PhoneNumber;
                employee.Salary = e.Salary;
                employee.BirthDate = e.BirthDate;
            }
            //var employee = myContext.Employees.Find(nik);
            //if (employee.FirstName != null) employee.FirstName = e.FirstName;
            //if (employee.LastName != null) employee.LastName = e.LastName;
            //if (employee.Email != null) employee.Email = e.Email;
            //if (employee.PhoneNumber != null) employee.PhoneNumber = e.PhoneNumber;
            //if (employee.Salary != 0) employee.Salary = e.Salary;
            //if (employee.BirthDate != null) employee.BirthDate = e.BirthDate;
            myContext.Entry(employee).State = EntityState.Modified;
            var update = myContext.Update(employee);
            return myContext.SaveChanges();
        }
    }
}
