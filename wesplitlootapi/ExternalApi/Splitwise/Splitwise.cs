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
            var client = new RestClient("https://secure.splitwise.com/oauth/token?" +
                $"client_id={ClientId}&" +
                $"client_secret={ClientSecret}&" +
                "grant_type=client_credentials&" +
                $"code={code}")
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            Token token = JsonConvert.DeserializeObject<Token>(response.Content);

            return token.AccessToken;
        }

        public string GetCurrentUser() 
        {
            RestClient client = new RestClient($"{BaseApiUrl}/get_current_user");
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            return response.Content;
        }
    }

    public class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }
}
