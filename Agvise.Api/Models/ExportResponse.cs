using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agvise.Api.Models
{
    public class ExportResponse
    {
        public long ExportId { get; set; }
        public string StatusUrl { get; set; }
        public string DownloadUrl { get; set; }
    }
}
