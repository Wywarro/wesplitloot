using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using wesplitlootapi.ExternalApi.Splitwise;

namespace wesplitlootapi.Controllers
{
    [Route("accounts/splitwise")]
    [ApiController]
    public class SplitwiseLoginController : ControllerBase
    {
        [HttpGet]
        [Route("login")]
        public IActionResult Login(string returnUrl = "http://localhost:8080")
        {
            return Challenge(new AuthenticationProperties() { RedirectUri = returnUrl });
        }

        [HttpGet]
        [Route("callback")]
        public IActionResult Callback(string code, string redirectUrl)
        {
            Splitwise splitwise = new Splitwise();

            string token = splitwise.GetToken(code);
            return Redirect($"http://localhost:8080/accounts/splitwise/token-handler?t={token}");
        }

        [HttpPost]
        [Route("token")]
        public string Token(string code)
        {
            //var code = this.Request.Query.FirstOrDefault(x => x.Key == "code").Value;
            Splitwise splitwise = new Splitwise();

            string token = splitwise.GetToken(code);

            return token;
        }
    }
}