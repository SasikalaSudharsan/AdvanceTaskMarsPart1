﻿using NUnit.Framework;

namespace AdvanceTaskMarsPart1.AssertHelpers
{
    public class ShareSkillAssertHelper
    {
        public static void assertAddShareSkillSuccessMessage(String expected, String actual)
        {
            Assert.That(expected == actual, "Actual message and expected message do not match");
        }

        public static void assertUpdateShareSkillSuccessMessage(String expected, String actual)
        {
            Assert.That(expected == actual, "Actual message and expected message do not match");
        }

        public static void assertDeleteShareSkillSuccessMessage(String expected, String actual)
        {
            Assert.That(expected == actual, "Actual message and expected message do not match");
        }
    }
}
