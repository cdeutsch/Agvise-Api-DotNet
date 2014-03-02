using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agvise.Api.Models
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }

        public ApiError Error { get; set; }
    }
}
