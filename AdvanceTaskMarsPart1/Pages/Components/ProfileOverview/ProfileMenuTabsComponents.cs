using AdvanceTaskMarsPart1.Utilities;
using OpenQA.Selenium;

namespace AdvanceTaskMarsPart1.Pages.Components.ProfileOverview
{
    public class ProfileMenuTabsComponents : BaseSetUp
    {
        private IWebElement LanguageTab;
        private IWebElement skillsTab;
        private IWebElement ShareSkillButton;

        public void renderComponents()
        {
            try
            {
                LanguageTab = driver.FindElement(By.XPath("//a[text()='Languages']"));
                skillsTab = driver.FindElement(By.XPath("//a[text()='Skills']"));
                ShareSkillButton = driver.FindElement(By.XPath("//a[text()='Share Skill']"));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void clickLanguageTab()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Languages']", 4);
            renderComponents();
            LanguageTab.Click();
            Thread.Sleep(4000);
        }

        public void clickSkillsTab()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Skills']", 4);
            renderComponents();
            skillsTab.Click();
            Thread.Sleep(4000);
        }

        public void clickShareSkillButton()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Share Skill']", 4);
            renderComponents();
            ShareSkillButton.Click();
        }
    }
}
