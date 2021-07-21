using System;
using AventStack.ExtentReports;
using NUnit.Framework;
using POM_Task2_DataDriven.Pages;
using POM_Task2_DataDriven.Utilities;

namespace POM_Task2_DataDriven.Tests
{
    [TestFixture]
    public class ShareSkillTest :Driver
    {
        private CommonMethods commonMethods;

        // Constructor 
        public ShareSkillTest()
        {
            commonMethods = new CommonMethods();
        }

        [Test]
        [TestCaseSource(typeof(Driver), "BrowserToRunWith")]
        public void createServiceTest(string browserName)
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "CreateService method is called");
                Setup(browserName);
                //ShareSkillPage Object
                ShareSkillPage shareSkillObj = new ShareSkillPage(driver);
                shareSkillObj.CreateServiceListing();
                test.Log(Status.Pass, "Service is listed");
                test.Pass("Test Passed");
            }
            catch (Exception msg)
            {
                var mediaEntity = commonMethods.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, msg.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
            }
        }
        
    }
}
