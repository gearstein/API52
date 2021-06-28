using API52.Base;
using API52.Context;
using API52.Models;
using API52.Repository.Data;
using API52.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API52.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        public IConfiguration configuration;
        private readonly AccountRepository accountrepository;
        private readonly MyContext myContext;
        public AccountsController(MyContext myContext,AccountRepository accountRepository) : base(accountRepository)
        {
            this.accountrepository = accountRepository;
            this.myContext = myContext;
        }
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(LoginVM loginVM)
        {
            try
            {
                var alternatif = accountrepository.Login(loginVM);
                if (alternatif == 1)
                {
                    //var cekEmail = myContext.Employees.FirstOrDefault(a => a.Email == loginVM.NIK);
                    //var cekNIK = myContext.Employees.Find(cekEmail.NIK);
                    //var hasedpassword = myContext.Accounts.Find(cekNIK.NIK);
                    ////var user = myContext.Accounts.FirstOrDefault(b => b.Password == loginVM.Password);
                    //if (cekEmail != null && BCrypt.Net.BCrypt.Verify(loginVM.Password, hasedpassword.Password))
                    //{
                    //    var email = myContext.Employees.Find(cekEmail.NIK);
                    //    var role = myContext.AccountRoles.FirstOrDefault(a => a.RoleID.ToString() == email.NIK);
                    //    var find = myContext.Roles.FirstOrDefault(b => b.RoleID.ToString() == role.NIK);
                    //    var claims = new[]
                    //    {
                    //    new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                    //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    //    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    //    new Claim("FirstName", cekEmail.FirstName),
                    //    new Claim("LastName", cekEmail.LastName),
                    //    new Claim("Email", cekEmail.Email),
                    //    //new Claim("Role", find.RoleName)
                    //    };
                    //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
                    //    var sigIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    //    var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"],
                    //        claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: sigIn);
                    //    var show = new JwtSecurityTokenHandler().WriteToken(token);
                    //    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                    //}
                    //else
                    //{
                    //    return BadRequest("Invalid credentials");
                    //}

                    //var insert = accountrepository.Login(loginVM);
                    //if (insert == 1)
                    //{
                    //var user = myContext.Accounts.FirstOrDefault(a => a.NIK == loginVM.NIK);
                    //var email = myContext.Employees.FirstOrDefault(a => a.Email == loginVM.NIK);
                    //var role = myContext.AccountRoles.FirstOrDefault(a => a.RoleID.ToString() == user.NIK);
                    //var find = myContext.Roles.FirstOrDefault(b => b.RoleID.ToString() == role.NIK);
                    //var claims = new[]
                    //{
                    //new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                    //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    //new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    //new Claim("FirstName", email.FirstName),
                    //new Claim("LastName", email.LastName),
                    //new Claim("Email", email.Email),
                    //new Claim("Role", find.RoleName)
                    //};
                    //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
                    //var sigIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    //var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"],
                    //    claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: sigIn);
                    //var show = new JwtSecurityTokenHandler().WriteToken(token);
                    //return Ok(new JwtSecurityTokenHandler().WriteToken(token));

                    var get = Ok(new { status = HttpStatusCode.OK, result = alternatif, messasge = "Login Success" });
                    return get;

                    //}
                    //else
                    //{
                    //    return NotFound(new
                    //    {
                    //        status = HttpStatusCode.NotFound,
                    //        result = insert,
                    //        messasge = "nik/password yang anda masukkan tidak sesuai dengan data didatabase"
                    //    });
                    //}
                }
                else
                {
                    return BadRequest("Data Kosong");
                }
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    status = HttpStatusCode.NotFound,
                    result = 0,
                    messasge = "Error"
                });
            }
        }
        [HttpPost("Reset")]
        public ActionResult ResetPassword(ForgotVM forgotVM)
        {
            try
            {
                var insert = accountrepository.ResetPassword(forgotVM);
                if (insert == 1)
                {
                    var get = Ok(new { status = HttpStatusCode.OK, result = insert, messasge = "Email Sent" });
                    return get;
                }
                else
                {
                    var get = BadRequest(new { status = HttpStatusCode.OK, result = insert, messasge = "Error" });
                    return get;
                }
            }
            catch (Exception)
            {

                var get = BadRequest(new { status = HttpStatusCode.OK, result = 0, messasge = "Error" });
                return get;
            }
        }
        [HttpPost("Change")]
        public ActionResult ChangePassword(ChangeVM changeVM)
        {
            try
            {
                var insert = accountrepository.ChangePassword(changeVM);
                if (insert == 2)
                {
                    var get = Ok(new { status = HttpStatusCode.OK, result = insert, messasge = "Change Successful" });
                    return get;
                }
                else
                {
                    var get = BadRequest(new { status = HttpStatusCode.OK, result = insert, messasge = "Error" });
                    return get;
                }
            }
            catch (Exception)
            {

                var get = BadRequest(new { status = HttpStatusCode.OK, result = 0, messasge = "Error" });
                return get;
            }
        }
    }
}
