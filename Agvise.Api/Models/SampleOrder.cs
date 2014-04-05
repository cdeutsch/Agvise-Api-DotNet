using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agvise.Api.Models
{
    public class SampleOrder
    {
        /// <summary>
        /// Primary key of the SampleOrder
        /// <remarks>Only set this to a non-zero value if you're doing an edit.</remarks>
        /// </summary>
        [Key]
        public long SampleOrderID { get; set; }

        public SampleOrderType SampleOrderType { get; set; }

        [Display(Name = "Grower Name")]
        [StringLength(25)]
        public string GrowerName { get; set; }

        [Display(Name = "Grower Address")]
        [StringLength(20)]
        public string GrowerAddress1 { get; set; }

        [Display(Name = "Grower Address 2")]
        [StringLength(20)]
        public string GrowerAddress2 { get; set; }

        [Display(Name = "Grower City")]
        [StringLength(22)]
        public string GrowerCity { get; set; }

        [Display(Name = "Grower State")]
        [StringLength(2)]
        public string GrowerState { get; set; }

        [Display(Name = "Grower Zip")]
        [StringLength(11)]
        public string GrowerPostalCode { get; set; }

        [Display(Name = "Grower Account Number")]
        [StringLength(50)]
        public string GrowerAccountNumber { get; set; }

        [Display(Name = "Grower Sampler")]
        [StringLength(25)]
        public string GrowerSampler { get; set; }

        [Display(Name = "Sample Date")]
        public DateTime? SampleDate { get; set; }

        [Display(Name = "Field ID")]
        [StringLength(30)]
        public string FieldIdentifier { get; set; }

        [Display(Name = "Field Name")]
        [StringLength(40)]
        public string FieldName { get; set; }

        [Display(Name = "County")]
        [StringLength(15)]
        public string FieldCounty { get; set; }

        [Display(Name = "Range")]
        [StringLength(15)]
        public string FieldRange { get; set; }

        [Display(Name = "Township")]
        [StringLength(15)]
        public string FieldTownship { get; set; }

        [Display(Name = "Section")]
        public int? FieldSection { get; set; }

        [Display(Name = "Quarter")]
        [StringLength(15)]
        public string FieldQuarter { get; set; }

        [Display(Name = "Total Acres")]
        public decimal? FieldTotalAcres { get; set; }

        [Display(Name = "Year Sampled")]
        public int? FieldYearSampled { get; set; }

        [Display(Name = "Previous Crop")]
        [StringLength(250)]
        public string PreviousCrop { get; set; }

        [Display(Name = "Manure Applied")]
        public bool? ManureApplied { get; set; }

        [Display(Name = "Crop Selection 1")]
        [StringLength(50)]
        public string CropSelection1 { get; set; }

        [Display(Name = "Yield Goal 1")]
        [StringLength(50)]
        public string YieldGoal1 { get; set; }

        [Display(Name = "P & K Application 1")]
        [StringLength(50)]
        public string PKApplication1 { get; set; }

        [Display(Name = "Crop Selection 2")]
        [StringLength(50)]
        public string CropSelection2 { get; set; }

        [Display(Name = "Yield Goal 2")]
        [StringLength(50)]
        public string YieldGoal2 { get; set; }

        [Display(Name = "P & K Application 2")]
        [StringLength(50)]
        public string PKApplication2 { get; set; }

        [Display(Name = "Crop Selection 3")]
        [StringLength(50)]
        public string CropSelection3 { get; set; }

        [Display(Name = "Yield Goal 3")]
        [StringLength(50)]
        public string YieldGoal3 { get; set; }

        [Display(Name = "P & K Application 3")]
        [StringLength(50)]
        public string PKApplication3 { get; set; }

        
        public virtual List<Sample> Samples { get; set; }

    }
}
