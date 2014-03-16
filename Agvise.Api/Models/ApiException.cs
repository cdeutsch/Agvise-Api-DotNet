using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agvise.Api.Models
{
    public class ApiException : Exception
    {
        public ApiError ApiError { get; private set; }

        public ApiException(ApiError apiError)
            : base(apiError.Message)
        {
            ApiError = apiError;
        }
    }
}
