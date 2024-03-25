using AdvanceTaskMarsPart1.Utilities;
using NUnit.Framework;
using AdvanceTaskMarsPart1.Steps;

namespace AdvanceTaskMarsPart1.Tests
{
    [TestFixture]
    public class ShareSkill_Tests : BaseSetUp
    {
        LoginSteps loginSteps;
        ShareSkillSteps shareSkillSteps;

        public ShareSkill_Tests()
        {
            loginSteps = new LoginSteps();
            shareSkillSteps = new ShareSkillSteps();
        }

        [SetUp]
        public void LoginActions()
        {
            loginSteps.doLogin();
        }

        [Test, Order(1), Description("This test is adding shareskill in the shareskill list")]
        [TestCase(1)]
        public void Add_ShareSkill(int id)
        {
            shareSkillSteps.addShareSkill(id);
        }

        [Test, Order(2), Description("This test is updating an existing shareskill in the shareskill list")]
        [TestCase(2)]
        public void Update_ShareSkill(int id)
        {
            shareSkillSteps.updateShareSkill(id);
        }

        [Test, Order(3), Description("This test is deleting an existing shareskill in the shareskill list")]
        [TestCase(2)]
        public void Delete_ShareSkill(int id)
        {
            shareSkillSteps.deleteShareSkill(id);
        }
    }
}
