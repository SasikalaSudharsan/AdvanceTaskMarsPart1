using AdvanceTaskMarsPart1.Data;
using AdvanceTaskMarsPart1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AdvanceTaskMarsPart1.Pages
{
    public class SkillPage : CommonDriver
    {
        private IReadOnlyCollection<IWebElement> deleteButtons => driver.FindElements(By.XPath("//div[@data-tab='second']//i[@class='remove icon']"));
        private IWebElement AddNewButton                       => driver.FindElement(By.XPath("//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//th[@class='right aligned']//div"));
        private IWebElement SkillTextbox                       => driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
        private IWebElement SkillLevelDropdown                 => driver.FindElement(By.XPath("//select[@name='level']"));
        private IWebElement AddButton                          => driver.FindElement(By.XPath("//input[@value='Add']"));
        private IWebElement successMessage                     => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        private Func<string, IWebElement> newSkill      = skill      => driver.FindElement(By.XPath($"//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{skill}']"));
        private Func<string, IWebElement> newSkillLevel = skilllevel => driver.FindElement(By.XPath($"//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{skilllevel}']"));
        private IWebElement CancelButton                => driver.FindElement(By.XPath("//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//input[@value='Cancel']"));
        private IWebElement UpdateNewButton             => driver.FindElement(By.XPath("//input[@value='Update']"));

        public void Delete_All_Records()
        {
            try
            {
                Thread.Sleep(4000);
               // Wait.WaitToBeClickable("XPath", "//div[@data-tab='second']//i[@class='remove icon']", 4);
            }
            catch (WebDriverTimeoutException e)
            {
                return;
            }
            //Delete all records in the list
            foreach (IWebElement deleteButton in deleteButtons)
            {
                deleteButton.Click();
            }
        }

        public void Add_Skill(SkillData skilldata)
        {
            Thread.Sleep(4000);
            AddNewButton.Click();
            SkillTextbox.SendKeys(skilldata.Skill);
            SelectElement chooseSkillLevel = new SelectElement(SkillLevelDropdown);
            chooseSkillLevel.SelectByText(skilldata.SkillLevel);
            AddButton.Click();
        }

        public string getMessage()
        {
            Wait.WaitToExist("XPath", "//div[@class='ns-box-inner']", 4);
            return successMessage.Text;
        }

        public string getSkill(string skill)
        {
            Thread.Sleep(4000);
            return newSkill(skill).Text;
        }

        public string getSkillLevel(string skilllevel)
        {
            Thread.Sleep(4000);
            return newSkillLevel(skilllevel).Text;
        }

        public void getCancel()
        {
            try
            {
                CancelButton.Click();
            }
            catch (NoSuchElementException)
            {
                return;
            }
        }

        public void Update_Skill(SkillData existingSkilldata, SkillData newSkillData)
        {
            Thread.Sleep(4000);
            IWebElement UpdateButton = driver.FindElement(By.XPath($"//div[@data-tab='second']//tr[td[1]='{existingSkilldata.Skill}' and td[2]='{existingSkilldata.SkillLevel}']//td[last()]/span[1]"));
            UpdateButton.Click();
            SkillTextbox.Clear();
            SkillTextbox.SendKeys(newSkillData.Skill);
            SelectElement chooseSkillLevel = new SelectElement(SkillLevelDropdown);
            chooseSkillLevel.SelectByValue(newSkillData.SkillLevel);
            UpdateNewButton.Click();
        }

        public void Delete_Skill(SkillData skillData)
        {
            Thread.Sleep(4000);
            //Click the delete button that needs to be deleted
            string xpath = $@"//div[@data-tab='second']//tr[td[1]='{skillData.Skill}' and td[2]='{skillData.SkillLevel}']//td[last()]/span[2]";
            IWebElement DeleteButton = driver.FindElement(By.XPath(xpath));
            DeleteButton.Click();
        }

        public string getDeletedSkill(SkillData skillData)
        {
            Thread.Sleep(4000);
            try
            {
                string xpath = $@"//div[@data-tab='second']//tr[td[1]='{skillData.Skill}' and td[2]='{skillData.SkillLevel}']";
                IWebElement DeletedSkill = driver.FindElement(By.XPath(xpath));
                return DeletedSkill.Text;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }
    }
}
