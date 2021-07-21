using System;
using NUnit.Framework;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using POM_Task2_DataDriven.Utilities;
using POM_Task2_DataDriven.Pages;
using System.Threading;

namespace POM_Task2_DataDriven.Tests
{
    [TestFixture]
    public class ProfilePageTest:Driver
    {
        private  CommonMethods commonMethods;

        //Create Constructor 
        public ProfilePageTest( )
        {
            commonMethods = new CommonMethods();
        }

        [Test]
        [TestCaseSource(typeof(Driver), "BrowserToRunWith")]
        public void DescriptionTest(string browserName)
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Description method is called");

                Setup(browserName);
                //Profile Description objects
                ProfileDescription profileDescriptionObj = new ProfileDescription(driver);
                profileDescriptionObj.Description();
                test.Log(Status.Pass, "Description is saved successfully");
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
        public void Language()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "CreateLanguage method is called");
                //Profile Page Objects
                ProfilePage ProfileObj = new ProfilePage(driver);
                ProfileObj.CreateLanguage();
                ProfileObj.EditLanguage();
                ProfileObj.DeleteLanguage();

                test.Log(Status.Pass, "Language is Created");
                test.Pass("Test Passed");
            }
            catch (Exception msg)
            {
                var mediaEntity = commonMethods.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, msg.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
            }
        }

        [Test]
        public void Skills()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Skills method is called");
                //Profile Page Objects
                ProfilePage ProfileObj = new ProfilePage(driver);
                ProfileObj.CreateSkills();
                ProfileObj.UpdateSkill();
                test.Log(Status.Pass, "Skill is Created");
                test.Pass("Test Passed");
            }
            catch (Exception msg)
            {
                var mediaEntity = commonMethods.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, msg.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
            }
        }
        [Test]
        public void Education()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Education method is called");
                //Profile Page Objects
                ProfilePage ProfileObj = new ProfilePage(driver);
                ProfileObj.EditLanguage();
                test.Log(Status.Pass, "Education is Edited");
                test.Pass("Test Passed");
            }
            catch (Exception msg)
            {
                var mediaEntity = commonMethods.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, msg.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
            }
        }
        [Test]
        public void Certification()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Certification method is called");
                //Profile Page Objects
                ProfilePage ProfileObj = new ProfilePage(driver);
                ProfileObj.EditLanguage();
                test.Log(Status.Pass, "Certification is Created");
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
