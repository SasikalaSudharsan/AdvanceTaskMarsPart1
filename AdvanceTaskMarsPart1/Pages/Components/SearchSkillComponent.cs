using AdvanceTaskMarsPart1.Data;
using AdvanceTaskMarsPart1.Utilities;
using OpenQA.Selenium;

namespace AdvanceTaskMarsPart1.Pages.Components.ProfileOverview
{
    public class SearchSkillComponent : BaseSetUp
    {
        private IWebElement SearchSkillsButton;
        private IWebElement SearchButton;
        private IWebElement SelectCategory;
        private IWebElement SelectSubcategory;
        private IReadOnlyCollection<IWebElement> SkillList;
        private IWebElement Message;
        private IWebElement OnlineButton;

        public void renderSearchskill()
        {
            try
            {
                SearchSkillsButton = driver.FindElement(By.XPath("//input[@placeholder='Search skills']"));
                SearchButton = driver.FindElement(By.XPath("//input[@placeholder='Search skills']//following-sibling::i[@class='search link icon']"));

    }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderSearchSkillCategory()
        {
            try
            {
                SelectCategory = driver.FindElement(By.XPath("//a[text()='Programming & Tech']"));
    }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderSearchSkillSubcategory()
        {
            try
            {
                SelectSubcategory = driver.FindElement(By.XPath("//a[text()='QA']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        
        public void renderSkillList()
        {
            try
            {
                SkillList = driver.FindElements(By.XPath("//div[@class='ui card']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderAddMessage()
        {
            try
            {
                Message = driver.FindElement(By.XPath("//div[@class='ui grid']/h3"));
    }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderSearchSkillFilters()
        {
            try
            {
                OnlineButton = driver.FindElement(By.XPath("//button[text()='Online']"));
    }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void clickSearchButton(SearchSkillData searchSkillData)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//input[@placeholder='Search skills']", 4);
            renderSearchskill();
            SearchSkillsButton.Click();
            SearchSkillsButton.SendKeys(searchSkillData.SearchSkill);
            SearchButton.Click();
        }

        public void SearchSkillCategory()
        {
            Thread.Sleep(4000);
            renderSearchSkillCategory();
            SelectCategory.Click();
        }

        public void SearchSkillSubcategory()
        {
            renderSearchSkillSubcategory();
            SelectSubcategory.Click();
        }

        public List<IWebElement> getSkillList()
        {
            Thread.Sleep(4000);
            renderSkillList();
            if (SkillList == null)
            {
                // If SkillList is null, return an empty list
                return new List<IWebElement>();
            }
            return new List<IWebElement>(SkillList);
        }

        public string getMessage()
        {
            Thread.Sleep(4000);
            renderAddMessage();
            return Message.Text;
        }

        public void SearchSkillFilters()
        {
            Thread.Sleep(4000);
            renderSearchSkillFilters();
            OnlineButton.Click();
        }
    }
}
