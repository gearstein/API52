using API52.Context;
using API52.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API52.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<MyContext,Employee,string>
    {
        public EmployeeRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
