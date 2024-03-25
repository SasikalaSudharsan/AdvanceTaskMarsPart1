using AdvanceTaskMarsPart1.Utilities;
using OpenQA.Selenium;

namespace AdvanceTaskMarsPart1.Pages.Components.AccountMenu
{
    public class NotificationComponents : BaseSetUp
    {
        private IWebElement LoadMoreButton;
        private IReadOnlyCollection<IWebElement> RequestsList;
        private IWebElement ShowLessButton;
        private IWebElement SelectCheckbox;
        private IWebElement DeleteButton;
        private IWebElement Message;
        private IWebElement MarkSelectionAsRead;
        private IWebElement SelectAllButton;
        private IWebElement UnSelectAllButton;
        private IReadOnlyCollection<IWebElement> CheckBoxSelected;

        public void renderLoadMoreButton()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//a[@class='ui button']", 4);
                LoadMoreButton = driver.FindElement(By.XPath("//a[@class='ui button']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderRequestsList()
        {
            try
            {
                RequestsList = driver.FindElements(By.XPath("//div[@class='fourteen wide column']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderShowLessButton()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//a[text()='...Show Less']", 4);
                ShowLessButton = driver.FindElement(By.XPath("//a[text()='...Show Less']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderSelectCheckbox()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "(//div[@class='one wide column']/input[@type='checkbox'])[1]", 4);
                SelectCheckbox = driver.FindElement(By.XPath("(//div[@class='one wide column']/input[@type='checkbox'])[1]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderDeleteButton()
        {
            try
            {
                DeleteButton = driver.FindElement(By.XPath("//div[@data-tooltip='Delete selection']"));
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
                Wait.WaitToExist(driver, "XPath", "//div[@class='ns-box-inner']", 4);
                Message = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderMarkAsRead()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//i[@class='check square icon']", 4);
                MarkSelectionAsRead = driver.FindElement(By.XPath("//i[@class='check square icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderSelectAll()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//div[@data-tooltip='Select all']", 4);
                SelectAllButton = driver.FindElement(By.XPath("//div[@data-tooltip='Select all']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderUnSelectAll()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//i[@class='ban icon']", 4);
                UnSelectAllButton = driver.FindElement(By.XPath("//i[@class='ban icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderVerifyCheckbox()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//input[@type='checkbox']", 4);
                CheckBoxSelected = driver.FindElements(By.XPath("//input[@type='checkbox']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void LoadMoreNotification()
        {
            renderLoadMoreButton();
            LoadMoreButton.Click();
        }

        public List<IWebElement> getRequestsList()
        {
            Thread.Sleep(4000);
            renderRequestsList();
            return new List<IWebElement>(RequestsList);
        }

        public void ShowLessNotification()
        {
            renderLoadMoreButton();
            LoadMoreButton.Click();
            renderShowLessButton();
            ShowLessButton.Click();
        }

        public void clickDeleteNotification()
        {
            renderSelectCheckbox();
            SelectCheckbox.Click();
            renderDeleteButton();
            DeleteButton.Click();
        }

        public string getMessage()
        {
            renderMessage();
            return Message.Text;
        }

        public void markAsReadNotification()
        {
            renderSelectCheckbox();
            SelectCheckbox.Click();
            renderMarkAsRead();
            MarkSelectionAsRead.Click();
        }

        public void selectAllNotification()
        {
            renderSelectAll();
            SelectAllButton.Click();
        }

        public List<IWebElement> VerifyChechboxSelected()
        {
            renderSelectCheckbox();
            if (CheckBoxSelected == null)
            {
                // If SkillList is null, return an empty list
                return new List<IWebElement>();
            }
            return new List<IWebElement>(CheckBoxSelected);
        }

        public void unSelectAllNotification()
        {
            Thread.Sleep(4000);
            renderSelectAll();
            SelectAllButton.Click();
            renderUnSelectAll();
            UnSelectAllButton.Click();
        }
    }
}
