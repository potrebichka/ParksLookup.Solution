using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ParksLookup.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        [HttpGet]
        public IActionResult View()
        {
            return Ok("You can view invoices!");
        }

        [Authorize(Roles = "Administrator,Accountant")]
        [HttpGet]
        public IActionResult Create()
        {
            var userIdClaim = HttpContext.User.Claims.Where(x => x.Type == "userid").SingleOrDefault();
            return Ok($"Your User ID is {userIdClaim.Value} and you can create invoices!");
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult Delete()
        {
            var userIdClaim = HttpContext.User.Claims.Where(x => x.Type == "userid").SingleOrDefault();
            return Ok($"Your User ID is {userIdClaim.Value} and you can delete invoices!");
        }
    }
}
