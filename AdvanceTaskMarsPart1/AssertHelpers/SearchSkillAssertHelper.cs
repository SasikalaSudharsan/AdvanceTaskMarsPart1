using NUnit.Framework;
using OpenQA.Selenium;

namespace AdvanceTaskMarsPart1.AssertHelpers
{
    public class SearchSkillAssertHelper
    {
        public static void assertSkillListNotEmpty(bool skillDisplayed)
        {
            Assert.That(skillDisplayed, Is.True, "Skill list is empty");
        }

        public static void assertSkillListEmpty(List<IWebElement> skillList)
        {
            Assert.That(skillList, Is.Empty, "Skill list is not empty");
        }
    }
}
