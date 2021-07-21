using System;
using System.Collections.Generic;
using System.Text;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using POM_Task2_DataDriven.Config;
using POM_Task2_DataDriven.Pages;
using static POM_Task2_DataDriven.Utilities.CommonMethods;

namespace POM_Task2_DataDriven.Utilities
{
    public class Driver
    {
        //Initialize the browser

        public static IWebDriver driver;
        public static SignInPage SignIn;
        public static ExtentReports extent;
        public static ExtentHtmlReporter hTMLReporter;
        public static ExtentTest test;


        [OneTimeSetUp]
        public void Initialize()
        {
            hTMLReporter = new ExtentHtmlReporter(ConstantHelpers.ReportsPath);
            hTMLReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(hTMLReporter);

            //Defining the browser
            //driver = new ChromeDriver(@"/Users/chriselyn/Projects/POM_Task2_DataDriven/POM_Task2_DataDriven/bin");
             

            //Maximise the window
            //driver.Manage().Window.Maximize();
            

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.DataFilePath, "Credentials");
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.DataFilePath, "ChangePasswordTestData");
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.DataFilePath, "ProfileTestData");
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.DataFilePath, "ShareSkillTestData");
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.DataFilePath, "ManageListingsTestData");
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.DataFilePath, "SearchTestData");
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.DataFilePath, "ChatTestData");
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.DataFilePath, "ServiceDetailTestData");
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.DataFilePath, "NotificationTestData");
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.DataFilePath, "ManageRequestsTestData");


            //call the SignIn class
            //SignIn = new SignInPage(driver);
            //SignIn.Login(CommonMethods.ExcelLibHelper.ReadData(1, "EmailAddress"), CommonMethods.ExcelLibHelper.ReadData(1, "Password"));

        }
        public void Setup(String browserName)
        {
            //Defining the browser
            if (browserName.Equals("chrome"))
                driver = new ChromeDriver();
            else if (browserName.Equals("ie"))
                driver = new InternetExplorerDriver();
            else if (browserName.Equals("safari"))
                driver = new SafariDriver();
            else
                driver = new FirefoxDriver();

            //Maximise the window
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            NavigateUrl();
        }

        public static string BaseUrl
        {
            get { return ConstantHelpers.Url; }
        }


        public static void NavigateUrl()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }

        public static IEnumerable<string> BrowserToRunWith()
        {
            string[] browsers = AutomationSettings.browsersToRunWith.Split(',');
            foreach (String b in browsers)
            {
                yield return b;
            }

        }

        [OneTimeTearDown]
        public void FinalSteps()
        {
            // close the driver
            driver.Close();
            driver.Quit();
            extent.Flush();
        }


    }
}
