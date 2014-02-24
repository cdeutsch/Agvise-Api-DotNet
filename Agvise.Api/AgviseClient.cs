using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agvise.Api
{
    public class AgviseClient
    {
        public static string BaseUrl = "http://localhost:49375/api/";
        public static string Resource = "content/item.js?nonce={nonce}";

        private readonly RestClient _client;

        public AgviseClient(string apiKey)
        {
            _client = new RestClient(BaseUrl);
            _client.Authenticator = new HttpBasicAuthenticator(apiKey, null);
        }

        public string GetSampleSubmission(long id)
        {
            var request = new RestRequest("samples/submit/{id}");
            request.AddUrlSegment("id", id.ToString());
            request.Method = Method.GET;

            var response = _client.Execute(request);

            response.ThrowExceptionsForErrors();

            return response.Content;
        }

        public RestClient RestClient
        {
            get
            {
                return _client;
            }
        }

    }
}
