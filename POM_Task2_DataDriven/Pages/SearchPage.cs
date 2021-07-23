using System;
using NUnit.Framework;
using OpenQA.Selenium;
using POM_Task2_DataDriven.Utilities;
using static POM_Task2_DataDriven.Utilities.CommonMethods;

namespace POM_Task2_DataDriven.Pages
{
    public class SearchPage
    {
        private readonly IWebDriver driver;
        private readonly SignInPage signIn;

        //page factory design pattern
        IWebElement SearchIcon => driver.FindElement(By.XPath("//i[@class='search link icon']"));
        IWebElement SearchSkillsBox => driver.FindElement(By.XPath("//section[@class='search-results']//input[@type='text'and @placeholder='Search skills']"));
        IWebElement SearchedSkill => driver.FindElement(By.XPath("//p[contains(text(),'Badminton')]"));
        IWebElement Online => driver.FindElement(By.XPath("//button[contains(text(),'Online')]"));

        //Create a Constructor
        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            signIn = new SignInPage(driver);
        }

        // 1. searching a skill from all categories
        public void SearchSkillsByAllCategories(string searchSkill)
        {
            signIn.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            ClickSearchIcon();
            EnterSearchSkill(searchSkill);
            ClickEnter();
        }

        // 2. searching a skill using filter
        public void SearchSkillsByFilters()
        {
            signIn.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            ClickSearchIcon();
            EnterSearchSkill(ExcelLibHelper.ReadData(1, "SearchSkillToAccept"));
            ClickEnter();
            ClickOnline();
            bool isSearchResult = ValidateSearchResult(ExcelLibHelper.ReadData(1, "SearchSkillToAccept"));
            Assert.IsTrue(isSearchResult);
        }

        public void ClickOnline()
        {
            //click online filter
            Online.Click();
        }

        public bool ValidateSearchResult(string searchSkill)
        {
            Wait.ElementExists(driver, "XPath", "//p[contains(text(),'Badminton')]", 100);
            //validate search result
            if (SearchedSkill.Text == searchSkill)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ClickEnter()
        {
            //click enter button
            SearchSkillsBox.SendKeys(Keys.Enter);
        }

        public void EnterSearchSkill(string skill)
        {
            //enter skill to search
            SearchSkillsBox.SendKeys(skill);
        }

        public void ClickSearchIcon()
        {
            //click search icon
            SearchIcon.Click();
        }
    }
}
