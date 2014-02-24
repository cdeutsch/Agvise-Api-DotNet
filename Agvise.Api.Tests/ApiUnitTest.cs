using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            string sample = client.GetSampleSubmission(20287);
            Assert.IsNotNull(sample);
            //Assert.IsTrue(response.Data.Filter.Matched);
        }
    }
}
