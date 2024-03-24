using AdvanceTaskMarsPart1.Utilities;
using OpenQA.Selenium;

namespace AdvanceTaskMarsPart1.Pages.Components.SignIn
{
    public class SignInComponent : BaseSetUp
    {
        private IWebElement SignInButton;

        public void renderSignIn()
        {
            try
            {
                SignInButton = driver.FindElement(By.XPath("//div[@id='home']/div/div/div/div/a"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void clickSignInButton()
        {
            renderSignIn();
            SignInButton.Click();
        }
    }
}
