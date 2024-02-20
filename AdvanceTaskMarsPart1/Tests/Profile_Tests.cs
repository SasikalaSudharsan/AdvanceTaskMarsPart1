using AdvanceTaskMarsPart1.Pages;
using AdvanceTaskMarsPart1.Utilities;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart1.Tests
{
    public class Profile_Tests : CommonDriver
    {
        LoginPage loginPageObj;
        ProfilePage profilePageObj;

        public Profile_Tests()
        {
            loginPageObj = new LoginPage();
            profilePageObj = new ProfilePage();
        }

        [SetUp]
        public void SetUp()
        {
            Initialize();
            loginPageObj.LoginActions();
        }

        [Test]
        public void Edit_Availability()
        {
            profilePageObj.Edit_Availability();
            string actualMessage = profilePageObj.getMessage();
            Assert.That(actualMessage == "Availability updated", "Actual message and expected message do not match");
            
            // Assert.That(profilePageObj.getAvailabilityType("Full Time") == "Full Time", "Updated AvailabilityType and expected AvailabilityType do not match");
            Console.WriteLine(actualMessage);
        }

        [Test]
        public void Cancel_Availability()
        {
            profilePageObj.Cancel_Availability();
        }

        [Test]
        public void Edit_Hours()
        {
            profilePageObj.Edit_Hours();
            string actualMessage = profilePageObj.getMessage();
            Assert.That(actualMessage == "Availability updated", "Actual message and expected message do not match");
            Console.WriteLine(actualMessage);
        }

        [Test]
        public void Edit_EarnTarget()
        {
            profilePageObj.Edit_EarnTarget();
            string actualMessage = profilePageObj.getMessage();
            Assert.That(actualMessage == "Availability updated", "Actual message and expected message do not match");
            Console.WriteLine(actualMessage);
        }

        [TearDown]
        public void TearDown()
        {
            Close();
        }
    }
}
