using AdvanceTaskMarsPart1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart1.Pages
{
    public class ProfilePage : CommonDriver
    {
        private IWebElement EditAvailabilityButton => driver.FindElement(By.XPath("//div[@class='four wide column']//div[@class='item']//strong[contains(text(),'Availability')]/../following-sibling::div//i[@class='right floated outline small write icon']"));
        
        public void Edit_Availability()
        {
            Thread.Sleep(4000);            
            EditAvailabilityButton.Click();

            IWebElement Availability = driver.FindElement(By.XPath("//select[@name='availabiltyType']"));
            SelectElement chooseAvailability = new SelectElement(Availability);
            chooseAvailability.SelectByText("Full Time");
        }

        public string getMessage()
        {
            Thread.Sleep(4000);
            IWebElement successMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            return successMessage.Text;
        }

        /* public string getAvailabilityType(string availabilityType)
        {
            Thread.Sleep(4000);
            IWebElement newAvailabilityType = driver.FindElement(By.XPath($"//div[@class='four wide column']//div[@class='item']//strong[contains(text(),'Availability')]/../following-sibling::div//span[text()='{availabilityType}']"));
            return newAvailabilityType.Text;
        } */

        public void Cancel_Availability()
        {
            Thread.Sleep(4000);
            EditAvailabilityButton.Click();
            IWebElement CancelAvailabilityButton = driver.FindElement(By.XPath("//div[@class='four wide column']//div[@class='item']//strong[contains(text(),'Availability')]/../following-sibling::div//i[@class='remove icon']"));
            CancelAvailabilityButton.Click();
        }

        public void Edit_Hours()
        {
            Thread.Sleep(4000);
            IWebElement EditHoursButton = driver.FindElement(By.XPath("//div[@class='four wide column']//div[@class='item']//strong[contains(text(),'Hours')]/../following-sibling::div//i[@class='right floated outline small write icon']"));
            EditHoursButton.Click();
            IWebElement Hours = driver.FindElement(By.XPath("//select[@name='availabiltyHour']"));
            SelectElement chooseHours = new SelectElement(Hours);
            chooseHours.SelectByText("More than 30hours a week");
        }

        public void Edit_EarnTarget()
        {
            Thread.Sleep(4000);
            IWebElement EditEarnTargetButton = driver.FindElement(By.XPath("//div[@class='four wide column']//div[@class='item']//strong[contains(text(),'Earn Target')]/../following-sibling::div//i[@class='right floated outline small write icon']"));
            EditEarnTargetButton.Click();
            IWebElement EarnTarget = driver.FindElement(By.XPath("//select[@name='availabiltyTarget']"));
            SelectElement chooseEarnTarget = new SelectElement (EarnTarget);
            chooseEarnTarget.SelectByText("Between $500 and $1000 per month");
        }
    }
}
