using NUnit.Framework;

namespace AdvanceTaskMarsPart1.AssertHelpers
{
    public class NotificationAssertHelper
    {
        public static void assertLoadMoreNotification(int expected, int actual)
        {
            Assert.That(expected == actual, "After clicking 'LoadMore', number of requests is not equal to original count");
        }

        public static void assertShowLessNotification(int expected, int actual)
        {
            Assert.That(expected == actual, "After clicking 'ShowLess', number of requests is not equal to original count");
        }

        public static void assertSuccessMessageNotification(string expected, string actual)
        {
            Assert.That(expected == actual, "Notification has not been deleted");
        }

        public static void assertSelectAllNotification(bool checkboxSelected)
        {
            Assert.That(checkboxSelected, Is.True, "Checkbox is not Selected");
        }

        public static void assertUnSelectAllNotification(bool checkboxSelected)
        {
            Assert.That(checkboxSelected, Is.False, "Checkbox is Selected");
        }
    }
}
