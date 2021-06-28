using API52.Context;
using API52.ViewModel;
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
    public class TokenController : ControllerBase
    {
        public IConfiguration configuration;
        private readonly MyContext myContext;

        public TokenController(IConfiguration config, MyContext context)
        {
            this.configuration = config;
            this.myContext = context;
        }

        [HttpPost]
        public IActionResult Post(LoginVM loginVM)
        {
            var alternatif = myContext.Accounts.Find(loginVM.NIK);
            if (alternatif != null)
            {
                var user = myContext.Accounts.FirstOrDefault(a => a.NIK == loginVM.NIK);
                if (user != null && BCrypt.Net.BCrypt.Verify(loginVM.Password, user.Password))
                {
                    var email = myContext.Employees.Find(user.NIK);
                    var role = myContext.AccountRoles.FirstOrDefault(a => a.NIK == user.NIK);
                    var find = myContext.Roles.Find(role.RoleID);
                    var claims = new[]
                    {
                    new Claim("Email", email.Email),
                    new Claim("role", find.RoleName)
                };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
                    var sigIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"],
                        claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: sigIn);
                    var show = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok((new { status = HttpStatusCode.OK, result = show, messasge = "Login Berhasil" }));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                var user = myContext.Employees.FirstOrDefault(a => a.Email == loginVM.NIK);
                var akun = myContext.Accounts.Find(user.NIK);
                if (user != null && BCrypt.Net.BCrypt.Verify(loginVM.Password, akun.Password))
                {
                    var email = myContext.Employees.Find(user.NIK);
                    var role = myContext.AccountRoles.FirstOrDefault(a => a.NIK == user.NIK);
                    var find = myContext.Roles.Find(role.RoleID);
                    var claims = new[]
                    {
                    new Claim("Email", email.Email),
                    new Claim("role", find.RoleName)
                };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
                    var sigIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"],
                        claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: sigIn);
                    var show = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok((new { status = HttpStatusCode.OK, result = show, messasge = "Login berhasil" }));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
        }
    }
}
