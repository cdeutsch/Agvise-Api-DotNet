using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agvise.Api.Models
{
    public class SubmittedSampleOrder : SampleOrder
    {
        [Key]
        public long SampleOrderID { get; set; }

        [Display(Name = "Submitter Name")]
        [StringLength(250)]
        public string SubmitterName { get; set; }

        [Display(Name = "Submitter Address")]
        [StringLength(250)]
        public string SubmitterAddress1 { get; set; }

        [Display(Name = "Submitter Address 2")]
        [StringLength(250)]
        public string SubmitterAddress2 { get; set; }

        [Display(Name = "Submitter City")]
        [StringLength(250)]
        public string SubmitterCity { get; set; }

        [Display(Name = "Submitter State")]
        [StringLength(5)]
        public string SubmitterState { get; set; }

        [Display(Name = "Submitter Zip")]
        [StringLength(20)]
        public string SubmitterPostalCode { get; set; }

        [Display(Name = "Submitter Account Number")]
        [StringLength(50)]
        public string SubmitterAccountNumber { get; set; }

        [Display(Name = "Submitter Email")]
        [StringLength(320)]
        public string SubmitterEmail { get; set; }

        [Display(Name = "Created By")]
        [StringLength(10)]
        public string CreatedByAccountNumber { get; set; }

        [Display(Name = "Updated By")]
        [StringLength(10)]
        public string UpdatedByAccountNumber { get; set; }

        public bool Printed { get; set; }

        public DateTime? Received { get; set; }

        public DateTime Updated { get; set; }

        public DateTime Created { get; set; }


        public new List<SubmittedSample> Samples { get; set; } // the new keyword, hides the base SampleOrder version
    }
}
