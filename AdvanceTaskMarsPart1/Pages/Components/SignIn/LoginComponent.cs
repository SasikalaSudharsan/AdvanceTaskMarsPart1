﻿using AdvanceTaskMarsPart1.Data;
using AdvanceTaskMarsPart1.Utilities;
using OpenQA.Selenium;

namespace AdvanceTaskMarsPart1.Pages.Components.SignIn
{
    public class LoginComponent : BaseSetUp
    {
        private IWebElement UsernameTextbox;
        private IWebElement PasswordTextbox;
        private IWebElement LoginButton;

        public void renderLogin()
        {
            try
            {
                UsernameTextbox = driver.FindElement(By.XPath("//input[@name='email']"));
                PasswordTextbox = driver.FindElement(By.XPath("//input[@name='password']"));
                LoginButton = driver.FindElement(By.XPath("//button[text()='Login']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void LoginActions(UserInformation userInformation)
        {
            renderLogin();
            UsernameTextbox.SendKeys(userInformation.UserName);
            PasswordTextbox.SendKeys(userInformation.Password);
            LoginButton.Click();
        }
    }
}
