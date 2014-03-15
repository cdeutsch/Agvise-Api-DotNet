using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agvise.Api.Models
{
    public class Sample
    {
        /// <summary>
        /// Primary key of the Sample
        /// <remarks>Only set this to a non-zero value if you're doing an edit.</remarks>
        /// </summary>
        [Display(Name = "Reference Number")]
        [Key]
        public long ReferenceNumber { get; set; }

        [Display(Name = "Sample ID")]
        [StringLength(50)]
        public string SampleIdentifier { get; set; }

        [Display(Name = "Unique ID")]
        [StringLength(50)]
        public string UniqueIdentifier { get; set; }

        [Display(Name = "Analysis Options")]
        [StringLength(1000)]
        public string AnalysisOptions { get; set; }

        [Display(Name = "Additional Analysis Options")]
        public List<string> AdditionalAnalysisOptions { get; set; }

        [Display(Name = "Phosphorus Option")]
        [StringLength(500)]
        public string PhosphorusOption { get; set; }

        [Display(Name = "Depth 1")]
        public int? Depth1 { get; set; }

        [Display(Name = "Depth 2")]
        public int? Depth2 { get; set; }

        [Display(Name = "Depth 3")]
        public int? Depth3 { get; set; }

        [Display(Name = "Depth 4")]
        public int? Depth4 { get; set; }

        [Display(Name = "Starting Depth Of 2nd")]
        public int? StartingDepthOf2nd { get; set; }

        [StringLength(50)]
        public string Acres { get; set; }

        [Display(Name = "Previous Crop")]
        [StringLength(250)]
        public string PreviousCrop { get; set; }

        [Display(Name = "Yield Goal 1")]
        [StringLength(50)]
        public string YieldGoal1Override { get; set; }

        [Display(Name = "Yield Goal 2")]
        [StringLength(50)]
        public string YieldGoal2Override { get; set; }

        [Display(Name = "Yield Goal 3")]
        [StringLength(50)]
        public string YieldGoal3Override { get; set; }

        [Display(Name = "Electronic Number")]
        [StringLength(50)]
        public string ElectronicNumber { get; set; }
   
    }
}
