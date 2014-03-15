using Agvise.Api.Models;
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
        public static string BaseUrl = "https://submit.agvise.com/api/";
        public static string Resource = "content/item.js?nonce={nonce}";

        private readonly RestClient _client;

        public AgviseClient(string apiKey)
        {
            _client = new RestClient(BaseUrl);
            _client.Authenticator = new HttpBasicAuthenticator(apiKey, null);
        }

        public SubmittedSampleOrder GetSampleSubmission(long sampleOrderID)
        {
            var request = new RestRequest("samples/submit/{id}");
            request.AddUrlSegment("id", sampleOrderID.ToString());
            request.Method = Method.GET;

            var response = _client.Execute<ApiResponse<SubmittedSampleOrder>>(request);

            response.ThrowExceptionsForErrors();
            response.Data.Error.ThrowExceptionsForErrors();

            return response.Data.Data;
        }

        public SubmittedSampleOrder SubmitSample(SampleOrder sampleOrder)
        {
            var request = new RestRequest("samples/submit");
            request.Method = Method.POST;
            request.AddBody(sampleOrder);

            var response = _client.Execute<ApiResponse<SubmittedSampleOrder>>(request);

            response.ThrowExceptionsForErrors();
            response.Data.Error.ThrowExceptionsForErrors();

            return response.Data.Data;
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
