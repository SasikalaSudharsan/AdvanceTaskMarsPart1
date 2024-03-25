using AdvanceTaskMarsPart1.Data;
using AdvanceTaskMarsPart1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AdvanceTaskMarsPart1.Pages.Components.ProfileOverview
{
    public class AddAndUpdateLanguageComponent : BaseSetUp
    {
        private IReadOnlyCollection<IWebElement> deleteButtons;
        private IWebElement LanguageTextbox;
        private IWebElement LanguageLevelDropdown;
        private IWebElement AddButton;
        private IWebElement successMessage;
        private IWebElement closeMessageIcon;
        private IWebElement UpdateNewButton;

        public void renderDeleteAllRecordsComponents()
        {
            try
            {
                deleteButtons = driver.FindElements(By.XPath("//div[@data-tab='first']//i[@class='remove icon']"));
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex);
            }
        }

        public void renderAddComponents()
        {
            try
            {
                LanguageTextbox = driver.FindElement(By.XPath("//input[@name='name']"));
                LanguageLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));
                AddButton = driver.FindElement(By.XPath("//input[@value='Add']"));
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
                LanguageTextbox = driver.FindElement(By.XPath("//input[@name='name']"));
                LanguageLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));
                UpdateNewButton = driver.FindElement(By.XPath("//input[@value='Update']"));
    }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void DeleteAllRecords()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//div[@data-tab='first']//i[@class='remove icon']", 4);
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

        public void addLanguage(LanguageData languageData)
        {
            renderAddComponents();
            LanguageTextbox.SendKeys(languageData.Language);
            SelectElement chooseLanguageLevel = new SelectElement(LanguageLevelDropdown);
            chooseLanguageLevel.SelectByValue(languageData.LanguageLevel);
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

        public void updateLanguage(LanguageData newLanguageData)
        {
            renderUpdateComponents();
            LanguageTextbox.Clear();
            LanguageTextbox.SendKeys(newLanguageData.Language);
            SelectElement chooseLanguageLevel = new SelectElement(LanguageLevelDropdown);
            chooseLanguageLevel.SelectByValue(newLanguageData.LanguageLevel);
            UpdateNewButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 4);
        }
    }
}
