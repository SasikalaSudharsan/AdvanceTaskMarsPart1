using AdvanceTaskMarsPart1.Data;
using AdvanceTaskMarsPart1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AdvanceTaskMarsPart1.Pages.Components
{
    public class AddAndUpdateShareSkillComponents : BaseSetUp
    {
        private IWebElement TitleTextbox;
        private IWebElement DescriptionTextbox;
        private IWebElement CategoryDropdown;
        private IWebElement SubcategoryDropdown;
        private IWebElement TagsTextbox;
        private IWebElement ServiceTypeRadioButton;
        private IWebElement LocationTypeRadioButton;
        private IWebElement StartDate;
        private IWebElement EndDate;
        private IWebElement SkillTradeRadioButton;
        private IWebElement CreditTextbox;
        private IWebElement ActiveRadioButton;
        private IWebElement SaveButton;
        private IWebElement newTitle;
        private IWebElement successMessage;

        public void renderAddComponents()
        {
            try
            {
                TitleTextbox = driver.FindElement(By.XPath("//input[@name='title']"));
                DescriptionTextbox = driver.FindElement(By.XPath("//textarea[@name='description']"));
                TagsTextbox = driver.FindElement(By.XPath("(//input[contains(@placeholder,'Add new tag')])[1]"));
                ServiceTypeRadioButton = driver.FindElement(By.XPath("//div[@class='ui radio checkbox']//label[contains(text(),'Hourly basis service')]"));
                LocationTypeRadioButton = driver.FindElement(By.XPath("//div[@class='ui radio checkbox']//label[contains(text(),'On-site')]"));
                StartDate = driver.FindElement(By.XPath("//input[@placeholder='Start date']"));
                EndDate = driver.FindElement(By.XPath("//input[@placeholder='End date']"));
                SkillTradeRadioButton = driver.FindElement(By.XPath("//div[@class='ui radio checkbox']//label[contains(text(),'Credit')]/preceding-sibling::input[@type='radio']"));
                ActiveRadioButton = driver.FindElement(By.XPath("//div[@class='ui radio checkbox']//label[contains(text(),'Active')]"));
                SaveButton = driver.FindElement(By.XPath("//input[@value='Save']"));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderCategory()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//select[@name='categoryId']", 4);
                CategoryDropdown = driver.FindElement(By.XPath("//select[@name='categoryId']"));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderSubcategory()
        {
            try
            {
                SubcategoryDropdown = driver.FindElement(By.XPath("//select[@name='subcategoryId']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderCredit()
        {
            try
            {
                CreditTextbox = driver.FindElement(By.XPath("//input[@placeholder='Amount']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderTitle(string title)
        {
            try
            {
                newTitle = driver.FindElement(By.XPath($"//td[@class='four wide'][text()='{title}'][1]"));
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
                Wait.WaitToBeVisible(driver, "XPath", "//input[@name='title']", 4);
                TitleTextbox = driver.FindElement(By.XPath("//input[@name='title']"));
                DescriptionTextbox = driver.FindElement(By.XPath("//textarea[@name='description']"));
                StartDate = driver.FindElement(By.XPath("//input[@placeholder='Start date']"));
                EndDate = driver.FindElement(By.XPath("//input[@placeholder='End date']"));
                SaveButton = driver.FindElement(By.XPath("//input[@value='Save']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderMessage()
        {
            try
            {
                Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 4);
                successMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void addShareSkill(ShareSkillData shareSkillData)
        {
            renderAddComponents();
            TitleTextbox.SendKeys(shareSkillData.Title);
            DescriptionTextbox.SendKeys(shareSkillData.Description);
            renderCategory();
            SelectElement chooseCategory = new SelectElement(CategoryDropdown);
            chooseCategory.SelectByText(shareSkillData.Category);
            renderSubcategory();
            SelectElement chooseSubcategory = new SelectElement(SubcategoryDropdown);
            chooseSubcategory.SelectByText(shareSkillData.Subcategory);
            TagsTextbox.SendKeys(shareSkillData.Tags);
            TagsTextbox.SendKeys(Keys.Enter);
            ServiceTypeRadioButton.Click();
            LocationTypeRadioButton.Click();
            StartDate.SendKeys(shareSkillData.StartDate);
            EndDate.SendKeys(shareSkillData.EndDate);
            SkillTradeRadioButton.Click();
            renderCredit();
            CreditTextbox.SendKeys(shareSkillData.Credit);
            ActiveRadioButton.Click();
            SaveButton.Click();
        }

        public string getTitle(string title)
        {
            Thread.Sleep(6000);
            renderTitle(title);
            return newTitle.Text;
        }

        public void updateShareSkill(ShareSkillData shareSkillData)
        {
            renderUpdateComponents();
            TitleTextbox.Clear();
            TitleTextbox.SendKeys(shareSkillData.Title);
            DescriptionTextbox.Clear();
            DescriptionTextbox.SendKeys(shareSkillData.Description);
            StartDate.SendKeys(shareSkillData.StartDate);
            EndDate.SendKeys(shareSkillData.EndDate);
            SaveButton.Click();
        }

        public string getMessage()
        {
            renderMessage();
            return successMessage.Text;
        }
    }
}
