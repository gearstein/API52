﻿using API52.Base;
using API52.Models;
using API52.Repository.Data;
using API52.ViewModel;
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
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        private readonly AccountRepository accountrepository;
        public AccountsController(AccountRepository accountRepository) : base(accountRepository)
        {
            this.accountrepository = accountRepository;
        }
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(LoginVM loginVM)
        {
            try
            {
                var insert = accountrepository.Login(loginVM);
                if (insert == 1)
                {
                    var get = Ok(new { status = HttpStatusCode.OK, result = insert, messasge = "Login Success" });
                    return get;
                }
                else
                {
                    return NotFound(new
                    {
                        status = HttpStatusCode.NotFound,
                        result = insert,
                        messasge = "nik/password yang anda masukkan tidak sesuai dengan data didatabase"
                    });
                }
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    status = HttpStatusCode.NotFound,
                    result = 0,
                    messasge = "nik/password yang anda masukkan tidak sesuai dengan data didatabase"
                });
            }
        }
    }
}