using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agvise.Api.Models;

namespace Agvise.Api.Models
{
    public static class ApiErrorExtensions
    {
        public static void ThrowExceptionsForErrors(this ApiError error)
        {
            if (error != null && (!string.IsNullOrWhiteSpace(error.Message)))
            {
                throw new ApplicationException(error.Message);
            }
        }
    }
}
