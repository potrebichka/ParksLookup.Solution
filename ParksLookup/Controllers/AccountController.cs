using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParksLookup.Dtos;
using ParksLookup.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ParksLookup.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public IActionResult Login(LoginDto loginDto)
        {
            var jwtToken = _accountService.Login(loginDto);

            if (jwtToken == null)
            {
                return Unauthorized();
            }

            return Ok(jwtToken);
        }
    }
}