using Agvise.Api;
using Agvise.Api.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharp
{
    public static class RestSharpExtensions
    {
        public static void ThrowExceptionsForErrors(this IRestResponse response)
        {
            if (response.StatusCode != System.Net.HttpStatusCode.OK) {
                ApiResponse<object> apiResponse = null;
                try
                {
                    var jsonDeserializer = new RestSharp.Deserializers.JsonDeserializer();
                    apiResponse = jsonDeserializer.Deserialize<ApiResponse<object>>(response);
                }
                catch (Exception)
                {
                }
                if (apiResponse != null && apiResponse.Error != null && !string.IsNullOrWhiteSpace(apiResponse.Error.Message))
                {
                    throw new ApiException(apiResponse);
                }
                else
                {
                    throw new ApplicationException(response.Content);
                }
            }
            if (response.ErrorException != null) {
                throw response.ErrorException;
            }
        }

        public static void ThrowExceptionsForErrors<T>(this IRestResponse<ApiResponse<T>> response)
        {
            if (response.StatusCode != System.Net.HttpStatusCode.OK) {
                if (response.Data != null && response.Data.Error != null) {
                    throw new ApiException(new ApiResponse<object>()
                    {
                        Data = (object)response.Data.Data,
                        Error = response.Data.Error
                    });
                } else {
                    throw new ApplicationException(response.Content);
                }
            }
            if (response.ErrorException != null) {
                throw response.ErrorException;
            }
        }
    }
}
