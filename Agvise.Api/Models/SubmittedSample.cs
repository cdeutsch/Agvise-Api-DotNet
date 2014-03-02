using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agvise.Api.Models
{
    public class SubmittedSample : Sample
    {
        [Display(Name = "Reference Number")]
        [Key]
        public long ReferenceNumber { get; set; }
    }
}
