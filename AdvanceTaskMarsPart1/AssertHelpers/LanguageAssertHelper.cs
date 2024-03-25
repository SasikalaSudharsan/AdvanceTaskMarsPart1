using NUnit.Framework;

namespace AdvanceTaskMarsPart1.AssertHelpers
{
    public class LanguageAssertHelper
    {
        public static void assertAddLanguageSuccessMessage(String expected, String actual)
        {
            Assert.That(expected == actual, "Actual message and expected message do not match");
        }

        public static void assertUpdateLanguageSuccessMessage(String expected, String actual)
        {
            Assert.That(expected == actual, "Actual message and expected message do not match");
        }

        public static void assertDeleteLanguageSuccessMessage(String expected, String actual)
        {
            Assert.That(expected == actual, "Actual message and expected message do not match");
        }

        public static void assertEmptyLanguageSuccessMessage(String expected, String actual)
        {
            Assert.That(expected == actual, "Actual message and expected message do not match");
        }

        public static void assertExistsLanguageSuccessMessage(String expected, String actual)
        {
            Assert.That(expected == actual, "Actual message and expected message do not match");
        }

        public static void assertSpecialCharsLanguageSuccessMessage(String expected, String actual)
        {
            Assert.That(expected == actual, "Actual message and expected message do not match");
        }
    }
}
