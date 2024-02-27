using AdvanceTaskMarsPart1.Data;
using AdvanceTaskMarsPart1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AdvanceTaskMarsPart1.Pages
{
    public class ShareSkillPage : CommonDriver
    {
        private IWebElement TitleTextbox            => driver.FindElement(By.XPath("//input[@name='title']"));
        private IWebElement DescriptionTextbox      => driver.FindElement(By.XPath("//textarea[@name='description']"));
        private IWebElement CategoryDropdown        => driver.FindElement(By.XPath("//select[@name='categoryId']"));
        private IWebElement SubcategoryDropdown     => driver.FindElement(By.XPath("//select[@name='subcategoryId']"));
        private IWebElement TagsTextbox             => driver.FindElement(By.XPath("(//input[contains(@placeholder,'Add new tag')])[1]"));
        private IWebElement ServiceTypeRadioButton  => driver.FindElement(By.XPath("//div[@class='ui radio checkbox']//label[contains(text(),'Hourly basis service')]"));
        private IWebElement LocationTypeRadioButton => driver.FindElement(By.XPath("//div[@class='ui radio checkbox']//label[contains(text(),'On-site')]"));
        private IWebElement StartDate               => driver.FindElement(By.XPath("//input[@placeholder='Start date']"));
        private IWebElement EndDate                 => driver.FindElement(By.XPath("//input[@placeholder='End date']"));
        private IWebElement SkillTradeRadioButton   => driver.FindElement(By.XPath("//div[@class='ui radio checkbox']//label[contains(text(),'Credit')]/preceding-sibling::input[@type='radio']"));
        private IWebElement CreditTextbox           => driver.FindElement(By.XPath("//input[@placeholder='Amount']"));
        private IWebElement ActiveRadioButton       => driver.FindElement(By.XPath("//div[@class='ui radio checkbox']//label[contains(text(),'Active')]"));
        private IWebElement SaveButton              => driver.FindElement(By.XPath("//input[@value='Save']"));
        private IWebElement ManageListingsTab       => driver.FindElement(By.XPath("//a[text()='Manage Listings']"));
        private IWebElement successMessage          => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        private Func<string, IWebElement> newTitle = title => driver.FindElement(By.XPath($"//td[@class='four wide'][text()='{title}'][1]"));
        private IWebElement YesButton               => driver.FindElement(By.XPath("//button[@class='ui icon positive right labeled button']"));

        public void Add_ShareSkill(ShareSkillData shareSkillData)
        {
            Thread.Sleep(4000);            
            TitleTextbox.SendKeys(shareSkillData.Title);            
            DescriptionTextbox.SendKeys(shareSkillData.Description);
            SelectElement chooseCategory = new SelectElement(CategoryDropdown);
            chooseCategory.SelectByText(shareSkillData.Category);            
            SelectElement chooseSubcategory = new SelectElement(SubcategoryDropdown);
            chooseSubcategory.SelectByText(shareSkillData.Subcategory);            
            TagsTextbox.SendKeys(shareSkillData.Tags);
            TagsTextbox.SendKeys(Keys.Enter);            
            ServiceTypeRadioButton.Click();            
            LocationTypeRadioButton.Click();            
            StartDate.SendKeys(shareSkillData.StartDate);            
            EndDate.SendKeys(shareSkillData.EndDate);            
            SkillTradeRadioButton.Click();
            Thread.Sleep(4000);            
            CreditTextbox.SendKeys(shareSkillData.Credit);            
            ActiveRadioButton.Click();            
            SaveButton.Click();
        }

        public string getMessage()
        {
            Thread.Sleep(2000);            
            return successMessage.Text;
        }

        public void ManageListings()
        {
            Thread.Sleep(4000);
            ManageListingsTab.Click();
        }

        public string getTitle(string title)
        {
            Thread.Sleep(4000);
            return newTitle(title).Text;
        }

        public void Update_ShareSkill(ShareSkillData shareSkillData)
        {
            Thread.Sleep(4000);            
            ManageListingsTab.Click();
            Thread.Sleep(4000);
            IWebElement UpdateButton = driver.FindElement(By.XPath($"//td[text()='{shareSkillData.ExistingTitle}']/following-sibling::td/div/button[@class='ui button']/i[@class='outline write icon']"));
            UpdateButton.Click();
            Thread.Sleep(4000);
            TitleTextbox.Clear();
            TitleTextbox.SendKeys(shareSkillData.Title);
            DescriptionTextbox.Clear();
            DescriptionTextbox.SendKeys(shareSkillData.Description);
            StartDate.SendKeys(shareSkillData.StartDate);
            EndDate.SendKeys(shareSkillData.EndDate);
            SaveButton.Click() ;
        }

        public void Delete_ShareSkill(ShareSkillData shareSkillData)
        {
            Thread.Sleep(4000);
            ManageListingsTab.Click() ;
            Thread.Sleep(4000);
            IWebElement DeleteButton = driver.FindElement(By.XPath($"//td[text()='{shareSkillData.Title}']/following-sibling::td/div/button[@class='ui button']/i[@class='remove icon']"));
            DeleteButton.Click();            
            YesButton.Click();
        }
    }
}
