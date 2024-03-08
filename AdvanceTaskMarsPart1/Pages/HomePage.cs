using AdvanceTaskMarsPart1.Utilities;
using OpenQA.Selenium;

namespace AdvanceTaskMarsPart1.Pages
{
    public class HomePage : CommonDriver
    {
        private IWebElement skillsTab        => driver.FindElement(By.XPath("//a[text()='Skills']"));
        private IWebElement ShareSkillButton => driver.FindElement(By.XPath("//a[text()='Share Skill']"));

        public void GoToSkillsPage()
        {
            Wait.WaitToBeClickable("XPath", "//a[text()='Skills']", 4);
            skillsTab.Click();
        }

        public void GoToShareSkillPage()
        {
            Wait.WaitToBeClickable("XPath", "//a[text()='Share Skill']", 4);
            ShareSkillButton.Click();
        }
    }
}
