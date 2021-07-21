﻿using System;
using AventStack.ExtentReports;
using NUnit.Framework;
using POM_Task2_DataDriven.Pages;
using POM_Task2_DataDriven.Utilities;
using static POM_Task2_DataDriven.Utilities.CommonMethods;

namespace POM_Task2_DataDriven.Tests
{
    [TestFixture]

    public class ManageRequestsTest : Driver
    {
        private CommonMethods commonMethods;

        public ManageRequestsTest()
        {
            commonMethods = new CommonMethods();
        }

        [Test]
        [TestCaseSource(typeof(Driver), "BrowserToRunWith")]
        public void AcceptReceivedRequestest(string browserName)
        {
            try
            {

                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "AcceptReceivedRequest method is called");

                Setup(browserName);
                //ManageRequests Page Objects
                ManageRequestsPage manageRequestsObj = new ManageRequestsPage(driver);
                manageRequestsObj.AcceptReceivedRequest(ExcelLibHelper.ReadData(1, "SearchSkillToAccept"));

                test.Log(Status.Pass, "Request is accepted");
                test.Pass("Test Passed");

            }
            catch (Exception e)
            {

                var mediaEntity = commonMethods.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, e.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
            }
        }

        [Test]
        [TestCaseSource(typeof(Driver), "BrowserToRunWith")]
        public void DeclineReceivedRequest(string browserName)
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "DeclineReceivedRequest method is called");

                Setup(browserName);
                //ManageRequests Page Objects
                ManageRequestsPage manageRequestsObj = new ManageRequestsPage(driver);
                manageRequestsObj.DeclineReceivedRequest();

                test.Log(Status.Pass, "Request is declined");
                test.Pass("Test Passed");
            }
            catch (Exception e)
            {

                var mediaEntity = commonMethods.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, e.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
            }

        }

    }
}
