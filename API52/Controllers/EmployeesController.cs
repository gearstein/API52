using API52.Base;
using API52.Models;
using API52.Repository.Data;
using API52.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API52.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class EmployeesController : BaseController<Employee,EmployeeRepository,string>
    {
        private readonly EmployeeRepository employeerepository;
        public EmployeesController(EmployeeRepository employeeRepository) : base(employeeRepository)
        {
            this.employeerepository = employeeRepository;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public ActionResult Register(RegisterVM registerVM)
        {
            try
            {
                var insert = employeerepository.Register(registerVM);
                if (insert > 2)
                {
                    var get = Ok(new { status = HttpStatusCode.OK, result = insert, messasge = "Register Success" });
                    return get;
                }
                else if (insert == 2)
                {
                    var get = BadRequest(new { status = HttpStatusCode.BadRequest, result = insert, messasge = "Email Sudah Terdaftar" });
                    return get;
                }
                else if (insert == 1)
                {
                    var get = BadRequest(new { status = HttpStatusCode.BadRequest, result = insert, messasge = "NIK Sudah Terdaftar" });
                    return get;
                }
                else
                {
                    var get = BadRequest(new { status = HttpStatusCode.BadRequest, result = insert, messasge = "Gagal Register" });
                    return get;
                }
            }
            catch (Exception)
            {
                var get = BadRequest(new { status = HttpStatusCode.BadRequest, result = 0, messasge = "Gagal Register" });
                return get;
            }
        }
        //[Authorize]
        [HttpGet("ViewRegister")]
        public ActionResult ViewRegister()
        {
            try
            {
                var get = employeerepository.ViewRegister();
                if (get == null)
                    return NotFound(new { status = HttpStatusCode.NotFound, result = get, messasge = "Not Found" });
                return Ok(new { status = HttpStatusCode.OK, result = get, messasge = "Success" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //[Authorize]
        [HttpGet("Find/{nik}")]
        public ActionResult FindRegister(string NIK)
        {
            var response = employeerepository.FindRegister(NIK);
            if (NIK == null)
            {
                var get = NotFound(new { status = HttpStatusCode.NotFound, result = response, messasge = "Not Found" });
                return get;
            }
            else
            {
                var get = Ok(new { status = HttpStatusCode.OK, result = response, messasge = "Success" });
                return get;
            }
        }
    }
}
