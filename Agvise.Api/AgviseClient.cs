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
            request.RequestFormat = DataFormat.Json;
            request.DateFormat = "yyyy-MM-ddTHH:mm:ssZ"; // do this so we get the right timezone
            request.AddUrlSegment("id", sampleOrderID.ToString());
            request.Method = Method.GET;

            var response = _client.Execute<ApiResponse<SubmittedSampleOrder>>(request);

            response.ThrowExceptionsForErrors<SubmittedSampleOrder>();

            return response.Data.Data;
        }

        public SubmittedSampleOrder SubmitSample(SampleOrder sampleOrder)
        {
            var request = new RestRequest("samples/submit");
            request.RequestFormat = DataFormat.Json;
            request.DateFormat = "yyyy-MM-ddTHH:mm:ssZ"; // do this so we get the right timezone
            request.Method = Method.POST;
            request.AddBody(sampleOrder);

            var response = _client.Execute<ApiResponse<SubmittedSampleOrder>>(request);

            response.ThrowExceptionsForErrors<SubmittedSampleOrder>();

            return response.Data.Data;
        }

        public byte[] GetSampleSubmissionLabels(List<long> sampleOrderIDs)
        {
            var request = new RestRequest("samples/submit/labels/");
            request.RequestFormat = DataFormat.Json;
            sampleOrderIDs.ForEach(id =>
                request.AddParameter("id", id, ParameterType.GetOrPost)
            );
            request.Method = Method.GET;

            var response = _client.Execute(request);

            response.ThrowExceptionsForErrors();

            return response.RawBytes;
        }

        public ExportResponse CreateSampleExport(ExportRequest exportRequest)
        {
            var request = new RestRequest("samples/export");
            request.RequestFormat = DataFormat.Json;
            request.AddObject(exportRequest);
            request.Method = Method.POST;

            var response = _client.Execute<ExportResponse>(request);

            response.ThrowExceptionsForErrors();

            return response.Data;
        }

        public List<ExportStatus> GetSampleExportStatuses()
        {
            var request = new RestRequest("samples/export/status");
            request.RequestFormat = DataFormat.Json;
            request.Method = Method.GET;

            var response = _client.Execute<List<ExportStatus>>(request);

            response.ThrowExceptionsForErrors();

            return response.Data;
        }

        public ExportStatus GetSampleExportStatus(long exportId)
        {
            var request = new RestRequest("samples/export/status/{id}");
            request.RequestFormat = DataFormat.Json;
            request.AddUrlSegment("id", exportId.ToString());
            request.Method = Method.GET;

            var response = _client.Execute<ExportStatus>(request);

            response.ThrowExceptionsForErrors();

            return response.Data;
        }

        public List<SampleExport> GetSampleExport(long exportId)
        {
            var request = new RestRequest("samples/export/{id}");
            request.RequestFormat = DataFormat.Json;
            request.AddUrlSegment("id", exportId.ToString());
            request.Method = Method.GET;

            var response = _client.Execute<List<SampleExport>>(request);

            response.ThrowExceptionsForErrors();

            return response.Data;
        }

        public SampleExport GetSample(int year, long referenceNumber)
        {
            var request = new RestRequest("samples/{year}/{referenceNumber}");
            request.RequestFormat = DataFormat.Json;
            request.AddUrlSegment("year", year.ToString());
            request.AddUrlSegment("referenceNumber", referenceNumber.ToString());
            request.Method = Method.GET;

            var response = _client.Execute<SampleExport>(request);

            response.ThrowExceptionsForErrors();

            return response.Data;
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
