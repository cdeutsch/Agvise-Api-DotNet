using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agvise.Api.Models;
using System.Collections.Generic;
using System.IO;

namespace Agvise.Api.Tests
{
    [TestClass]
    public class ApiUnitTest
    {
        AgviseClient client = null;

        public ApiUnitTest()
        {
            client = new AgviseClient(System.Configuration.ConfigurationManager.AppSettings["AgviseApiKey"]);
        }

        [TestMethod]
        public void TestGetSampleSubmission()
        {
            var submittedSampleOrder = client.GetSampleSubmission(202083);
            Assert.IsNotNull(submittedSampleOrder.PKApplication1);
        }

        [TestMethod]
        public void TestGetSampleSubmissionLabels()
        {
            byte[] bytes = client.GetSampleSubmissionLabels(new List<long>() { 202083 });
            Assert.IsTrue(bytes.Length > 0);
            string path = Path.Combine(System.Environment.CurrentDirectory, Guid.NewGuid().ToString() + ".pdf");
            File.WriteAllBytes(path, bytes);
            var fileInfo = new FileInfo(path);
            Assert.IsTrue(fileInfo.Length > 0);
            fileInfo.Delete();
        }

        [TestMethod]
        public void TestSubmitSample()
        {
            var sampleOrder = new SampleOrder()
            {
                SampleOrderType = SampleOrderType.GridZone,
                GrowerName = "ABC Grower Name",
                GrowerAddress1 = "123 Fake St",
                GrowerAddress2 = "Suite 650",
                GrowerCity = "Grand Forks",
                GrowerState = "XX",
                GrowerPostalCode = "22222",
                GrowerAccountNumber = "0123456789",
                GrowerSampler = "Sampler 123",
                SampleDate = DateTime.Now.Date, // only the date is used
                FieldIdentifier = "123-A",
                FieldName = "23-A Field",
                FieldCounty = "Fargo",
                FieldRange = "12",
                FieldTownship = "Hatton",
                FieldSection = 25,
                FieldQuarter = "NE",
                FieldTotalAcres = 902.5m,
                FieldYearSampled = 2012,
                //ManureApplied = true,
                CropSelection1 = "Barley",
                YieldGoal1 = "90",
                PKApplication1 = "INVALID",
                CropSelection2 = "S. Beets 6 lbs",
                YieldGoal2 = "20",
                PKApplication2 = "Broadcast",
                CropSelection3 = "Barley-Feed",
                YieldGoal3 = "80",
                PKApplication3 = "Broadcast/Maint",

                Samples = new List<Sample>()
                {
                    new Sample() 
                    {
                        SampleIdentifier = "111",
                        UniqueIdentifier = "222",
                        AnalysisOptions = "INVALID",
                        AdditionalAnalysisOptions = new List<string>() 
                        { 
                            "INVALID",
                            "Potassium"
                        },
                        PhosphorusOption = "INVALID",
                        Depth1 = 24,
                        Depth2 = 48,
                        //Depth3 = 64,
                        //Depth4 = 82,
                        StartingDepthOf2nd = 24,
                        Acres = "100",
                        PreviousCrop = "INVALID",
                        YieldGoal1Override = "90",
                        YieldGoal2Override = "20",
                        YieldGoal3Override = "80",
                        ElectronicNumber = "98765",
                    },
                    new Sample() 
                    {
                        SampleIdentifier = "112",
                        UniqueIdentifier = "223",
                        AnalysisOptions = "DEALER DEFAULT",
                        AdditionalAnalysisOptions = new List<string>() 
                        { 
                            "Phosphorus",
                            "Potassium"
                        },
                        PhosphorusOption = "",
                        Depth1 = 24,
                        Depth2 = 48,
                        //Depth3 = 64,
                        //Depth4 = 82,
                        StartingDepthOf2nd = 24,
                        Acres = "100",
                        PreviousCrop = "Canola-bu",
                        YieldGoal1Override = "90",
                        YieldGoal2Override = "20",
                        YieldGoal3Override = "80",
                        ElectronicNumber = "98765",
                    }
                }
            };

            try
            {
                var try1 = client.SubmitSample(sampleOrder);
            }
            catch (ApiException exp)
            {
                Assert.IsNotNull(exp.ApiError.ValidationErrors);
                Assert.IsTrue(exp.ApiError.ValidationErrors.Count == 6);
            }

            // fix errors.
            sampleOrder.GrowerState = "ND";
            sampleOrder.PKApplication1 = "University";
            sampleOrder.Samples[0].AnalysisOptions = "DEALER DEFAULT";
            sampleOrder.Samples[0].AdditionalAnalysisOptions[0] = "Phosphorus";
            sampleOrder.Samples[0].PhosphorusOption = "";
            sampleOrder.Samples[0].PreviousCrop = "Canola-bu";

            var submittedSampleOrder = client.SubmitSample(sampleOrder);
            RunSampleOrderAsserts(sampleOrder, submittedSampleOrder);

            // perform an edit
            submittedSampleOrder.GrowerCity = "Sioux Falls";
            submittedSampleOrder.GrowerState = "SD";
            submittedSampleOrder.GrowerPostalCode = "33333";
            submittedSampleOrder.Samples[0].SampleIdentifier = "3333";
            submittedSampleOrder.Samples[0].UniqueIdentifier = "4444";

            var submittedSampleOrder2 = client.SubmitSample(submittedSampleOrder);
            RunSampleOrderAsserts(submittedSampleOrder, submittedSampleOrder2);

            var submittedSampleOrder3 = client.GetSampleSubmission(submittedSampleOrder2.SampleOrderID);
            RunSampleOrderAsserts(submittedSampleOrder2, submittedSampleOrder3);

            Assert.AreEqual(submittedSampleOrder2.CustomerAccountNumber, submittedSampleOrder3.CustomerAccountNumber);
            Assert.AreEqual(submittedSampleOrder2.SubmitterName, submittedSampleOrder3.SubmitterName);
            Assert.AreEqual(submittedSampleOrder2.SubmitterAddress1, submittedSampleOrder3.SubmitterAddress1);
            Assert.AreEqual(submittedSampleOrder2.SubmitterAddress2, submittedSampleOrder3.SubmitterAddress2);
            Assert.AreEqual(submittedSampleOrder2.SubmitterCity, submittedSampleOrder3.SubmitterCity);
            Assert.AreEqual(submittedSampleOrder2.SubmitterState, submittedSampleOrder3.SubmitterState);
            Assert.AreEqual(submittedSampleOrder2.SubmitterPostalCode, submittedSampleOrder3.SubmitterPostalCode);
            Assert.AreEqual(submittedSampleOrder2.SubmitterAccountNumber, submittedSampleOrder3.SubmitterAccountNumber);
            Assert.AreEqual(submittedSampleOrder2.SubmitterEmail, submittedSampleOrder3.SubmitterEmail);
            Assert.AreEqual(submittedSampleOrder2.CreatedByAccountNumber, submittedSampleOrder3.CreatedByAccountNumber);
            Assert.AreEqual(submittedSampleOrder2.UpdatedByAccountNumber, submittedSampleOrder3.UpdatedByAccountNumber);
            Assert.AreEqual(submittedSampleOrder2.Printed, submittedSampleOrder3.Printed);
            Assert.AreEqual(submittedSampleOrder2.Received, submittedSampleOrder3.Received);
            Assert.AreEqual(submittedSampleOrder2.Updated.ToUniversalTime().ToString(), submittedSampleOrder3.Updated.ToUniversalTime().ToString());
            Assert.AreEqual(submittedSampleOrder2.Created.ToUniversalTime().ToString(), submittedSampleOrder3.Created.ToUniversalTime().ToString());

        }

        [TestMethod]
        public void TestCreateExport()
        {
            var exportRequest = new ExportRequest()
            {
                Year = DateTime.UtcNow.Year
            };

            var exportResponse = client.CreateSampleExport(exportRequest);

            Assert.IsNotNull(exportResponse);
            Assert.IsTrue(exportResponse.ExportId > 0);
            Assert.IsNotNull(exportResponse.StatusUrl);

            // check url until ready.
            int attempts = 0;
            while (attempts < 20)
            {
                attempts += 1;
                var exportStatus = client.GetSampleExportStatus(exportResponse.ExportId);
                Assert.IsNotNull(exportStatus);
                Assert.IsTrue(exportStatus.Status.Length > 0);

                if (exportStatus.Status.Equals("finished", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(2000);
                }
            }

            // get results.
            var sampleExports = client.GetSampleExport(exportResponse.ExportId);
            Assert.IsNotNull(sampleExports);
            Assert.IsTrue(sampleExports.Count > 0);
            foreach (var sampleExport in sampleExports)
            {
                Assert.AreEqual(sampleExport.year_Tested, DateTime.UtcNow.Year);
                Assert.IsTrue(sampleExport.id > 0);
                Assert.IsTrue(sampleExport.reference_Number.HasValue && sampleExport.reference_Number.Value > 0);
            }
        }

        [TestMethod]
        public void TestGetSampleExportStatuses()
        {
            // get results.
            var exportStatuses = client.GetSampleExportStatuses();
            Assert.IsNotNull(exportStatuses);
            Assert.IsTrue(exportStatuses.Count > 0);
            foreach (var exportStatus in exportStatuses)
            {
                Assert.IsNotNull(exportStatus);
                Assert.IsTrue(exportStatus.Status.Length > 0);
                Assert.IsTrue(exportStatus.DownloadUrl.Length > 0);
                Assert.IsTrue(exportStatus.ExportId > 0);
            }
        }

        [TestMethod]
        public void TestGetSample()
        {
            // get results.
            var sampleExport = client.GetSample(2014, 14017626);
            Assert.IsNotNull(sampleExport);
            Assert.IsTrue(sampleExport.id > 0);
            Assert.IsTrue(sampleExport.reference_Number.HasValue && sampleExport.reference_Number.Value > 0);

            Assert.AreEqual(2028432, sampleExport.id);
            Assert.AreEqual(14017626, sampleExport.reference_Number);
            Assert.AreEqual("NW12673", sampleExport.lab_Number);
            Assert.AreEqual(0, sampleExport.grid_Number);
            Assert.AreEqual("", sampleExport.sample_Description);
            Assert.IsNull(sampleExport.date_Sampled);
            Assert.AreEqual(6, sampleExport.depth_Sample_1);
            Assert.AreEqual(24, sampleExport.depth_Sample_2);
            Assert.AreEqual(0, sampleExport.depth_Sample_3);
            Assert.AreEqual(0, sampleExport.depth_Sample_4);
            Assert.AreEqual(6, sampleExport.depth_Second_Sample_Starting);
            Assert.AreEqual("0.21", sampleExport.salt_mmhos_1_to_1_Depth_1);
            Assert.AreEqual("0.45", sampleExport.salt_mmhos_1_to_1_Depth_2);
            Assert.AreEqual("5.8", sampleExport.pH_1_to_1_Depth_1);
            Assert.AreEqual("7.4", sampleExport.pH_1_to_1_Depth_2);
            Assert.AreEqual("0", sampleExport.buffer_pH_Sikora);
            Assert.AreEqual("0", sampleExport.zinc_ppm_DTPA_S);
            Assert.AreEqual("0", sampleExport.iron_ppm_DTPA_S);
            Assert.AreEqual("0.93", sampleExport.copper_ppm_DTPA_S);
            Assert.AreEqual("0", sampleExport.manganese_ppm_DPTA_S);
            Assert.AreEqual("0", sampleExport.boron_ppm_DTPA_S);
            Assert.AreEqual("0", sampleExport.organic_Matter_Percent_LOI);
            Assert.AreEqual(0, sampleExport.sand_Percentage_Hyd);
            Assert.AreEqual(0, sampleExport.silt_Percentage_Hyd);
            Assert.AreEqual(0, sampleExport.clay_Percentage_Hyd);
            Assert.AreEqual("", sampleExport.bulk_Density_g_cc);
            Assert.AreEqual("", sampleExport.water_Hold_Capacity_1_3_Bar);
            Assert.AreEqual(0, sampleExport.water_Soluble_Calcium_ppm);
            Assert.AreEqual(0, sampleExport.water_Soluble_Potassium_ppm);
            Assert.AreEqual(0, sampleExport.water_Soluble_Magnesium_ppm);
            Assert.AreEqual(0, sampleExport.water_Soluble_Sodium_ppm);
            Assert.AreEqual(0, sampleExport.water_Soluble_Phosphorus_ppm);
            Assert.AreEqual(0, sampleExport.water_Soluble_Sulfur_ppm);
            Assert.IsNull(sampleExport.manure_Applied);
            Assert.AreEqual(0, sampleExport.ammonical_Nitrogen_lb_ac_Depth_1);
            Assert.AreEqual(0, sampleExport.ammonical_Nitrogen_lb_ac_Depth_2);
            Assert.AreEqual(0, sampleExport.ammonical_Nitrogen_lb_ac_Depth_3);
            Assert.AreEqual(0, sampleExport.aluminum_ppm_KCl);
            Assert.AreEqual("", sampleExport.lab_Comment);
            Assert.AreEqual(DateTime.Parse("2014-04-09T00:00:00"), sampleExport.date_Received);
            Assert.AreEqual("Wheat-Winter", sampleExport.crop_Name_1);
            Assert.AreEqual(90, sampleExport.yield_Goal_1);
            Assert.AreEqual("Band", sampleExport.guideline_Name_1);
            Assert.IsNull(sampleExport.crop_Name_2);
            Assert.AreEqual(0, sampleExport.yield_Goal_2);
            Assert.AreEqual("", sampleExport.guideline_Name_2);
            Assert.IsNull(sampleExport.crop_Name_3);
            Assert.AreEqual(0, sampleExport.yield_Goal_3);
            Assert.AreEqual("", sampleExport.guideline_Name_3);
            Assert.AreEqual(2014, sampleExport.year_Tested);
            Assert.AreEqual("AG0001", sampleExport.billing_Account_Number);
            Assert.AreEqual("DUCKS UNLIMITED", sampleExport.submitter_Name);
            Assert.AreEqual("2525 RIVER ROAD", sampleExport.submitter_Address_1);
            Assert.AreEqual("", sampleExport.submitter_Address_2);
            Assert.AreEqual("BISMARCK, ND", sampleExport.submitter_City_And_State);
            Assert.AreEqual("58503", sampleExport.submitter_Postal_Code);
            Assert.AreEqual(DateTime.Parse("2014-04-10T00:00:00"), sampleExport.date_Reported);
            Assert.AreEqual("", sampleExport.electronic_ID);
            Assert.AreEqual(0, sampleExport.number_Of_Grids);
            Assert.AreEqual(0, sampleExport.solvita_ppm_CO2);
            Assert.AreEqual("", sampleExport.unique_ID);
            Assert.AreEqual(0, sampleExport.phosphorus_ppm_M3);
            Assert.AreEqual("DUCKS UNLIMITED", sampleExport.grower_Name);
            Assert.AreEqual("2525 RIVER ROAD", sampleExport.grower_Address_1);
            Assert.AreEqual("", sampleExport.grower_Address_2);
            Assert.AreEqual("BISMARCK, ND", sampleExport.grower_City_And_State);
            Assert.AreEqual("58503", sampleExport.grower_Postal_Code);
            Assert.AreEqual("", sampleExport.field_Name);
            Assert.AreEqual("NCREC", sampleExport.field_ID);
            Assert.AreEqual("", sampleExport.county);
            Assert.AreEqual("", sampleExport.township);
            Assert.AreEqual("0", sampleExport.section_Number);
            Assert.AreEqual("", sampleExport.quarter_Description);
            Assert.AreEqual("", sampleExport.range);
            Assert.AreEqual("0", sampleExport.acres);
            Assert.AreEqual("0.0", sampleExport.percent_Saturation_Calcium);
            Assert.AreEqual("0.0", sampleExport.percent_Saturation_Hydrogn);
            Assert.AreEqual("0.0", sampleExport.percent_Saturation_Potassium);
            Assert.AreEqual("0.0", sampleExport.percent_Saturation_Magnesium);
            Assert.AreEqual("0.0", sampleExport.percent_Saturation_Sodium);
            Assert.AreEqual("0", sampleExport.calcium_MEQ);
            Assert.AreEqual("0", sampleExport.calcium_ppm_Am_AC);
            Assert.AreEqual("0.0", sampleExport.carbonate_Percent_Depth_1);
            Assert.AreEqual("0.0", sampleExport.carbonate_Percent_Depth_2);
            Assert.AreEqual("0", sampleExport.ceC_MEQ);
            Assert.AreEqual("5", sampleExport.chloride_lb_ac_Depth1);
            Assert.AreEqual("15", sampleExport.chloride_lb_ac_Depth2);
            Assert.AreEqual("0", sampleExport.hydrogen_MEQ);
            Assert.AreEqual("0", sampleExport.potassium_MEQ);
            Assert.AreEqual("538", sampleExport.potassium_ppm_Am_AC);
            Assert.AreEqual("0", sampleExport.magnesium_MEQ);
            Assert.AreEqual("0", sampleExport.magnesium_ppm_Am_AC);
            Assert.AreEqual("16", sampleExport.nitrate_Nitrogen_lb_ac_Depth_1);
            Assert.AreEqual("27", sampleExport.nitrate_Nitrogen_lb_ac_Depth_2);
            Assert.AreEqual("0", sampleExport.nitrate_Nitrogen_lb_ac_Depth_3);
            Assert.AreEqual("0", sampleExport.nitrate_Nitrogen_lb_ac_Depth_4);
            Assert.AreEqual("43", sampleExport.nitrate_Nitrogen_lb_ac_0_to_24);
            Assert.AreEqual("0", sampleExport.nitrate_Nitrogen_lb_ac_below_24);
            Assert.AreEqual("0", sampleExport.sodium_MEQ);
            Assert.AreEqual("0", sampleExport.sodium_ppm_Am_AC);
            Assert.AreEqual("0", sampleExport.phosphorus_ppm_Bray_1);
            Assert.AreEqual("0", sampleExport.phosphorus_ppm_Bray_2);
            Assert.AreEqual("30", sampleExport.phosphorus_ppm_Olsen);
            Assert.AreEqual("14", sampleExport.sulfate_Sulfur_lb_ac_Depth_1);
            Assert.AreEqual("48", sampleExport.sulfate_Sulfur_lb_ac_Depth_2);
            Assert.IsNull(sampleExport.usdA_Texture_Class);
            Assert.AreEqual("Wheat-Winter", sampleExport.fertilizerGuideline1.crop);
            Assert.AreEqual("WINTER_WHEAT", sampleExport.fertilizerGuideline1.crop_Code);
            Assert.AreEqual("Band", sampleExport.fertilizerGuideline1.guideline);
            Assert.AreEqual("BND", sampleExport.fertilizerGuideline1.guideline_Code);
            Assert.AreEqual(90, sampleExport.fertilizerGuideline1.yield_Goal);
            Assert.AreEqual("", sampleExport.fertilizerGuideline1.boron_To_Apply);
            Assert.AreEqual("", sampleExport.fertilizerGuideline1.boron_Application_Method);
            Assert.AreEqual("20", sampleExport.fertilizerGuideline1.chloride_To_Apply);
            Assert.AreEqual("Broadcast", sampleExport.fertilizerGuideline1.chloride_Application_Method);
            Assert.AreEqual("0", sampleExport.fertilizerGuideline1.copper_To_Apply);
            Assert.AreEqual("", sampleExport.fertilizerGuideline1.copper_Application_Method);
            Assert.AreEqual("", sampleExport.fertilizerGuideline1.iron_To_Apply);
            Assert.AreEqual("", sampleExport.fertilizerGuideline1.iron_Application_Method);
            Assert.AreEqual("10", sampleExport.fertilizerGuideline1.potassium_To_Apply);
            Assert.AreEqual("Band (Starter)*", sampleExport.fertilizerGuideline1.potassium_Application_Method);
            Assert.AreEqual("", sampleExport.fertilizerGuideline1.lime_To_ApplyTons);
            Assert.AreEqual("", sampleExport.fertilizerGuideline1.lime_Application_Method);
            Assert.AreEqual("", sampleExport.fertilizerGuideline1.magnesium_To_Apply);
            Assert.AreEqual("", sampleExport.fertilizerGuideline1.magnesium_Application_Method);
            Assert.AreEqual("", sampleExport.fertilizerGuideline1.manganese_To_Apply);
            Assert.AreEqual("", sampleExport.fertilizerGuideline1.manganeseIron_Application_Method);
            Assert.AreEqual("173", sampleExport.fertilizerGuideline1.nitrogen_To_Apply);
            Assert.AreEqual("", sampleExport.fertilizerGuideline1.nitrogen_Application_Method);
            Assert.AreEqual("15", sampleExport.fertilizerGuideline1.phosphorus_To_Apply);
            Assert.AreEqual("Band (Starter)*", sampleExport.fertilizerGuideline1.phosphorus_Application_Method);
            Assert.AreEqual("7", sampleExport.fertilizerGuideline1.sulfur_To_Apply);
            Assert.AreEqual("Band (Trial)", sampleExport.fertilizerGuideline1.sulfur_Application_Method);
            Assert.AreEqual("", sampleExport.fertilizerGuideline1.zinc_To_Apply);
            Assert.AreEqual("", sampleExport.fertilizerGuideline1.zinc_Application_Method);
        }


        private void RunSampleOrderAsserts(SampleOrder expected, SubmittedSampleOrder actual)
        {
            Assert.AreEqual(expected.SampleOrderType, actual.SampleOrderType);
            Assert.AreEqual(expected.GrowerName, actual.GrowerName);
            Assert.AreEqual(expected.GrowerAddress1, actual.GrowerAddress1);
            Assert.AreEqual(expected.GrowerAddress2, actual.GrowerAddress2);
            Assert.AreEqual(expected.GrowerCity, actual.GrowerCity);
            Assert.AreEqual(expected.GrowerState, actual.GrowerState);
            Assert.AreEqual(expected.GrowerPostalCode, actual.GrowerPostalCode);
            Assert.AreEqual(expected.GrowerAccountNumber, actual.GrowerAccountNumber);
            Assert.AreEqual(expected.GrowerSampler, actual.GrowerSampler);
            Assert.AreEqual(expected.SampleDate.Value.ToUniversalTime().ToString(), actual.SampleDate.Value.ToUniversalTime().ToString());
            Assert.AreEqual(expected.FieldIdentifier, actual.FieldIdentifier);
            Assert.AreEqual(expected.FieldName, actual.FieldName);
            Assert.AreEqual(expected.FieldCounty, actual.FieldCounty);
            Assert.AreEqual(expected.FieldRange, actual.FieldRange);
            Assert.AreEqual(expected.FieldTownship, actual.FieldTownship);
            Assert.AreEqual(expected.FieldSection, actual.FieldSection);
            Assert.AreEqual(expected.FieldQuarter, actual.FieldQuarter);
            Assert.AreEqual(expected.FieldTotalAcres, actual.FieldTotalAcres);
            Assert.AreEqual(expected.FieldYearSampled, actual.FieldYearSampled);
            Assert.AreEqual(expected.ManureApplied, actual.ManureApplied);
            Assert.AreEqual(expected.CropSelection1, actual.CropSelection1);
            Assert.AreEqual(expected.YieldGoal1, actual.YieldGoal1);
            Assert.AreEqual(expected.PKApplication1, actual.PKApplication1);
            Assert.AreEqual(expected.CropSelection2, actual.CropSelection2);
            Assert.AreEqual(expected.YieldGoal2, actual.YieldGoal2);
            Assert.AreEqual(expected.PKApplication2, actual.PKApplication2);
            Assert.AreEqual(expected.CropSelection3, actual.CropSelection3);
            Assert.AreEqual(expected.YieldGoal3, actual.YieldGoal3);
            Assert.AreEqual(expected.PKApplication3, actual.PKApplication3);

            foreach (var expectedSample in expected.Samples)
            {
                var actualSample = actual.Samples.FirstOrDefault(oo => oo.SampleIdentifier == expectedSample.SampleIdentifier);
                Assert.IsNotNull(actualSample);
                Assert.AreEqual(expectedSample.SampleIdentifier, actualSample.SampleIdentifier);
                Assert.AreEqual(expectedSample.UniqueIdentifier, actualSample.UniqueIdentifier);
                Assert.AreEqual(expectedSample.AnalysisOptions, actualSample.AnalysisOptions);
                Assert.AreEqual(expectedSample.PhosphorusOption, actualSample.PhosphorusOption);
                Assert.AreEqual(expectedSample.Depth1, actualSample.Depth1);
                Assert.AreEqual(expectedSample.Depth2, actualSample.Depth2);
                Assert.AreEqual(expectedSample.Depth3, actualSample.Depth3);
                Assert.AreEqual(expectedSample.Depth4, actualSample.Depth4);
                Assert.AreEqual(expectedSample.StartingDepthOf2nd, actualSample.StartingDepthOf2nd);
                Assert.AreEqual(expectedSample.Acres, actualSample.Acres);
                Assert.AreEqual(expectedSample.PreviousCrop, actualSample.PreviousCrop);
                Assert.AreEqual(expectedSample.YieldGoal1Override, actualSample.YieldGoal1Override);
                Assert.AreEqual(expectedSample.YieldGoal2Override, actualSample.YieldGoal2Override);
                Assert.AreEqual(expectedSample.YieldGoal3Override, actualSample.YieldGoal3Override);
                Assert.AreEqual(expectedSample.ElectronicNumber, actualSample.ElectronicNumber);
                Assert.AreEqual(expectedSample.AdditionalAnalysisOptions.Count, actualSample.AdditionalAnalysisOptions.Count);
                for (int xx = 0; xx < expectedSample.AdditionalAnalysisOptions.Count; xx++)
                {
                    Assert.AreEqual(expectedSample.AdditionalAnalysisOptions[xx], actualSample.AdditionalAnalysisOptions[xx]);
                }

                Assert.IsTrue(actualSample.ReferenceNumber > 0);
            }

            Assert.IsTrue(actual.SampleOrderID > 0);
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.SubmitterName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.CreatedByAccountNumber));
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.UpdatedByAccountNumber));
        }
    }
}
