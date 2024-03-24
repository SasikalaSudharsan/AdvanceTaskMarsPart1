using AdvanceTaskMarsPart1.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using AdvanceTaskMarsPart1.Steps;

namespace AdvanceTaskMarsPart1.Tests
{
    [TestFixture]
    public class Notification_Tests : BaseSetUp
    {
        LoginSteps loginSteps;
        NotificationSteps notificationSteps;
        public static ExtentTest test;

        public Notification_Tests()
        {
            loginSteps = new LoginSteps();
            notificationSteps = new NotificationSteps();
        }

        [SetUp]
        public void SetUp()
        {
            Initialize();
            loginSteps.doLogin();
        }

        [Test, Order(1), Description("This test is displaying the requests list when click on LoadMore button")]
        public void LoadMore_Notification()
        {
            test = extent.CreateTest("LoadMore_Notification").Info("Test Started");
            notificationSteps.loadMoreNotification();
            test.Log(Status.Pass, "LoadMore_Notification passed");
        }

        [Test, Order(2), Description("This test is shrinking the requests list when click on ShowLess button")]
        public void ShowLess_Notification()
        {
            test = extent.CreateTest("ShowLess_Notification").Info("Test Started");
            notificationSteps.showLessNotification();
            test.Log(Status.Pass, "ShowLess_Notification passed");
        }

        [Test, Order(3), Description("This test is deleting the requests from the notifications list")]
        public void Delete_Notification()
        {
            test = extent.CreateTest("Delete_Notification").Info("Test Started");
            notificationSteps.deleteNotification();
            test.Log(Status.Pass, "Delete_Notification passed");
        }

        [Test, Order(4), Description("This test is marking the requests as read from the notifications list")]
        public void MarkAsRead_Notification()
        {
            test = extent.CreateTest("MarkAsRead_Notification").Info("Test Started");
            notificationSteps.markAsReadNotification();
            test.Log(Status.Pass, "MarkAsRead_Notification passed");
        }

        [Test, Order(5), Description("This test is selecting all the requests from the notifications list")]
        public void SelectAll_Notification()
        {
            test = extent.CreateTest("SelectAll_Notification").Info("Test Started");
            notificationSteps.selectAllNotification();
            test.Log(Status.Pass, "SelectAll_Notification passed");
        }

        [Test, Order(6), Description("This test is unselecting all the requests from the notifications list")]
        public void UnSelectAll_Notification()
        {
            test = extent.CreateTest("UnSelectAll_Notification").Info("Test Started");
            notificationSteps.UnSelectAllNotification();
            test.Log(Status.Pass, "UnSelectAll_Notification passed");
        }

        [TearDown]
        public void TearDown()
        {
            Close();
        }
    }
}
