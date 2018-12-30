﻿using Indio.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Indio.Controllers
{
    [Authorize(Roles = "Account")]
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {

        private readonly IAccountsServices _accountsServices;

        public AccountsController(IAccountsServices accountsServices)
        {
            _accountsServices = accountsServices;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            var result = _accountsServices.GetAccounts();
            return Ok(result);
        }

        
    }
}