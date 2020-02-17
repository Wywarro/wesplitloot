using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wesplitlootapi.ExternalApi
{
    public class Requests
    {
        public const string JSON = "application/json";
        public const string FORM_URLENCODED = "application/x-www-form-urlencoded";
        public const string OCTET_STREAM = "application/octet-stream";
        public const string FORM_DATA = "multipart/form-data";

        public RestClient RestClient { get; set; }
        public string Token { get; set; }

        public Requests(string url, string token)
        {
            RestClient = new RestClient(url);
            Token = token;
        }

        public string CreateUpdateRequest(Method method, string body, string contentType = JSON)
        {
            var request = new RestRequest(method);
            AddHeaders(ref request, contentType);
            request.AddParameter("undefined", body, ParameterType.RequestBody);

            return ExecuteRequest(request);
        }

        private void AddHeaders(ref RestRequest request, string contentType = JSON)
        {
            request.AddHeader("Content-Type", contentType);
            request.AddHeader("Authorization", $"Bearer {Token}");
        }

        private string ExecuteRequest(RestRequest request)
        {
            IRestResponse response = RestClient.Execute(request);
            return response.Content;
        }

        public string ReadRequest(string contentType = JSON)
        {
            RestRequest request = new RestRequest(Method.GET);
            AddHeaders(ref request, contentType);

            return ExecuteRequest(request); ;
        }
    }
}
