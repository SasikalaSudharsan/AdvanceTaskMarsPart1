using AdvanceTaskMarsPart1.Utilities;
using NUnit.Framework;
using AdvanceTaskMarsPart1.Steps;

namespace AdvanceTaskMarsPart1.Tests
{
    [TestFixture]
    public class Notification_Tests : BaseSetUp
    {
        LoginSteps loginSteps;
        NotificationSteps notificationSteps;

        public Notification_Tests()
        {
            loginSteps = new LoginSteps();
            notificationSteps = new NotificationSteps();
        }

        [SetUp]
        public void LoginActions()
        {
            loginSteps.doLogin();
        } 

        [Test, Order(1), Description("This test is displaying the requests list when click on LoadMore button")]
        public void LoadMore_Notification()
        {
            notificationSteps.loadMoreNotification();
        }

        [Test, Order(2), Description("This test is shrinking the requests list when click on ShowLess button")]
        public void ShowLess_Notification()
        {
            notificationSteps.showLessNotification();
        }

        [Test, Order(3), Description("This test is deleting the requests from the notifications list")]
        public void Delete_Notification()
        {
            notificationSteps.deleteNotification();
        }

        [Test, Order(4), Description("This test is marking the requests as read from the notifications list")]
        public void MarkAsRead_Notification()
        {
            notificationSteps.markAsReadNotification();
        }

        [Test, Order(5), Description("This test is selecting all the requests from the notifications list")]
        public void SelectAll_Notification()
        {
            notificationSteps.selectAllNotification();
        }

        [Test, Order(6), Description("This test is unselecting all the requests from the notifications list")]
        public void UnSelectAll_Notification()
        {
            notificationSteps.UnSelectAllNotification();
        }
    }
}
