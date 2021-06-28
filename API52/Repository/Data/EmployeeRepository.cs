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
            var cekNIK = context.Employees.Find(registerVM.NIK);
            if (cekNIK == null)
            {
                var cekEmail = context.Employees.FirstOrDefault(a => a.Email == registerVM.Email);
                if (cekEmail == null)
                {
                    //employee
                    var employee = new Employee();
                    employee.NIK = registerVM.NIK;
                    employee.FirstName = registerVM.FirstName;
                    employee.LastName = registerVM.LastName;
                    employee.Gender = (Models.GenderRole)registerVM.Gender;
                    employee.Email = registerVM.Email;
                    employee.BirthDate = registerVM.BirthDate;
                    employee.Salary = registerVM.Salary;
                    employee.PhoneNumber = registerVM.PhoneNumber;
                    context.Employees.Add(employee);
                    context.SaveChanges();

                    //account
                    string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerVM.Password);
                    var role1 = context.Roles.Single(a => a.RoleID == 1);
                    var role2 = context.Roles.Single(a => a.RoleID == 2);
                    var account = new Account()
                    {
                        NIK = employee.NIK,
                        Password = passwordHash,
                        Roles = new List<Role>()
                    };
                    //account.Roles.Add(role1);
                    account.Roles.Add(role1);
                    context.Accounts.Add(account);
                    context.SaveChanges();
                    //account.NIK = registerVM.NIK;
                    //account.Password = registerVM.Password;
                    //string passwordHash = BCrypt.Net.BCrypt.HashPassword(account.Password);
                    //account.Password = passwordHash;

                    //edukasi
                    var edu = context.Educations.SingleOrDefault(b => b.Degree == registerVM.Degree
                        && b.GPA == registerVM.GPA && b.UniversityId == registerVM.UniversityId);
                    int eduid = edu.EducationId;

                    //profilling
                    var profilling = new Profilling();
                    profilling.NIK = registerVM.NIK;
                    profilling.EducationId = eduid;
                    //profilling.EducationId = "select educationid from educationid where degree = register.degree and gpa = register.gpa and universityid = register.universityid"
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
        public IQueryable ViewRegister()
        {
            var register = (from emp in MyContext.Employees
                            join acc in MyContext.Accounts on emp.NIK equals acc.NIK
                            join prof in MyContext.Profillings on acc.NIK equals prof.NIK
                            join edu in MyContext.Educations on prof.EducationId equals edu.EducationId
                            join uni in MyContext.Universities on edu.UniversityId equals uni.UniversityId
                            join acrol in MyContext.AccountRoles on acc.NIK equals acrol.NIK
                            join rol in MyContext.Roles on acrol.RoleID equals rol.RoleID
                            select new
                            {
                                emp.NIK,
                                emp.FirstName,
                                emp.LastName,
                                emp.Gender,
                                emp.BirthDate,
                                emp.Email,
                                emp.PhoneNumber,
                                rol.RoleName,
                                emp.Salary,
                                edu.Degree,
                                edu.GPA,
                                uni.UniversityName
                            });
            return register;
        }
        public IQueryable FindRegister(string NIK)
        {
            var employee = MyContext.Employees.FirstOrDefault(a => a.NIK == NIK);
            if (employee != null)
            {
                var register = (from emp in MyContext.Employees
                                join acc in MyContext.Accounts on emp.NIK equals acc.NIK
                                join prof in MyContext.Profillings on acc.NIK equals prof.NIK
                                join edu in MyContext.Educations on prof.EducationId equals edu.EducationId
                                join uni in MyContext.Universities on edu.UniversityId equals uni.UniversityId
                                join acrol in MyContext.AccountRoles on acc.NIK equals acrol.NIK
                                join rol in MyContext.Roles on acrol.RoleID equals rol.RoleID
                                where emp.NIK == NIK
                                select new
                                {
                                    emp.NIK,
                                    emp.FirstName,
                                    emp.LastName,
                                    emp.Gender,
                                    emp.BirthDate,
                                    emp.Email,
                                    emp.PhoneNumber,
                                    rol.RoleName,
                                    emp.Salary,
                                    edu.Degree,
                                    edu.GPA,
                                    uni.UniversityName
                                });
                return register;
            }
            else
            {
                return null;
            }
        }
    }
}
