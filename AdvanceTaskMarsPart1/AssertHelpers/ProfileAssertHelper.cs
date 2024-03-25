using NUnit.Framework;

namespace AdvanceTaskMarsPart1.AssertHelpers
{
    public class ProfileAssertHelper
    {
        public static void assertAvailabilitySuccessMessage(String expected, String actual)
        {
            Assert.That(expected == actual, "Actual message and expected message do not match");
        }

        public static void assertHoursSuccessMessage(String expected, String actual)
        {
            Assert.That(expected == actual, "Actual message and expected message do not match");
        }

        public static void assertEarnTargetSuccessMessage(String expected, String actual)
        {
            Assert.That(expected == actual, "Actual message and expected message do not match");
        }
    }
}
