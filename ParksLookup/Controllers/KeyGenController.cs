using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ParksLookup.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KeyGenController : ControllerBase
    {
        [HttpGet]
        public IActionResult GenerateKey()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var key = new byte[64];
                rng.GetBytes(key);
                return Ok(Convert.ToBase64String(key));
            }
        }
    }
}