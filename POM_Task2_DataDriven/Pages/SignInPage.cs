using System;
using NUnit.Framework;
using OpenQA.Selenium;
using POM_Task2_DataDriven.Utilities;

namespace POM_Task2_DataDriven.Pages
{
    public class SignInPage
    {
        private readonly IWebDriver driver;

        //creat a constructor
        public SignInPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        

        //page factory
        IWebElement SignIn => driver.FindElement(By.XPath("//a[contains(text(),'Sign In')]"));
        IWebElement EmailAddress => driver.FindElement(By.XPath("//input[@placeholder='Email address']"));
        IWebElement Password => driver.FindElement(By.XPath("//input[@placeholder='Password']"));
        IWebElement LoginButton => driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));
        IWebElement SignOut => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/a[2]/button"));

        // Methods Start Here
        public void ClickSignIn()
        {
            Wait.ElementExists(driver, "XPath", "//a[contains(text(),'Sign In')]", 50);
            //click sign in 
            SignIn.Click();
        }
        public void ValidateYouAreAtLoginPage()
        {
            //Validate that I am in the login Page
            Wait.ElementExists(driver, "XPath", "//button[contains(text(),'Login')]", 50);
            bool isLoginPage =LoginButton.Displayed;
            Assert.IsTrue(isLoginPage);
        }
        
         
        //public bool wValidateYouAreAtLoginPage()
        //{
        //    return LoginButton.Displayed;
        //}

        public void EnterEmailAndPassword(string email, string password)
        {
            try
            {
                //enter email address
                EmailAddress.SendKeys(email);
                Console.WriteLine("Enter Eamil Address" + email);

                //eneter password
                Password.SendKeys(password);
                Console.WriteLine("Enter Password"+ password);
            }
            catch (Exception msg)
            {
                Assert.Fail("Test Failed at SignIn Page", msg.Message);
            }
            
        }

        public void ClickLoginButton()
        {
            //Click login Butoon
            LoginButton.Click();
        }

        public bool ValidateYouAreLoggedInSuccessfully()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/a[2]/button", 10);
            return SignOut.Displayed;
        }


        public void Login(string emailValue, string passwordValue)
        {
            ClickSignIn();
            ValidateYouAreAtLoginPage();
            EnterEmailAndPassword(emailValue, passwordValue);
            ClickLoginButton();
            bool IsLoggedIn = ValidateYouAreLoggedInSuccessfully();
            Assert.IsTrue(IsLoggedIn);
        }
    }
}
