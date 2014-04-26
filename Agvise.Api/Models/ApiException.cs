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

        public object ResponseData { get; private set; }

        private string _message;

        public override string Message
        {
            get { return _message; }
        }

        public ApiException(ApiError apiError)
        {
            if (apiError == null)
            {
                throw new ApplicationException("ApiError parameter can not be null.");
            }

            ApiError = apiError;
            if (apiError != null && !string.IsNullOrWhiteSpace(apiError.Message))
            {
                _message = apiError.Message;
            }
            else
            {
                _message = "Unknown Api Error";
            }
        }

        public ApiException(ApiResponse<object> apiResponse)
        {
            if (apiResponse == null)
            {
                throw new ApplicationException("ApiResponse parameter can not be null.");
            }
            
            if (apiResponse != null)
            {
                ApiError = apiResponse.Error;
                ResponseData = apiResponse.Data;
                if (apiResponse != null && apiResponse.Error != null && !string.IsNullOrWhiteSpace(apiResponse.Error.Message))
                {
                    _message = apiResponse.Error.Message;
                }
                else
                {
                    _message = "Unknown Api Error";
                }
            }
            else
            {
                _message = "Unknown Api Response Error";
            }
        }
    }
}
