using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agvise.Api.Models
{
    public class SampleExport
    {
        public long id { get; set; }
        public Nullable<long> reference_Number { get; set; }
        public string lab_Number { get; set; }
        public Nullable<int> grid_Number { get; set; }
        public string sample_Description { get; set; }
        public Nullable<System.DateTime> date_Sampled { get; set; }
        public Nullable<int> depth_Sample_1 { get; set; }
        public Nullable<int> depth_Sample_2 { get; set; }
        public Nullable<int> depth_Sample_3 { get; set; }
        public Nullable<int> depth_Sample_4 { get; set; }
        public Nullable<int> depth_Second_Sample_Starting { get; set; }
        public string previous_Crop_Name { get; set; }

        public string salt_mmhos_1_to_1_Depth_1 { get; set; }
        public string salt_mmhos_1_to_1_Depth_2 { get; set; }

        public string pH_1_to_1_Depth_1 { get; set; }
        public string pH_1_to_1_Depth_2 { get; set; }

        public string buffer_pH_Sikora { get; set; }

        public string zinc_ppm_DTPA_S { get; set; }
        public string iron_ppm_DTPA_S { get; set; }
        public string copper_ppm_DTPA_S { get; set; }
        public string manganese_ppm_DPTA_S { get; set; }

        public string boron_ppm_DTPA_S { get; set; }
        public string organic_Matter_Percent_LOI { get; set; }

        public Nullable<int> sand_Percentage_Hyd { get; set; }
        public Nullable<int> silt_Percentage_Hyd { get; set; }
        public Nullable<int> clay_Percentage_Hyd { get; set; }

        public string bulk_Density_g_cc { get; set; }
        public string water_Hold_Capacity_1_3_Bar { get; set; }

        public Nullable<int> water_Soluble_Calcium_ppm { get; set; }
        public Nullable<int> water_Soluble_Potassium_ppm { get; set; }
        public Nullable<int> water_Soluble_Magnesium_ppm { get; set; }
        public Nullable<int> water_Soluble_Sodium_ppm { get; set; }
        public double water_Soluble_Phosphorus_ppm { get; set; }
        public Nullable<int> water_Soluble_Sulfur_ppm { get; set; }

        public Nullable<bool> manure_Applied { get; set; }

        public Nullable<decimal> ammonical_Nitrogen_lb_ac_Depth_1 { get; set; }
        public Nullable<decimal> ammonical_Nitrogen_lb_ac_Depth_2 { get; set; }
        public Nullable<decimal> ammonical_Nitrogen_lb_ac_Depth_3 { get; set; }
        public Nullable<decimal> aluminum_ppm_KCl { get; set; }
        public string lab_Comment { get; set; }

        public Nullable<System.DateTime> date_Received { get; set; }

        public string crop_Name_1 { get; set; }
        public int? yield_Goal_1 { get; set; }
        public string guideline_Name_1 { get; set; }

        public string crop_Name_2 { get; set; }
        public int? yield_Goal_2 { get; set; }
        public string guideline_Name_2 { get; set; }

        public string crop_Name_3 { get; set; }
        public int? yield_Goal_3 { get; set; }
        public string guideline_Name_3 { get; set; }

        public int? year_Tested { get; set; }
        public string billing_Account_Number { get; set; }
        public string submitter_Name { get; set; }
        public string submitter_Address_1 { get; set; }
        public string submitter_Address_2 { get; set; }
        public string submitter_City_And_State { get; set; }
        public string submitter_Postal_Code { get; set; }
        public DateTime? date_Reported { get; set; }
        public string electronic_ID { get; set; }
        public int? number_Of_Grids { get; set; }
        public decimal? solvita_ppm_CO2 { get; set; }
        public string unique_ID { get; set; }
        public int? phosphorus_ppm_M3 { get; set; }

        public string grower_Name { get; set; }
        public string grower_Address_1 { get; set; }
        public string grower_Address_2 { get; set; }
        public string grower_City_And_State { get; set; }
        public string grower_Postal_Code { get; set; }

        public string field_Name { get; set; } 
        public string field_ID { get; set; } 

        public string county { get; set; }
        public string township { get; set; }
        public string section_Number { get; set; }
        public string quarter_Description { get; set; }
        public string range { get; set; }

        public string acres { get; set; }


        public string percent_Saturation_Calcium { get; set; }
        public string percent_Saturation_Hydrogn { get; set; }
        public string percent_Saturation_Potassium { get; set; }
        public string percent_Saturation_Magnesium { get; set; }
        public string percent_Saturation_Sodium { get; set; }

        public string calcium_MEQ { get; set; }
        public string calcium_ppm_Am_AC { get; set; }
        public string carbonate_Percent_Depth_1 { get; set; }
        public string carbonate_Percent_Depth_2 { get; set; }
        public string ceC_MEQ { get; set; }
        public string chloride_lb_ac_Depth1 { get; set; }
        public string chloride_lb_ac_Depth2 { get; set; }
        public string hydrogen_MEQ { get; set; }
        public string potassium_MEQ { get; set; }
        public string potassium_ppm_Am_AC { get; set; }
        public string magnesium_MEQ { get; set; }
        public string magnesium_ppm_Am_AC { get; set; }
        public string nitrate_Nitrogen_lb_ac_Depth_1 { get; set; }
        public string nitrate_Nitrogen_lb_ac_Depth_2 { get; set; }
        public string nitrate_Nitrogen_lb_ac_Depth_3 { get; set; }
        public string nitrate_Nitrogen_lb_ac_Depth_4 { get; set; }
        public string nitrate_Nitrogen_lb_ac_0_to_24 { get; set; }
        public string nitrate_Nitrogen_lb_ac_below_24 { get; set; }
        public string sodium_MEQ { get; set; }
        public string sodium_ppm_Am_AC { get; set; }
        public string phosphorus_ppm_Bray_1 { get; set; }
        public string phosphorus_ppm_Bray_2 { get; set; }
        public string phosphorus_ppm_Olsen { get; set; }
        public string sulfate_Sulfur_lb_ac_Depth_1 { get; set; }
        public string sulfate_Sulfur_lb_ac_Depth_2 { get; set; }
        public string usdA_Texture_Class { get; set; }

        public FertilizerGuidelineExport fertilizerGuideline1 { get; set; }
        public FertilizerGuidelineExport fertilizerGuideline2 { get; set; }
        public FertilizerGuidelineExport fertilizerGuideline3 { get; set; }

    }

    public class FertilizerGuidelineExport
    {
        public string crop { get; set; }
        public string crop_Code { get; set; }
        public string guideline { get; set; }
        public string guideline_Code { get; set; }
        public int? yield_Goal { get; set; }

        public string boron_To_Apply { get; set; }
        public string boron_Application_Method { get; set; }
        public string chloride_To_Apply { get; set; }
        public string chloride_Application_Method { get; set; }
        public string copper_To_Apply { get; set; }
        public string copper_Application_Method { get; set; }
        public string iron_To_Apply { get; set; }
        public string iron_Application_Method { get; set; }
        public string potassium_To_Apply { get; set; }
        public string potassium_Application_Method { get; set; }
        public string lime_To_ApplyTons { get; set; }
        public string lime_Application_Method { get; set; }
        public string magnesium_To_Apply { get; set; }
        public string magnesium_Application_Method { get; set; }
        public string manganese_To_Apply { get; set; }
        public string manganeseIron_Application_Method { get; set; }
        public string nitrogen_To_Apply { get; set; }
        public string nitrogen_Application_Method { get; set; }
        public string phosphorus_To_Apply { get; set; }
        public string phosphorus_Application_Method { get; set; }
        public string sulfur_To_Apply { get; set; }
        public string sulfur_Application_Method { get; set; }
        public string zinc_To_Apply { get; set; }
        public string zinc_Application_Method { get; set; }
    }
}
