using API52.Models;
using API52.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API52.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesControllerLama : ControllerBase
    {
        //private EmployeeRepository employeerepository;
        //public EmployeesControllerLama(EmployeeRepository employeerepository)
        //{
        //    this.employeerepository = employeerepository;
        //}
        //[HttpGet]
        //public ActionResult Get()
        //{
        //    try
        //    {
        //        var get = employeerepository.Get();
        //        if (get == null)
        //            return NotFound(new { status = HttpStatusCode.NotFound, result = get, messasge = "Not Found" });
        //        return Ok(new { status = HttpStatusCode.OK, result = get, messasge = "Success" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}
        //[HttpGet("/API/Employees/{nik}")]
        //public ActionResult Find(string Nik)
        //{
        //    var response = employeerepository.Get(Nik);
        //    if (Nik == null)
        //    {
        //        var get = NotFound(new { status = HttpStatusCode.NotFound, result = response, messasge = "Not Found" });
        //        return get;
        //    }
        //    else
        //    {
        //        var get = Ok(new { status = HttpStatusCode.OK, result = response, messasge = "Success" });
        //        return get;
        //    }
        //}
        //[HttpPost]
        //public ActionResult Post(Employee e)
        //{
        //    var insert = employeerepository.Insert(e);
        //    if (insert == 1)
        //    {
        //        var get = Ok(new { status = HttpStatusCode.OK, result = insert, messasge = "Success" });
        //        return get;
        //    }
        //    else
        //    {
        //        var get = NotFound(new { status = HttpStatusCode.NotFound, result = insert, messasge = "Not Found" });
        //        return get;
        //    }
        //}
        //[HttpDelete]
        //public ActionResult Delete(string Nik)
        //{
        //    var response = employeerepository.Delete(Nik);
        //    if (Nik == null)
        //    {
        //        var get = NotFound(new { status = HttpStatusCode.NotFound, result = response, messasge = "Not Found" });
        //        return get;
        //    }
        //    else
        //    {
        //        if (response == 1)
        //        {
        //            var get = Ok(new { status = HttpStatusCode.OK, result = response, messasge = "Success" });
        //            return get;
        //        }
        //        else
        //        {
        //            var get = NotFound(new { status = HttpStatusCode.NotFound, result = response, messasge = "Not Found" });
        //            return get;
        //        }
        //    }
        //}
        //[HttpPut]
        //public ActionResult Update(Employee employee, string nik)
        //{
        //    var response = employeerepository.Update(employee, nik);
        //    if (nik == null)
        //    {
        //        var get = NotFound(new { status = HttpStatusCode.NotFound, result = response, messasge = "Not Found" });
        //        return get;
        //    }
        //    else
        //    {
        //        if (response == 1)
        //        {
        //            var get = Ok(new { status = HttpStatusCode.OK, result = response, messasge = "Success" });
        //            return get;
        //        }
        //        else
        //        {
        //            var get = NotFound(new { status = HttpStatusCode.NotFound, result = response, messasge = "Not Found" });
        //            return get;
        //        }
        //    }
        //}
    }
}
