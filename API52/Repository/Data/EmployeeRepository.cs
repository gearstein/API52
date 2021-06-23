using API52.Context;
using API52.Models;
using API52.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API52.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<MyContext,Employee,string>
    {
        private readonly MyContext context;
        public EmployeeRepository(MyContext myContext) : base(myContext)
        {
            this.context = myContext;
        }
        public int Register(RegisterVM registerVM)
        {
            var employee = new Employee();
            var account = new Account();
            var profilling = new Profilling();

            var cekNIK = context.Employees.Find(registerVM.NIK);
            if (cekNIK == null)
            {
                var cekEmail = context.Employees.FirstOrDefault(a => a.Email == registerVM.Email);
                if (cekEmail == null)
                {
                    employee.NIK = registerVM.NIK;
                    employee.FirstName = registerVM.FirstName;
                    employee.LastName = registerVM.LastName;
                    employee.Gender = (Models.GenderRole)registerVM.Gender;
                    employee.Email = registerVM.Email;
                    employee.BirthDate = registerVM.BirthDate;
                    employee.Salary = registerVM.Salary;
                    employee.PhoneNumber = registerVM.PhoneNumber;
                    account.NIK = registerVM.NIK;
                    account.Password = registerVM.Password;
                    var edu = context.Educations.SingleOrDefault(b => b.Degree == registerVM.Degree
                        && b.GPA == registerVM.GPA && b.UniversityId == registerVM.UniversityId);
                    int eduid = edu.EducationId;
                    profilling.NIK = registerVM.NIK;
                    profilling.EducationId = eduid;
                    string passwordHash = BCrypt.Net.BCrypt.HashPassword(account.Password);
                    account.Password = passwordHash;
                    //profilling.EducationId = "select educationid from educationid where degree = register.degree and gpa = register.gpa and universityid = register.universityid"
                    context.Employees.Add(employee);
                    context.Accounts.Add(account);
                    context.Profillings.Add(profilling);
                    var insert = context.SaveChanges();
                    return insert;
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                return 1;
            }
        }
    }
}
