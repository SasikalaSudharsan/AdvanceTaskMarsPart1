using AdvanceTaskMarsPart1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AdvanceTaskMarsPart1.Pages
{
    public class ProfilePage : CommonDriver
    {
        private IWebElement EditAvailabilityButton => driver.FindElement(By.XPath("//div[@class='four wide column']//div[@class='item']//strong[contains(text(),'Availability')]/../following-sibling::div//i[@class='right floated outline small write icon']"));
        private IWebElement Availability           => driver.FindElement(By.XPath("//select[@name='availabiltyType']"));
        private IWebElement successMessage         => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        private Func<string, IWebElement> newAvailabilityType = availability => driver.FindElement(By.XPath($"//span[text()='{availability}']"));
        private IWebElement CancelAvailabilityButton => driver.FindElement(By.XPath("//div[@class='four wide column']//div[@class='item']//strong[contains(text(),'Availability')]/../following-sibling::div//i[@class='remove icon']"));
        private IWebElement EditHoursButton          => driver.FindElement(By.XPath("//div[@class='four wide column']//div[@class='item']//strong[contains(text(),'Hours')]/../following-sibling::div//i[@class='right floated outline small write icon']"));
        private IWebElement Hours                    => driver.FindElement(By.XPath("//select[@name='availabiltyHour']"));
        private Func<string, IWebElement> newHours   = hours => driver.FindElement(By.XPath($"//span[text()='{hours}']"));
        private IWebElement EditEarnTargetButton     => driver.FindElement(By.XPath("//div[@class='four wide column']//div[@class='item']//strong[contains(text(),'Earn Target')]/../following-sibling::div//i[@class='right floated outline small write icon']"));
        private IWebElement EarnTarget               => driver.FindElement(By.XPath("//select[@name='availabiltyTarget']"));
        private Func<string, IWebElement> newEarnTarget = earnTarget => driver.FindElement(By.XPath($"//span[text()='{earnTarget}']"));

        public void Edit_Availability(string availability)
        {
            //Wait.WaitToBeClickable("XPath", "//div[@class='four wide column']//div[@class='item']//strong[contains(text(),'Availability')]/../following-sibling::div//i[@class='right floated outline small write icon']", 6);
            Thread.Sleep(6000);
            EditAvailabilityButton.Click();            
            SelectElement chooseAvailability = new SelectElement(Availability);
            chooseAvailability.SelectByText(availability);
        }

        public string getMessage()
        {
            //Wait.WaitToExist("XPath", "//div[@class='ns-box-inner']", 4);
            Thread.Sleep(4000);            
            return successMessage.Text;
        }

        public string getAvailabilityType(string availability)
        {
            Thread.Sleep(4000);
            return newAvailabilityType(availability).Text;
        } 

        public void Cancel_Availability()
        {
            Thread.Sleep(4000);
            EditAvailabilityButton.Click();            
            CancelAvailabilityButton.Click();
        }

        public void Edit_Hours(string hours)
        {
            //Wait.WaitToBeClickable("XPath", "//div[@class='four wide column']//div[@class='item']//strong[contains(text(),'Hours')]/../following-sibling::div//i[@class='right floated outline small write icon']", 6);
            Thread.Sleep(6000);            
            EditHoursButton.Click();            
            SelectElement chooseHours = new SelectElement(Hours);
            chooseHours.SelectByText(hours);
        }

        public string getHours(string hours)
        {
            Thread.Sleep(4000);
            return newHours(hours).Text;
        }

        public void Edit_EarnTarget(string earnTarget)
        {
            //Wait.WaitToBeClickable("XPath", "//div[@class='four wide column']//div[@class='item']//strong[contains(text(),'Earn Target')]/../following-sibling::div//i[@class='right floated outline small write icon']", 6);
            Thread.Sleep(6000);            
            EditEarnTargetButton.Click();            
            SelectElement chooseEarnTarget = new SelectElement (EarnTarget);
            chooseEarnTarget.SelectByText(earnTarget);
        }

        public string getEarnTarget(string earnTarget)
        {
            Thread.Sleep(4000);
            return newEarnTarget(earnTarget).Text;
        }
    }
}
