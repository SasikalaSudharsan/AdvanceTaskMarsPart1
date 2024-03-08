using AdvanceTaskMarsPart1.Utilities;
using OpenQA.Selenium;

namespace AdvanceTaskMarsPart1.Pages
{
    public class NotificationPage : CommonDriver
    {
        private IWebElement NotificationTab   => driver.FindElement(By.XPath("//div[@class='ui top left pointing dropdown item']"));
        private IWebElement SeeAllLink        => driver.FindElement(By.XPath("//a[text()='See All...']"));
        private IWebElement LoadMoreButton    => driver.FindElement(By.XPath("//a[@class='ui button']"));
        private IReadOnlyCollection<IWebElement> RequestsList => driver.FindElements(By.XPath("//div[@class='fourteen wide column']"));
        private IWebElement ShowLessButton    => driver.FindElement(By.XPath("//a[text()='...Show Less']"));
        private IWebElement SelectCheckbox    => driver.FindElement(By.XPath("(//div[@class='one wide column']/input[@type='checkbox'])[1]"));
        private IWebElement DeleteButton      => driver.FindElement(By.XPath("//div[@data-tooltip='Delete selection']"));
        private IWebElement Message           => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        private IWebElement MarkSelectionAsRead => driver.FindElement(By.XPath("//i[@class='check square icon']"));
        private IWebElement SelectAllButton     => driver.FindElement(By.XPath("//div[@data-tooltip='Select all']"));
        private IWebElement UnSelectAllButton   => driver.FindElement(By.XPath("//i[@class='ban icon']"));
        private IReadOnlyCollection<IWebElement> CheckBoxSelected => driver.FindElements(By.XPath("//input[@type='checkbox']"));

        public void LoadMore_Notification()
        {
            Wait.WaitToBeClickable("XPath", "//div[@class='ui top left pointing dropdown item']", 4);
            NotificationTab.Click();
            Wait.WaitToBeClickable("XPath", "//a[text()='See All...']", 4);
            SeeAllLink.Click();
            Wait.WaitToBeClickable("XPath", "//a[@class='ui button']", 4);
            LoadMoreButton.Click();
        }

        public List<IWebElement> getRequestsList()
        {
            Thread.Sleep(4000);
            return new List<IWebElement>(RequestsList);
        }

        public void ShowLess_Notification()
        {
            Wait.WaitToBeClickable("XPath", "//div[@class='ui top left pointing dropdown item']", 4);
            NotificationTab.Click();
            Wait.WaitToBeClickable("XPath", "//a[text()='See All...']", 4);
            SeeAllLink.Click();
            Wait.WaitToBeClickable("XPath", "//a[@class='ui button']", 4);
            LoadMoreButton.Click();
            Wait.WaitToBeClickable("XPath", "//a[text()='...Show Less']", 4);
            ShowLessButton.Click();
        }

        public void Delete_Notification()
        {
            Wait.WaitToBeClickable("XPath", "//div[@class='ui top left pointing dropdown item']", 4);
            NotificationTab.Click();
            Wait.WaitToBeClickable("XPath", "//a[text()='See All...']", 4);
            SeeAllLink.Click();
            Wait.WaitToBeClickable("XPath", "(//div[@class='one wide column']/input[@type='checkbox'])[1]", 4);            
            SelectCheckbox.Click();            
            DeleteButton.Click();
        }

        public string getMessage()
        {
            Wait.WaitToExist("XPath", "//div[@class='ns-box-inner']", 4);
            return Message.Text;
        }

        public void MarkAsRead_Notification()
        {
            Wait.WaitToBeClickable("XPath", "//div[@class='ui top left pointing dropdown item']", 4);
            NotificationTab.Click();
            Wait.WaitToBeClickable("XPath", "//a[text()='See All...']", 6);
            SeeAllLink.Click();
            Wait.WaitToBeClickable("XPath", "(//div[@class='one wide column']/input[@type='checkbox'])[1]", 4);
            SelectCheckbox.Click();            
            MarkSelectionAsRead.Click();
        }

        public void SelectAll_Notification()
        {
            Wait.WaitToBeClickable("XPath", "//div[@class='ui top left pointing dropdown item']", 4);
            NotificationTab.Click();
            Wait.WaitToBeClickable("XPath", "//a[text()='See All...']", 6);
            SeeAllLink.Click();
            // Wait.WaitToBeClickable("XPath", "//div[@data-tooltip='Select all']", 4);
            Thread.Sleep(4000);
            SelectAllButton.Click();
        }

        public void UnSelectAll_Notification()
        {
            Wait.WaitToBeClickable("XPath", "//div[@class='ui top left pointing dropdown item']", 4);
            NotificationTab.Click();
            Wait.WaitToBeClickable("XPath", "//a[text()='See All...']", 6);
            SeeAllLink.Click();
            // Wait.WaitToBeClickable("XPath", "//div[@data-tooltip='Select all']", 4);
            Thread.Sleep(4000);
            SelectAllButton.Click();            
            UnSelectAllButton.Click();
        }

        public List<IWebElement> VerifyChechboxSelected()
        {
            return new List<IWebElement>(CheckBoxSelected);
        }
    }
}
