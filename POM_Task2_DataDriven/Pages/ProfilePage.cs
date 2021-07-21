using System;
using OpenQA.Selenium;
using POM_Task2_DataDriven.Utilities;
using static POM_Task2_DataDriven.Utilities.CommonMethods;

namespace POM_Task2_DataDriven.Pages
{
    public class ProfilePage
    {
        private readonly IWebDriver driver;

        // Create Constructor
        public ProfilePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Page Factory
        IWebElement DescriptionText => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3"));
        IWebElement DescriptionIcon => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i"));
        IWebElement Description => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea"));
        IWebElement SavedDescription => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button"));
        //IWebElement SavedDescription => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span"));
        IWebElement AddNewLanguage => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        IWebElement AddNewSkill => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
        IWebElement Language => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
        IWebElement LanguageLevel => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[2]"));
        IWebElement AddLanguage => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
        private IWebElement lastEntryResult_Lang => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        // #################UPDATE PAGE FACTORY ############
        private IWebElement clickEditBtn => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i"));
        private IWebElement editLang => driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        private IWebElement dropDown_edit_Lang => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select/option[5]"));
        private IWebElement updateBtnLang => driver.FindElement(By.XPath("//input[@value='Update']"));
        IWebElement EditLanguageTxt => driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        // #################DELETE PAGE FACTORY ############
        private IWebElement delete_Language => driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[3]/span[2]/i[1]"));
        private IWebElement Lang_title => driver.FindElement(By.XPath("//h3[normalize-space()='Languages']"));

        private IWebElement deleteValidation => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        IWebElement AddSkill => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
        IWebElement SkillsTab => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
        IWebElement AddNewBtnSkill => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
        IWebElement Skill => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
        IWebElement SkillLevel => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option[2]"));
        IWebElement AddedLanguage => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
        IWebElement AddedSkill => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
        IWebElement Message => driver.FindElement(By.XPath("/html/body/div[1]/div"));

        //reading data from file
        private string descrip = ExcelLibHelper.ReadData(1, "Description");
        private string language = ExcelLibHelper.ReadData(1, "CreateLanguage");
        private string editLanguage = ExcelLibHelper.ReadData(1, "EditLanguage");
        private string createSkill = ExcelLibHelper.ReadData(1, "CreateSkill");
        private string editSkill = ExcelLibHelper.ReadData(1, "EditSkill");
        private string createEducation = ExcelLibHelper.ReadData(1, "CreateEducation");
        private string editEducation = ExcelLibHelper.ReadData(1, "EditEducation");
        private string createCertification = ExcelLibHelper.ReadData(1, "CreateCertification");
        private string editCertification = ExcelLibHelper.ReadData(1, "CreateCertification");


        public bool ValidateProfilePage()
        {
            Wait.ElementExists(driver, "XPath", "//h3[normalize-space()='Description']", 20);
            return DescriptionText.Displayed;
        }

        //Description Field
        public void RunDescription()
        {
            ClickDescription();
            EnterDescription(descrip);
            ClickSave();
        }
        public void ClickDescription()
        {
            DescriptionIcon.Click();
        }
        public void EnterDescription(string description)
        {
            //Enter description
            Description.Clear();
            Description.SendKeys(description);
            Console.WriteLine("Enter Description" + description);
        }
        public void ClickSave()
        {
            SavedDescription.Click();
        }

        //Create Language Fileds
        public void CreateLanguage()
        {
            //Wait.ElementExists(driver, "XPath", "AddNewLanguage", 100);
            ClickAddNewLanguage();
            EnterLanguage(language);
            chooseLangugaeLevel();
            ClickAddLanguage();
           // Wait.ElementExists(driver, "XPath", "ClickAddLanguage", 10);
            validateLanguage_created();

        }
        public void ClickAddNewLanguage()
        {

            AddNewLanguage.Click();
        }
        public void EnterLanguage(string language)
        {
            Language.SendKeys(language);
        }
        public void chooseLangugaeLevel()
        {
            LanguageLevel.Click();
        }
        public void ClickAddLanguage()
        {
            AddLanguage.Click();
        }
        public bool validateLanguage_created()
        {
            IWebElement actualResult = lastEntryResult_Lang;
            //Assert.That(actualResult.Text, Is.EqualTo("Java"), "Test Failed");
            Console.WriteLine(actualResult + "----->>>>>>");
            if (actualResult.Text == "Create Language")
            {
                Console.WriteLine("Language is created Successfully!!, Test Pass!!");
                return true;

            }
            else
            {
                Console.WriteLine("Language is not created, Test Failed!!!!");
                return false;

            }
        }

        // Edit Language Fields
        public void ClickEditIcon()
        {
            clickEditBtn.Click();
        }
        public void editLanguageTxt(string editLanguage)
        {
            EditLanguageTxt.Clear();
            EditLanguageTxt.SendKeys(editLanguage);
        }
        public void editChooseLanguage()
        {
            dropDown_edit_Lang.Click();
        }
        public void clickUpdateLanguage()
        {
            updateBtnLang.Click();
        }

        public bool validateUpdate_Lang()
        {
            string name = lastEntryResult_Lang.Text;
            if (lastEntryResult_Lang.Text == "Edit Language")
            {
                Console.WriteLine("Updated Language is created Successfully!!Test Pass====>>>" + name);
                return true;

            }
            else
            {
                Console.WriteLine("Updated Language is not created, Test Failed!!!!");
                return false;

            }
        }

        public void EditLanguage()
        {
            //Wait.ElementExists(driver, "XPath", "ClickAddLanguage", 30);
            ClickEditIcon();
            editLanguageTxt(editLanguage);
            editChooseLanguage();
            clickUpdateLanguage();
            validateUpdate_Lang();
        }

        //Delete Language
        public void clickDeleteLanguage()
        {
            delete_Language.Click();
        }

        public void validateDeleteItem()
        {
            //IWebElement deleteValidation = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            string deleteTxt = deleteValidation.Text;
            Console.WriteLine("Delete message from pop up ========>>>>>>>> " + deleteTxt);
        }

        public void DeleteLanguage()
        {
            //Wait.ElementExists(driver, "XPath", "delete_Language", 50);
            clickDeleteLanguage();
            validateDeleteItem();
        }

        // create Skills Fileds
        public void CreateSkills()
        {
            ClickAddNewSkill();
            EnterSkill(createSkill);
            chooseSkills();
            addSkillBtn();
        }
        public void ClickAddNewSkill()
        {
            SkillsTab.Click();
            AddNewBtnSkill.Click();
        }
        public void EnterSkill(string createSkill)
        {
            //Enter Skill
            Skill.SendKeys(createSkill);
        }
        public void chooseSkills()
        {
            SkillLevel.Click();
        }
        public void addSkillBtn()
        {
            AddSkill.Click();
           
        }
        public void validateSkillCreated()
        {

        }

        // Update Skills Fileds

        public void UpdateSkill()
        {
            Wait.ElementExists(driver, "XPath", "ClickUpdateIcon", 20);
            ClickUpdateIcon();
            enterUpdateSkill(editSkill);
            chooseUpdateSkillLevel();
            addSkillUpdateBtn();

        }
        public void ClickUpdateIcon()
        {
            clickEditBtn.Click();
        }
        public void enterUpdateSkill(string editSkill)
        {
            Skill.Clear();
            Skill.SendKeys(editSkill);
        }
        public void chooseUpdateSkillLevel()
        {
            SkillLevel.Click();
        }
        public void addSkillUpdateBtn()
        {
            AddSkill.Click();
        }





    }


}