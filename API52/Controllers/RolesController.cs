using API52.Base;
using API52.Models;
using API52.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API52.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class RolesController : BaseController<Role, RoleRepository, int>
    {
        public RolesController(RoleRepository roleRepository) : base(roleRepository)
        {

        }
    }
}
