using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agvise.Api.Models
{
    public class ApiError
    {
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }
        public string MessageDetail { get; set; }
    }
}
