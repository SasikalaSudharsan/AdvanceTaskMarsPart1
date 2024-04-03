using AdvanceTaskMarsPart1.Data;
using AdvanceTaskMarsPart1.Utilities;
using OpenQA.Selenium;

namespace AdvanceTaskMarsPart1.Pages.Components
{
    public class ShareSkillOverviewComponent : BaseSetUp
    {
        private IWebElement ShareSkillButton;
        private IWebElement ManageListingsTab;
        private IWebElement UpdateButton;
        private IWebElement DeleteButton;
        private IWebElement YesButton;

        public void renderShareSkill()
        {
            try
            {
                ShareSkillButton = driver.FindElement(By.XPath("//a[text()='Share Skill']"));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderManageListings()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Manage Listings']", 4);
                ManageListingsTab = driver.FindElement(By.XPath("//a[text()='Manage Listings']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        
        public void renderUpdateButton(string existingTitle)
        {
            try
            {
                UpdateButton = driver.FindElement(By.XPath($"//td[text()='{existingTitle}']/following-sibling::td/div/button[@class='ui button']/i[@class='outline write icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderDeleteButton(string title)
        {
            try
            {
                DeleteButton = driver.FindElement(By.XPath($"//td[text()='{title}']/following-sibling::td/div/button[@class='ui button']/i[@class='remove icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderYesButton()
        {
            try
            {
                YesButton = driver.FindElement(By.XPath("//button[@class='ui icon positive right labeled button']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void clickShareSkillButton()
        {
            Thread.Sleep(4000);
            renderShareSkill();
            ShareSkillButton.Click();
        }

        public void clickManageListings()
        {
            renderManageListings();
            ManageListingsTab.Click();
        }

        public void clickUpdateButton(ShareSkillData shareSkillData)
        {
            string existingTitle = shareSkillData.ExistingTitle;
            Thread.Sleep(4000);
            renderUpdateButton(existingTitle);
            UpdateButton.Click();
        }

        public void clickDeleteButton(ShareSkillData shareSkillData)
        {
            string title = shareSkillData.Title;
            Thread.Sleep(4000);
            renderDeleteButton(title);
            DeleteButton.Click();
            renderYesButton();
            YesButton.Click();
        }
    }
}
