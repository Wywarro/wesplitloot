using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace wesplitlootapi.Controllers
{
    [Route("api/v1/authenticate")]
    [ApiController]
    public class SplitwiseController : ControllerBase
    {
        [HttpGet]
        public IActionResult Login(string returnUrl = "http://localhost:8081")
        {
            return Challenge(new AuthenticationProperties() { RedirectUri = returnUrl });
        }
    }
}