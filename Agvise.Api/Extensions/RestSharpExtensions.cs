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
        public static void ThrowExceptionsForErrors<T>(this IRestResponse<ApiResponse<T>> response)
        {
            if (response.StatusCode != System.Net.HttpStatusCode.OK) {
                if (response.Data != null && response.Data.Error != null)
                {
                    throw new ApiException(response.Data.Error);
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
    }
}
