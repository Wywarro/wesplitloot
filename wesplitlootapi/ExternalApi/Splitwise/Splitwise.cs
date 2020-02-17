using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace wesplitlootapi.ExternalApi.Splitwise
{
    public class Splitwise
    {
        public const string TOKEN_ENDPOINT = "https://secure.splitwise.com/oauth/token";
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string BaseApiUrl { get; set; }

        public Splitwise() 
        {
            ClientId = Environment.GetEnvironmentVariable("SPLITWISE_CLIENT_ID");
            ClientSecret = Environment.GetEnvironmentVariable("SPLITWISE_CLIENT_SECRET");

            BaseApiUrl = "https://www.splitwise.com/api/v3.0";
        }

        public string GetToken(string code)
        {
            Requests tokenRequest = new Requests($"{TOKEN_ENDPOINT}?" +
                $"client_id={ClientId}&" +
                $"client_secret={ClientSecret}&" +
                "grant_type=client_credentials&" +
                $"code={code}", "no-token");

            tokenRequest.RestClient.Timeout = -1;

            Token token = JsonConvert.DeserializeObject<Token>(tokenRequest.ReadRequest());

            return token.AccessToken;
        }

        public string GetCurrentUser(string token)
        {
            Requests userRequest = new Requests($"{BaseApiUrl}/get_current_user", token);

            return userRequest.ReadRequest();
        }
    }
}
