using AdvanceTaskMarsPart1.Data;
using AdvanceTaskMarsPart1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AdvanceTaskMarsPart1.Pages.Components.ProfileOverview
{
    public class AddAndUpdateSkillComponent : BaseSetUp
    {
        private IReadOnlyCollection<IWebElement> deleteButtons;
        private IWebElement SkillTextbox;
        private IWebElement SkillLevelDropdown;
        private IWebElement AddButton;
        private IWebElement successMessage;
        private IWebElement closeMessageIcon;
        private IWebElement UpdateNewButton;

        public void renderDeleteAllRecordsComponents()
        {
            try
            {
                deleteButtons = driver.FindElements(By.XPath("//div[@data-tab='second']//i[@class='remove icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderAddComponents()
        {
            try
            {
                SkillTextbox = driver.FindElement(By.CssSelector("input[placeholder='Add Skill']"));
                SkillLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));
                AddButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderAddMessage()
        {
            try
            {
                successMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                closeMessageIcon = driver.FindElement(By.XPath("//*[@class='ns-close']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderUpdateComponents()
        {
            try
            {
                SkillTextbox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
                SkillLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));
                UpdateNewButton = driver.FindElement(By.XPath("//input[@value='Update']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void DeleteAllRecords()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//div[@data-tab='second']//i[@class='remove icon']", 4);
            }
            catch (WebDriverTimeoutException e)
            {
                return;
            }
            renderDeleteAllRecordsComponents();
            //Delete all records in the list
            foreach (IWebElement deleteButton in deleteButtons)
            {
                deleteButton.Click();
            }
        }

        public void addSkill(SkillData skillData)
        {
            renderAddComponents();
            SkillTextbox.SendKeys(skillData.Skill);
            SelectElement chooseSkillLevel = new SelectElement(SkillLevelDropdown);
            chooseSkillLevel.SelectByText(skillData.SkillLevel);
            AddButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 4);
        }

        public string getMessage()
        {
            renderAddMessage();
            string message = successMessage.Text;
            closeMessageIcon.Click();
            Thread.Sleep(6000);
            return message;
        }

        public void updateSkill(SkillData newSkillData)
        {
            renderUpdateComponents();
            SkillTextbox.Clear();
            SkillTextbox.SendKeys(newSkillData.Skill);
            SelectElement chooseSkillLevel = new SelectElement(SkillLevelDropdown);
            chooseSkillLevel.SelectByValue(newSkillData.SkillLevel);
            UpdateNewButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 4);
        }
    }
}
