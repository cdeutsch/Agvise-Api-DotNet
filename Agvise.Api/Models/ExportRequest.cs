using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agvise.Api.Models
{
    public class ExportRequest
    {
        public ExportRequest()
        {
            Format = "json";
        }

        public int Year { get; set; }

        public string Account { get; set; }

        public List<long> ReferenceNumbers { get; set; }

        public List<string> ElectronicIds { get; set; }

        public long? LastReferenceNumber { get; set; }

        public string Format { get; set; }

        public string StatusCallbackUrl { get; set; }

        public string DownloadCallbackUrl { get; set; }

    }
}
