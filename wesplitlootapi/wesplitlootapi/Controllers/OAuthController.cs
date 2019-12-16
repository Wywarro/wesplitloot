using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OAuth;

namespace wesplitlootapi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OAuthController : ControllerBase
    {
        private Manager oauth = new OAuth.Manager();

        private void SetManagerProps()
        {
            string CONSUMER_KEY = "Kq8swWewdB1bmdgtzQWQi6xhOieXZKswHtrYJ4oO";
            string CONSUMER_SECRET = "ivx8gNdg0syYjSZORO0Ls30TpzaIk4CNuoTyuDwK";

            oauth["consumer_key"] = CONSUMER_KEY;
            oauth["consumer_secret"] = CONSUMER_SECRET;
        }

        [HttpPost]
        [Route("login")]
        public object Login()
        { 
            string REQUEST_TOKEN_URL = "https://secure.splitwise.com/oauth/request_token";
            string AUTHORIZE_URL = "https://secure.splitwise.com/oauth/authorize";

            SetManagerProps();

            oauth.AcquireRequestToken(REQUEST_TOKEN_URL, "POST");

            string url = $"{AUTHORIZE_URL}?oauth_token=" + oauth["token"];

            return Ok(new { url });
        }

        [HttpGet]
        [Route("callback")]
        public string Callback()
        {
            return "hello";
        }
    }
}