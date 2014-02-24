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
                throw new ApplicationException(response.Content);
            }
            if (response.ErrorException != null) {
                throw response.ErrorException;
            }
        }
    }
}
