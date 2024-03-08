using AdvanceTaskMarsPart1.Pages;
using AdvanceTaskMarsPart1.Utilities;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AdvanceTaskMarsPart1.Tests
{
    public class Notification_Tests : CommonDriver
    {
        LoginPage loginPageObj;
        NotificationPage notificationPageObj;
        public static ExtentReports extent;
        public static ExtentTest test;

        public Notification_Tests()
        {
            loginPageObj = new LoginPage();
            notificationPageObj = new NotificationPage();
        }

        [OneTimeSetUp]
        public static void ExtentStart()
        {
            //Create new instance of ExtentReports
            extent = new ExtentReports();
            //Create new instance of ExtentSparkReporter
            var SparkReporter = new ExtentSparkReporter(@"D:\Sasikala\MVP_Studio\AdvanceTaskPart1\AdvanceTaskMarsPart1\AdvanceTaskMarsPart1\ExtentReports\Notification.html");
            //Attach the ExtentSparkReporter to the ExtentReports
            extent.AttachReporter(SparkReporter);
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
            test = extent.CreateTest("LoadMore_Notification").Info("Test Started");
            notificationPageObj.LoadMore_Notification();
            // Retrieve the list of requests after clicking Loadmore button
            List<IWebElement> RequestsList = notificationPageObj.getRequestsList();
            // Get the count of requests in the request list
            int ActualCount = RequestsList.Count;
            // Assert that the actual count of requests is equal to the expected count 
            Assert.That(ActualCount == 10, "After clicking 'LoadMore', number of requests is not equal to original count");
            test.Log(Status.Pass, "LoadMore_Notification passed");
        }

        [Test, Order(2), Description("This test is shrinking the requests list when click on ShowLess button")]
        public void ShowLess_Notification()
        {
            test = extent.CreateTest("ShowLess_Notification").Info("Test Started");
            notificationPageObj.ShowLess_Notification();
            // Retrieve the list of requests after clicking ShowLess button
            List<IWebElement> RequestsList = notificationPageObj.getRequestsList();
            int ActualCount = RequestsList.Count;
            // Assert that the actual count of requests is equal to the expected count 
            Assert.That(ActualCount == 5, "After clicking 'ShowLess', number of requests is not equal to original count");
            test.Log(Status.Pass, "ShowLess_Notification passed");
        }

        [Test, Order(3), Description("This test is deleting the requests from the notifications list")]
        public void Delete_Notification()
        {
            test = extent.CreateTest("Delete_Notification").Info("Test Started");
            notificationPageObj.Delete_Notification();
            // Retrieve the message displayed after deleting notification
            string ActualMessage = notificationPageObj.getMessage();
            Assert.That(ActualMessage == "Notification updated", "Notification has not been deleted");
            test.Log(Status.Pass, "Delete_Notification passed");
        }

        [Test, Order(4), Description("This test is marking the requests as read from the notifications list")]
        public void MarkAsRead_Notification()
        {
            test = extent.CreateTest("MarkAsRead_Notification").Info("Test Started");
            notificationPageObj.MarkAsRead_Notification();
            // Retrieve the message displayed after clicking MarkAsRead 
            string ActualMessage = notificationPageObj.getMessage();
            Assert.That(ActualMessage == "Notification updated", "Notification has not been deleted");
            test.Log(Status.Pass, "MarkAsRead_Notification passed");
        }

        [Test, Order(5), Description("This test is selecting all the requests from the notifications list")]
        public void SelectAll_Notification()
        {
            test = extent.CreateTest("SelectAll_Notification").Info("Test Started");
            notificationPageObj.SelectAll_Notification();
            // Retrieve a list of checkboxes that are selected on the notification page
            List<IWebElement> CheckBoxSelected = notificationPageObj.VerifyChechboxSelected();
            // Iterate through each checkbox in the list to verify if they are selected
            foreach (var checkbox in CheckBoxSelected)
            {
                // Assert that the checkbox is selected
                Assert.That(checkbox.Selected, Is.True, "Checkbox is not Selected");
            }
            test.Log(Status.Pass, "SelectAll_Notification passed");
        }

        [Test, Order(6), Description("This test is unselecting all the requests from the notifications list")]
        public void UnSelectAll_Notification()
        {
            test = extent.CreateTest("UnSelectAll_Notification").Info("Test Started");
            notificationPageObj.UnSelectAll_Notification();
            // Retrieve a list of checkboxes that are unselected on the notification page
            List<IWebElement> CheckBoxUnSelected = notificationPageObj.VerifyChechboxSelected();
            // Iterate through each checkbox in the list to verify if they are unselected
            foreach (var checkbox in CheckBoxUnSelected)
            {
                // Assert that the checkbox is unselected
                Assert.That(checkbox.Selected, Is.False, "Checkbox is Selected");
            }
            test.Log(Status.Pass, "UnSelectAll_Notification passed");
        }

        [TearDown]
        public void TearDown()
        {
            Close();
        }

        [OneTimeTearDown]
        public static void ExtentClose()
        {
            //Flush the ExtentReports instance
            extent.Flush();
        }
    }
}
