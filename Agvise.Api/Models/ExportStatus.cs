using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agvise.Api.Models
{
    public class ExportStatus
    {
        public long ExportId { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string DownloadUrl { get; set; }
    }
}
