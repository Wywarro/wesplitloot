using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace wesplitlootapi.Controllers
{
    [Route("api/v1/splitwise/")]
    [ApiController]
    public class SplitwiseApiController : ControllerBase
    {
        [Route("user")]
        public string GetUser()
        {
            return "hello";
        }
    }
}