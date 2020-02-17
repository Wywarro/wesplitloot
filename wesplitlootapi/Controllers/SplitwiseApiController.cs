using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using wesplitlootapi.ExternalApi.Splitwise;

namespace wesplitlootapi.Controllers
{
    [Route("api/v1/splitwise/")]
    [ApiController]
    public class SplitwiseApiController : ControllerBase
    {
        [Route("user")]
        public ActionResult GetUser()
        {
            Splitwise splitwise = new Splitwise();
            string authorizationHeader = Request.Headers["Authorization"];
            if (!authorizationHeader.Contains("Bearer"))
            {
                return BadRequest("No token passed");
            }
            string token = authorizationHeader.Substring(7);
            string user = splitwise.GetCurrentUser(token);

            return Ok(user);
        }
    }
}