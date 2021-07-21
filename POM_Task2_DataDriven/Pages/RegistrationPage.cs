using System;
using NUnit.Framework;
using OpenQA.Selenium;
using POM_Task2_DataDriven.Utilities;
using static POM_Task2_DataDriven.Utilities.CommonMethods;

namespace POM_Task2_DataDriven.Pages
{
    public class RegistrationPage
    {
        private readonly IWebDriver driver;

        // Page Factory design pattern

        IWebElement Join => driver.FindElement(By.XPath("//button[contains(text(),'Join')]"));
        IWebElement FirstName => driver.FindElement(By.XPath("//input[@placeholder='First name']"));
        IWebElement LastName => driver.FindElement(By.XPath("//input[@placeholder='Last name']"));
        IWebElement EmailAddress => driver.FindElement(By.XPath("//input[@placeholder='Email address']"));
        IWebElement Password => driver.FindElement(By.XPath("//input[@placeholder='Password']"));
        IWebElement ConfirmPassword => driver.FindElement(By.XPath("//input[@placeholder='Confirm Password']"));
        IWebElement TermsAndConditions => driver.FindElement(By.XPath("//input[@name='terms']"));
        IWebElement JoinBtn => driver.FindElement(By.XPath("//div[@id='submit-btn']"));
        IWebElement Message => driver.FindElement(By.XPath("//div[contains(text(),'Registration successful')]"));

        // Create Contstructor
        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Methods Starts here

        public void ValidateIAmAtTheRegirstationPage()
        {
            bool isDisplayed =JoinBtn.Displayed;
            Assert.IsTrue(isDisplayed);
        }
        public void EnterValidCredentials()
        {
            try
            {
                //Eneter the First Name
                FirstName.SendKeys(ExcelLibHelper.ReadData(1, "FirstName"));

                //Eneter the Last Name
                LastName.SendKeys(ExcelLibHelper.ReadData(1, "LastName"));

                //Enete the Email Address
                EmailAddress.SendKeys(ExcelLibHelper.ReadData(1, "EmailAddress"));

                //Enter Password
                Password.SendKeys(ExcelLibHelper.ReadData(1, "Password"));

                //Enter Confirm Password
                ConfirmPassword.SendKeys(ExcelLibHelper.ReadData(1, "ConfirmPassword"));
            }
            catch (Exception msg)
            {
                Assert.Fail("Test failed at Join Page", msg.Message);
            }
        }
        public void ClickJoin()
        {
            Wait.ElementExists(driver, "Xpath", "//button[contains(text(),'Join')]",150);
            //Click Join
            Join.Click();
        }
        public void ClickToAgreeTermAndCondition()
        {
            //Click on AgreeTermsAndCondtions
            TermsAndConditions.Click();
        }
        public void ClickJoinButton()
        {
            //Click Join Button
            JoinBtn.Click();
        }
        public bool ValidateSucessMessage()
        {
            Wait.ElementExists(driver, "XPath", "//div[contains(text(),'Registration successful')]", 100);
            //Validate reistration Message
            if (Message.Text == ExcelLibHelper.ReadData(1, "RegistrationMessage"))
            {
                Console.WriteLine("Success message is displayed, Test Passed");
                return true;
            }
            else
            {
                Console.WriteLine("Success message is displayed, Test Passed");
                return false;
            }
        }

        // User Registration
        public void Registration()
        {
            ClickJoin();
            ValidateIAmAtTheRegirstationPage();
            EnterValidCredentials();
            ClickToAgreeTermAndCondition();
            ClickJoinButton();
            bool isRegistered = ValidateSucessMessage();
            Assert.IsTrue(isRegistered);
        }

    }
}
