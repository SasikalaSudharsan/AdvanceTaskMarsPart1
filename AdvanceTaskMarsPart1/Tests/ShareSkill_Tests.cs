using AdvanceTaskMarsPart1.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using AdvanceTaskMarsPart1.Steps;

namespace AdvanceTaskMarsPart1.Tests
{
    [TestFixture]
    public class ShareSkill_Tests : BaseSetUp
    {
        LoginSteps loginSteps;
        ShareSkillSteps shareSkillSteps;
        public static ExtentTest test;

        public ShareSkill_Tests()
        {
            loginSteps = new LoginSteps();
            shareSkillSteps = new ShareSkillSteps();
        }

        [SetUp]
        public void SetUp()
        {
            Initialize();
            loginSteps.doLogin();
        }

        [Test, Order(1), Description("This test is adding shareskill in the shareskill list")]
        [TestCase(1)]
        public void Add_ShareSkill(int id)
        {
            test = extent.CreateTest("Add_ShareSkill").Info("Test started");
            shareSkillSteps.addShareSkill(id);
            test.Log(Status.Pass, "Add_ShareSkill passed");
        }

        [Test, Order(2), Description("This test is updating an existing shareskill in the shareskill list")]
        [TestCase(2)]
        public void Update_ShareSkill(int id)
        {
            test = extent.CreateTest("Update_ShareSkill").Info("Test started");
            shareSkillSteps.updateShareSkill(id);
            test.Log(Status.Pass, "Update_ShareSkill passed");
        }

        [Test, Order(3), Description("This test is deleting an existing shareskill in the shareskill list")]
        [TestCase(2)]
        public void Delete_ShareSkill(int id)
        {
            test = extent.CreateTest("Delete_ShareSkill").Info("Test started");
            shareSkillSteps.deleteShareSkill(id);
            test.Log(Status.Pass, "Delete_ShareSkill passed");
        }

        [TearDown]
        public void TearDown()
        {
            Close();
        }
    }
}
