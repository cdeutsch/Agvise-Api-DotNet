using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agvise.Api.Models;
using System.Collections.Generic;

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
            var submittedSampleOrder = client.GetSampleSubmission(20287);

        }

        [TestMethod]
        public void TestSubmitSample()
        {
            var sampleOrder = new SampleOrder()
            {
                SampleOrderType = 2,
                CustomerAccountNumber = "XX0001",
                GrowerName = "ABC Grower Name",
                GrowerAddress1 = "123 Fake St",
                GrowerAddress2 = "Suite 650",
                GrowerCity = "Grand Forks",
                GrowerState = "ND",
                GrowerPostalCode = "22222",
                GrowerAccountNumber = "0123456789",
                GrowerSampler = "Sampler 123",
                SampleDate = DateTime.UtcNow,
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
                PKApplication1 = "University",
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

            var submittedSampleOrder = client.SubmitSample(sampleOrder);
            RunSampleOrderAsserts(sampleOrder, submittedSampleOrder);

            var submittedSampleOrder2 = client.GetSampleSubmission(submittedSampleOrder.SampleOrderID);
            RunSampleOrderAsserts(sampleOrder, submittedSampleOrder);

            Assert.AreEqual(submittedSampleOrder.SubmitterName, submittedSampleOrder2.SubmitterName);
            Assert.AreEqual(submittedSampleOrder.SubmitterAddress1, submittedSampleOrder2.SubmitterAddress1);
            Assert.AreEqual(submittedSampleOrder.SubmitterAddress2, submittedSampleOrder2.SubmitterAddress2);
            Assert.AreEqual(submittedSampleOrder.SubmitterCity, submittedSampleOrder2.SubmitterCity);
            Assert.AreEqual(submittedSampleOrder.SubmitterState, submittedSampleOrder2.SubmitterState);
            Assert.AreEqual(submittedSampleOrder.SubmitterPostalCode, submittedSampleOrder2.SubmitterPostalCode);
            Assert.AreEqual(submittedSampleOrder.SubmitterAccountNumber, submittedSampleOrder2.SubmitterAccountNumber);
            Assert.AreEqual(submittedSampleOrder.SubmitterEmail, submittedSampleOrder2.SubmitterEmail);
            Assert.AreEqual(submittedSampleOrder.CreatedByAccountNumber, submittedSampleOrder2.CreatedByAccountNumber);
            Assert.AreEqual(submittedSampleOrder.UpdatedByAccountNumber, submittedSampleOrder2.UpdatedByAccountNumber);
            Assert.AreEqual(submittedSampleOrder.Printed, submittedSampleOrder2.Printed);
            Assert.AreEqual(submittedSampleOrder.Received, submittedSampleOrder2.Received);
            Assert.AreEqual(submittedSampleOrder.Updated, submittedSampleOrder2.Updated);
            Assert.AreEqual(submittedSampleOrder.Created, submittedSampleOrder2.Created);

        }

        private void RunSampleOrderAsserts(SampleOrder expected, SubmittedSampleOrder actual)
        {
            Assert.AreEqual(expected.SampleOrderType, actual.SampleOrderType);
            Assert.AreEqual(expected.CustomerAccountNumber, actual.CustomerAccountNumber);
            Assert.AreEqual(expected.GrowerName, actual.GrowerName);
            Assert.AreEqual(expected.GrowerAddress1, actual.GrowerAddress1);
            Assert.AreEqual(expected.GrowerAddress2, actual.GrowerAddress2);
            Assert.AreEqual(expected.GrowerCity, actual.GrowerCity);
            Assert.AreEqual(expected.GrowerState, actual.GrowerState);
            Assert.AreEqual(expected.GrowerPostalCode, actual.GrowerPostalCode);
            Assert.AreEqual(expected.GrowerAccountNumber, actual.GrowerAccountNumber);
            Assert.AreEqual(expected.GrowerSampler, actual.GrowerSampler);
            Assert.AreEqual(expected.SampleDate, actual.SampleDate);
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
                Assert.IsNull(actualSample);
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
