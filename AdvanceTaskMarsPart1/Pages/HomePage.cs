using AdvanceTaskMarsPart1.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart1.Pages
{
    public class HomePage : CommonDriver
    {
        private IWebElement skillsTab => driver.FindElement(By.XPath("//a[text()='Skills']"));

        public void GoToSkillsPage()
        {
            Wait.WaitToBeClickable("XPath", "//a[text()='Skills']", 4);
            skillsTab.Click();
        }
    }
}
