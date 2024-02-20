using AdvanceTaskMarsPart1.Data;
using AdvanceTaskMarsPart1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AdvanceTaskMarsPart1.Pages
{
    public class LanguagePage : CommonDriver
    {
        private IReadOnlyCollection<IWebElement> deleteButtons => driver.FindElements(By.XPath("//div[@data-tab='first']//i[@class='remove icon']"));
        private IWebElement AddNewButton                       => driver.FindElement(By.XPath("//div[@class='four wide column' and h3='Languages']/following-sibling::div[@class='twelve wide column scrollTable']//th[@class='right aligned']//div"));
        private IWebElement LanguageTextbox                    => driver.FindElement(By.XPath("//input[@name='name']"));
        private IWebElement LanguageLevelDropdown              => driver.FindElement(By.XPath("//select[@name='level']"));
        private IWebElement AddButton                          => driver.FindElement(By.XPath("//input[@value='Add']"));
        private IWebElement successMessage                     => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        private IWebElement UpdateNewButton                    => driver.FindElement(By.XPath("//input[@value='Update']"));
        private Func<string, IWebElement> newLanguage      = language      => driver.FindElement(By.XPath($"//div[@class='four wide column' and h3='Languages']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{language}']"));
        private Func<string, IWebElement> newLanguageLevel = languagelevel => driver.FindElement(By.XPath($"//div[@class='four wide column' and h3='Languages']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{languagelevel}']"));
        private IWebElement CancelButton                   => driver.FindElement(By.XPath("//div[@class='four wide column' and h3='Languages']/following-sibling::div[@class='twelve wide column scrollTable']//input[@value='Cancel']"));
        
        public void Delete_All_Records()
        {
            try
            {
                Wait.WaitToBeClickable("XPath", "//div[@data-tab='first']//i[@class='remove icon']", 4);
            }
            catch(WebDriverTimeoutException e)
            {
                return;
            }
            //Delete all records in the list
            foreach (IWebElement deleteButton in deleteButtons)
            {
                deleteButton.Click();
            }
        }

        public void Add_Language(LanguageData languageData)
        {
            Thread.Sleep(4000);            
            AddNewButton.Click();
            LanguageTextbox.SendKeys(languageData.Language);
            SelectElement chooseLanguageLevel = new SelectElement(LanguageLevelDropdown);
            chooseLanguageLevel.SelectByValue(languageData.LanguageLevel);            
            AddButton.Click();
        }

        public string getMessage()
        {
            //Thread.Sleep(4000);
            Wait.WaitToExist("XPath", "//div[@class='ns-box-inner']", 4);
            //Get the text message after adding language
            return successMessage.Text;
        }

        public string getLanguage(string language)
        {
            Thread.Sleep(4000);
            return newLanguage(language).Text;
        }

        public string getLanguageLevel(string languagelevel)
        {
            Thread.Sleep(4000);
            return newLanguageLevel(languagelevel).Text;
        }

        public void getCancel()
        {
            try
            {
                CancelButton.Click();
            }
            catch (NoSuchElementException)
            {
                return;
            }
        }

        public void Update_Language(LanguageData existingLanguageData, LanguageData newLanguageData)
        {
            Thread.Sleep(4000);
            IWebElement UpdateButton = driver.FindElement(By.XPath($"//div[@data-tab='first']//tr[td[1]='{existingLanguageData.Language}' and td[2]='{existingLanguageData.LanguageLevel}']//td[last()]/span[1]"));
            UpdateButton.Click();
            LanguageTextbox.Clear();
            LanguageTextbox.SendKeys(newLanguageData.Language);
            SelectElement chooseLanguageLevel = new SelectElement(LanguageLevelDropdown);
            chooseLanguageLevel.SelectByValue(newLanguageData.LanguageLevel);            
            UpdateNewButton.Click();
        }

        public void Delete_Language(LanguageData languageData)
        {
            Thread.Sleep(4000);
            //Click the delete button that needs to be deleted
            string xpath = $@"//div[@data-tab='first']//tr[td[1]='{languageData.Language}' and td[2]='{languageData.LanguageLevel}']//td[last()]/span[2]";
            IWebElement DeleteButton = driver.FindElement(By.XPath(xpath));
            DeleteButton.Click();
        }

        public string getDeletedLanguage(LanguageData languageData)
        {
            Thread.Sleep(4000);
            try
            {
                string xpath = $@"//div[@data-tab='first']//tr[td[1]='{languageData.Language}' and td[2]='{languageData.LanguageLevel}']";
                IWebElement DeletedLanguage = driver.FindElement(By.XPath(xpath));
                return DeletedLanguage.Text;
            }
            catch(NoSuchElementException)
            {
                return null;
            }
        }        
    }
}
