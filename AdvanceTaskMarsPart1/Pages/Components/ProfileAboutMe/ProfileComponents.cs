using AdvanceTaskMarsPart1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AdvanceTaskMarsPart1.Pages.Components.ProfileAboutMe
{
    public class ProfileComponents : BaseSetUp
    {
        private IWebElement EditAvailabilityButton;
        private IWebElement Availability;
        private IWebElement successMessage;
        private IWebElement CancelAvailabilityButton;
        private IWebElement EditHoursButton;
        private IWebElement Hours;
        private IWebElement EditEarnTargetButton;
        private IWebElement EarnTarget;

        public void renderAvailabilityButton()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//div[@class='four wide column']//div[@class='item']//strong[contains(text(),'Availability')]/../following-sibling::div//i[@class='right floated outline small write icon']", 6);
                EditAvailabilityButton = driver.FindElement(By.XPath("//div[@class='four wide column']//div[@class='item']//strong[contains(text(),'Availability')]/../following-sibling::div//i[@class='right floated outline small write icon']"));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderAvailability()
        {
            try
            {
                Availability = driver.FindElement(By.XPath("//select[@name='availabiltyType']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderSuccessMessage()
        {
            try
            {
                Wait.WaitToExist(driver, "XPath", "//div[@class='ns-box-inner']", 4);
                successMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderCancelAvailability()
        {
            try
            {
                CancelAvailabilityButton = driver.FindElement(By.XPath("//div[@class='four wide column']//div[@class='item']//strong[contains(text(),'Availability')]/../following-sibling::div//i[@class='remove icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderHoursButton()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//div[@class='four wide column']//div[@class='item']//strong[contains(text(),'Hours')]/../following-sibling::div//i[@class='right floated outline small write icon']", 6);
                EditHoursButton = driver.FindElement(By.XPath("//div[@class='four wide column']//div[@class='item']//strong[contains(text(),'Hours')]/../following-sibling::div//i[@class='right floated outline small write icon']"));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderHours()
        {
            try
            {
                Hours = driver.FindElement(By.XPath("//select[@name='availabiltyHour']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderEarnTargetButton()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//div[@class='four wide column']//div[@class='item']//strong[contains(text(),'Earn Target')]/../following-sibling::div//i[@class='right floated outline small write icon']", 6);
                EditEarnTargetButton = driver.FindElement(By.XPath("//div[@class='four wide column']//div[@class='item']//strong[contains(text(),'Earn Target')]/../following-sibling::div//i[@class='right floated outline small write icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderEarnTarget()
        {
            try
            {
                EarnTarget = driver.FindElement(By.XPath("//select[@name='availabiltyTarget']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void editAvailability(string availability)
        {
            renderAvailabilityButton();
            EditAvailabilityButton.Click();
            renderAvailability();
            SelectElement chooseAvailability = new SelectElement(Availability);
            chooseAvailability.SelectByText(availability);
        }

        public string getMessage()
        {
            renderSuccessMessage();
            return successMessage.Text;
        }

        public void cancelAvailabilityButton()
        {
            renderAvailabilityButton();
            EditAvailabilityButton.Click();
            renderCancelAvailability();
            CancelAvailabilityButton.Click();
        }

        public void editHours(string hours)
        {
            renderHoursButton();
            EditHoursButton.Click();
            renderHours();
            SelectElement chooseHours = new SelectElement(Hours);
            chooseHours.SelectByText(hours);
        }

        public void editEarnTarget(string earnTarget)
        {
            renderEarnTargetButton();
            EditEarnTargetButton.Click();
            renderEarnTarget();
            SelectElement chooseEarnTarget = new SelectElement(EarnTarget);
            chooseEarnTarget.SelectByText(earnTarget);
        }
    }
}
