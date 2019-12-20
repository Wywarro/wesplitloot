using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OAuth;

namespace wesplitlootapi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OAuthController : ControllerBase
    {
        [HttpGet]
        [Route("callback")]
        public ClaimsPrincipal Callback()
        {
            return User;
        }
    }
}