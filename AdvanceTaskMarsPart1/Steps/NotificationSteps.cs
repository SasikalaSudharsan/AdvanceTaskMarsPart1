using AdvanceTaskMarsPart1.AssertHelpers;
using AdvanceTaskMarsPart1.Pages.Components.AccountMenu;
using OpenQA.Selenium;

namespace AdvanceTaskMarsPart1.Steps
{
    public class NotificationSteps
    {
        NotificationOverviewComponents notificationOverviewComponents;
        NotificationComponents notificationComponents;

        public NotificationSteps()
        {
            notificationOverviewComponents = new NotificationOverviewComponents();
            notificationComponents = new NotificationComponents();
        }

        public void loadMoreNotification()
        {
            notificationOverviewComponents.GoToNotifications();
            notificationComponents.LoadMoreNotification();
            // Retrieve the list of requests after clicking Loadmore button
            List<IWebElement> RequestsList = notificationComponents.getRequestsList();
            // Get the count of requests in the request list
            int ActualCount = RequestsList.Count;
            // Assert that the actual count of requests is equal to the expected count 
            NotificationAssertHelper.assertLoadMoreNotification(10, ActualCount);
        }

        public void showLessNotification()
        {
            notificationOverviewComponents.GoToNotifications();
            notificationComponents.ShowLessNotification();
            // Retrieve the list of requests after clicking ShowLess button
            List<IWebElement> RequestsList = notificationComponents.getRequestsList();
            int ActualCount = RequestsList.Count;
            // Assert that the actual count of requests is equal to the expected count 
            NotificationAssertHelper.assertShowLessNotification(5, ActualCount);
        }

        public void deleteNotification()
        {
            notificationOverviewComponents.GoToNotifications();
            notificationComponents.clickDeleteNotification();
            // Retrieve the message displayed after deleting notification
            string ActualMessage = notificationComponents.getMessage();
            NotificationAssertHelper.assertSuccessMessageNotification("Notification updated", ActualMessage);
        }

        public void markAsReadNotification()
        {
            notificationOverviewComponents.GoToNotifications();
            notificationComponents.markAsReadNotification();
            // Retrieve the message displayed after clicking MarkAsRead
            string ActualMessage = notificationComponents.getMessage();
            NotificationAssertHelper.assertSuccessMessageNotification("Notification updated", ActualMessage);
        }

        public void selectAllNotification()
        {
            notificationOverviewComponents.GoToNotifications();
            notificationComponents.selectAllNotification();
            // Retrieve a list of checkboxes that are selected on the notification page
            List<IWebElement> CheckBoxSelected = notificationComponents.VerifyChechboxSelected();
            // Iterate through each checkbox in the list to verify if they are selected
            foreach (var checkbox in CheckBoxSelected)
            {
                // Assert that the checkbox is selected
                NotificationAssertHelper.assertSelectAllNotification(checkbox.Selected);
            }
        }

        public void UnSelectAllNotification()
        {
            notificationOverviewComponents.GoToNotifications();
            notificationComponents.unSelectAllNotification();
            // Retrieve a list of checkboxes that are unselected on the notification page
            List<IWebElement> CheckBoxUnSelected = notificationComponents.VerifyChechboxSelected();
            // Iterate through each checkbox in the list to verify if they are unselected
            foreach (var checkbox in CheckBoxUnSelected)
            {
                // Assert that the checkbox is unselected
                NotificationAssertHelper.assertUnSelectAllNotification(checkbox.Selected);
            }
        }
    }
}
