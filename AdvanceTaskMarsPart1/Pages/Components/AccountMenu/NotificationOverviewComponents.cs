using AdvanceTaskMarsPart1.Utilities;
using OpenQA.Selenium;

namespace AdvanceTaskMarsPart1.Pages.Components.AccountMenu
{
    public class NotificationOverviewComponents : BaseSetUp
    {
        private IWebElement NotificationDropdown;
        private IWebElement SeeAllLink;

        public void renderNotificationDropdown()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ui top left pointing dropdown item']", 4);
                NotificationDropdown = driver.FindElement(By.XPath("//div[@class='ui top left pointing dropdown item']"));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderSeeAllNotificationLink()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//a[text()='See All...']", 6);
                SeeAllLink = driver.FindElement(By.XPath("//a[text()='See All...']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void GoToNotifications()
        {
            renderNotificationDropdown();
            NotificationDropdown.Click();
            renderSeeAllNotificationLink();
            SeeAllLink.Click();
        }
    }
}
