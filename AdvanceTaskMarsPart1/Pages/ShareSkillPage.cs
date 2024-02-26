using AdvanceTaskMarsPart1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AdvanceTaskMarsPart1.Pages
{
    public class ShareSkillPage : CommonDriver
    {
        private IWebElement TitleTextbox => driver.FindElement(By.XPath("//input[@name='title']"));
        private IWebElement DescriptionTextbox => driver.FindElement(By.XPath("//textarea[@name='description']"));
        private IWebElement CategoryDropdown => driver.FindElement(By.XPath("//select[@name='categoryId']"));
        private IWebElement SubcategoryDropdown => driver.FindElement(By.XPath("//select[@name='subcategoryId']"));
        private IWebElement TagsTextbox => driver.FindElement(By.XPath("(//input[contains(@placeholder,'Add new tag')])[1]"));
        private IWebElement ServiceTypeRadioButton => driver.FindElement(By.XPath("//div[@class='ui radio checkbox']//label[contains(text(),'Hourly basis service')]"));
        private IWebElement LocationTypeRadioButton => driver.FindElement(By.XPath("//div[@class='ui radio checkbox']//label[contains(text(),'On-site')]"));
        private IWebElement StartDate => driver.FindElement(By.XPath("//input[@placeholder='Start date']"));
        private IWebElement EndDate => driver.FindElement(By.XPath("//input[@placeholder='End date']"));
        private IWebElement SkillTradeRadioButton => driver.FindElement(By.XPath("//div[@class='ui radio checkbox']//label[contains(text(),'Credit')]/preceding-sibling::input[@type='radio']"));
        private IWebElement CreditTextbox => driver.FindElement(By.XPath("//input[@placeholder='Amount']"));
        private IWebElement ActiveRadioButton => driver.FindElement(By.XPath("//div[@class='ui radio checkbox']//label[contains(text(),'Active')]"));
        private IWebElement SaveButton => driver.FindElement(By.XPath("//input[@value='Save']"));

        public void Add_ShareSkill()
        {
            Thread.Sleep(4000);            
            TitleTextbox.SendKeys("Selenium");            
            DescriptionTextbox.SendKeys("Selenium with Java");
            SelectElement chooseCategory = new SelectElement(CategoryDropdown);
            chooseCategory.SelectByText("Programming & Tech");            
            SelectElement chooseSubcategory = new SelectElement(SubcategoryDropdown);
            chooseSubcategory.SelectByText("QA");            
            TagsTextbox.SendKeys("Selenium");
            TagsTextbox.SendKeys(Keys.Enter);            
            ServiceTypeRadioButton.Click();            
            LocationTypeRadioButton.Click();            
            StartDate.SendKeys("03/01/2024");            
            EndDate.SendKeys("03/29/2024");            
            SkillTradeRadioButton.Click();
            Thread.Sleep(4000);            
            CreditTextbox.SendKeys("5");            
            ActiveRadioButton.Click();            
            SaveButton.Click();
        }

        public string getMessage()
        {
            Thread.Sleep(2000);
            IWebElement successMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            return successMessage.Text;
        }

        public void ManageListings()
        {
            Thread.Sleep(4000);
            IWebElement ManageListingsTab = driver.FindElement(By.XPath("//a[text()='Manage Listings']"));
            ManageListingsTab.Click();
        }

        public string getTitle(string title)
        {
            Thread.Sleep(4000);
            IWebElement newTitle = driver.FindElement(By.XPath($"//td[@class='four wide'][text()='{title}'][1]"));
            return newTitle.Text;
        }

        public void Update_ShareSkill()
        {
            Thread.Sleep(4000);
            IWebElement ManageListingsTab = driver.FindElement(By.XPath("//a[text()='Manage Listings']"));
            ManageListingsTab.Click();
            Thread.Sleep(4000);
            IWebElement UpdateButton = driver.FindElement(By.XPath("//td[text()='Selenium']/following-sibling::td/div/button[@class='ui button']/i[@class='outline write icon']"));
            UpdateButton.Click();
            Thread.Sleep(4000);
            TitleTextbox.Clear();
            TitleTextbox.SendKeys("Nunit");
            DescriptionTextbox.Clear();
            DescriptionTextbox.SendKeys("Nunit framework");
            StartDate.SendKeys("03/02/2024");
            EndDate.SendKeys("03/30/2024");
            SaveButton.Click() ;
        }
    }
}
