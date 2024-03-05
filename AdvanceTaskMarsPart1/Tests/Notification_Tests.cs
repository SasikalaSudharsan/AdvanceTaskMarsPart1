using AdvanceTaskMarsPart1.Pages;
using AdvanceTaskMarsPart1.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AdvanceTaskMarsPart1.Tests
{
    public class Notification_Tests : CommonDriver
    {
        LoginPage loginPageObj;
        NotificationPage notificationPageObj;

        public Notification_Tests()
        {
            loginPageObj = new LoginPage();
            notificationPageObj = new NotificationPage();
        }

        [SetUp]
        public void SetUp()
        {
            Initialize();
            loginPageObj.LoginActions();
        }

        [Test, Order(1), Description("This test is displaying the requests list when click on LoadMore button")]
        public void LoadMore_Notification()
        {
            notificationPageObj.LoadMore_Notification();

            List<IWebElement> RequestsList = notificationPageObj.getRequestsList();
            int ActualCount = RequestsList.Count;
            Assert.That(ActualCount == 10, "After clicking 'LoadMore', number of requests is not equal to original count");
        }

        [Test, Order(2), Description("This test is shrinking the requests list when click on ShowLess button")]
        public void ShowLess_Notification()
        {
            notificationPageObj.ShowLess_Notification();

            List<IWebElement> RequestsList = notificationPageObj.getRequestsList();
            int ActualCount = RequestsList.Count;
            Assert.That(ActualCount == 5, "After clicking 'ShowLess', number of requests is not equal to original count");
        }

        [Test, Order(3), Description("This test is deleting the requests from the notifications list")]
        public void Delete_Notification()
        {
            notificationPageObj.Delete_Notification();
            string ActualMessage = notificationPageObj.getMessage();
            Assert.That(ActualMessage == "Notification updated", "Notification has not been deleted");
        }

        [TearDown]
        public void TearDown()
        {
            Close();
        }
    }
}
