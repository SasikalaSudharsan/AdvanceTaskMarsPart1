using AdvanceTaskMarsPart1.Data;
using AdvanceTaskMarsPart1.Utilities;
using OpenQA.Selenium;

namespace AdvanceTaskMarsPart1.Pages
{
    public class SearchSkillsPage : CommonDriver
    {
        private IWebElement SearchSkillsButton => driver.FindElement(By.XPath("//input[@placeholder='Search skills']"));
        private IWebElement SearchButton       => driver.FindElement(By.XPath("//input[@placeholder='Search skills']//following-sibling::i[@class='search link icon']"));
        private IWebElement SelectCategory     => driver.FindElement(By.XPath("//a[text()='Programming & Tech']"));
        private IWebElement SelectSubcategory  => driver.FindElement(By.XPath("//a[text()='QA']"));
        private IReadOnlyCollection<IWebElement> SkillList => driver.FindElements(By.XPath("//div[@class='ui card']"));
        private IWebElement OnlineButton       => driver.FindElement(By.XPath("//button[text()='Online']"));
        private IWebElement Message            => driver.FindElement(By.XPath("//div[@class='ui grid']/h3"));

        public void SearchSkills_Categories(SearchSkillData searchSkillData)
        {
            Wait.WaitToBeClickable("XPath", "//input[@placeholder='Search skills']", 4);
            SearchSkillsButton.Click();
            SearchSkillsButton.SendKeys(searchSkillData.SearchSkill);
            SearchButton.Click();
            Wait.WaitToBeClickable("XPath", "//a[text()='Programming & Tech']", 4);
            SelectCategory.Click();            
            SelectSubcategory.Click();
        }
            
        public List<IWebElement> getSkillList()
        {
            Thread.Sleep(4000);
            return new List<IWebElement>(SkillList);
        }

        public string getMessage()
        {
            Thread.Sleep(4000);            
            return Message.Text;
        }

        public void SearchSkills_Filters(SearchSkillData searchSkillData)
        {
            Wait.WaitToBeClickable("XPath", "//input[@placeholder='Search skills']", 4);
            SearchSkillsButton.Click();
            SearchSkillsButton.SendKeys(searchSkillData.SearchSkill);
            SearchButton.Click();
            Wait.WaitToBeClickable("XPath", "//button[text()='Online']", 4);
            OnlineButton.Click();
        }
    }
}
