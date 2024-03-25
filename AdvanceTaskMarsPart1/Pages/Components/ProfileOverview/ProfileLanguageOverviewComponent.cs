using AdvanceTaskMarsPart1.Data;
using AdvanceTaskMarsPart1.Utilities;
using OpenQA.Selenium;

namespace AdvanceTaskMarsPart1.Pages.Components.ProfileOverview
{
    public class ProfileLanguageOverviewComponent : BaseSetUp
    {
        private IWebElement AddNewButton;
        private IWebElement UpdateButton;
        private IWebElement DeleteButton;

        public void renderAddButton()
        {
            try
            {
                AddNewButton = driver.FindElement(By.XPath("//div[@class='four wide column' and h3='Languages']/following-sibling::div[@class='twelve wide column scrollTable']//th[@class='right aligned']//div"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderUpdateButton(string existingLanguage, string existingLanguageLevel)
        {
            try
            {
                UpdateButton = driver.FindElement(By.XPath($"//div[@data-tab='first']//tr[td[1]='{existingLanguage}' and td[2]='{existingLanguageLevel}']//td[last()]/span[1]"));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderDeleteButton(string language, string languageLevel)
        {
            try
            {
                DeleteButton = driver.FindElement(By.XPath($"//div[@data-tab='first']//tr[td[1]='{language}' and td[2]='{languageLevel}']//td[last()]/span[2]"));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void clickAddLanguageButton()
        {
            renderAddButton();
            AddNewButton.Click();
        }

        public void clickUpdateLanguageButton(LanguageData existingLanguageData)
        {
            string existingLanguage = existingLanguageData.Language;
            string existingLanguageLevel = existingLanguageData.LanguageLevel;
            Thread.Sleep(4000);
            renderUpdateButton(existingLanguage, existingLanguageLevel);
            UpdateButton.Click();
        }

        public void clickDeleteLanguageButton(LanguageData languageData)
        {
            string language = languageData.Language;
            string languageLevel = languageData.LanguageLevel;
            Thread.Sleep(4000);
            renderDeleteButton(language, languageLevel);
            DeleteButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 4);
        }
    }
}
