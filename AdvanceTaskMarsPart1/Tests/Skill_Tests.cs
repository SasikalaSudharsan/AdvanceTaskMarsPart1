using AdvanceTaskMarsPart1.Pages.Components.ProfileOverview;
using AdvanceTaskMarsPart1.Steps;
using AdvanceTaskMarsPart1.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework;

namespace AdvanceTaskMarsPart1.Tests
{
    [TestFixture]
    public class Skill_Tests : BaseSetUp
    {
        LoginSteps loginSteps;
        ProfileMenuTabsComponents profileMenuTabsComponents;
        AddAndUpdateSkillComponent addAndUpdateSkillComponent;
        SkillSteps skillSteps;
        public static ExtentTest test;

        public Skill_Tests()
        {
            loginSteps = new LoginSteps();
            profileMenuTabsComponents = new ProfileMenuTabsComponents();
            addAndUpdateSkillComponent = new AddAndUpdateSkillComponent();
            skillSteps = new SkillSteps();
        }

        [SetUp]
        public void SetUp()
        {
            Initialize();
            loginSteps.doLogin();
            profileMenuTabsComponents.clickSkillsTab();
        }

        [Test, Order(1), Description("This test is deleting all records in skill list")]
        public void Delete_All_Records()
        {
            test = extent.CreateTest("Delete_AllRecords").Info("Test started");
            addAndUpdateSkillComponent.DeleteAllRecords();
            test.Log(Status.Pass, "Delete_AllRecords passed");
        }

        [Test, Order(2), Description("This test is adding skill in the skill list")]
        public void Add_Skill()
        {
            test = extent.CreateTest("Add_Skill").Info("Test started");
            skillSteps.addSkill();
            test.Log(Status.Pass, "Add_Skill passed");
        }

        [Test, Order(3), Description("This test is updating an existing skill in the skill list")]
        [TestCase(1)]
        public void Update_Skill(int id)
        {
            test = extent.CreateTest("Update_Skill").Info("Test started");
            skillSteps.updateSkill(id);
            test.Log(Status.Pass, "Update_Skill passed");
        }

        [Test, Order(4), Description("This test is deleting an existing skill in the skill list")]
        [TestCase(1)]
        public void Delete_Skill(int id)
        {
            test = extent.CreateTest("Delete_Skill").Info("Test started");
            skillSteps.deleteSkill(id);
            test.Log(Status.Pass, "Delete_Skill passed");
        }

        [Test, Order(5), Description("This test is adding empty textbox in the skill list")]
        public void EmptyTextbox_Skill()
        {
            test = extent.CreateTest("EmptyTextbox_Skill").Info("Test started");
            skillSteps.emptySkill();
            test.Log(Status.Pass, "EmptyTextbox_Skill passed");
        }

        [Test, Order(6), Description("This test is adding exists skill in the skill list")]
        public void Exists_Skill()
        {
            test = extent.CreateTest("Exists_Skill").Info("Test started");
            skillSteps.existsSkill();
            test.Log(Status.Pass, "Exists_Skill passed");
        }

        [Test, Order(7), Description("This test is adding special characters in the skill list")]
        public void SpecialCharacters_Skill()
        {
            test = extent.CreateTest("SpecialCharacters_Skill").Info("Test started");
            skillSteps.specialCharactersSkill();
            test.Log(Status.Pass, "SpecialCharacters_Skill passed");
        }

        [TearDown]
        public void TearDown()
        {
            //If tests fails capture screenshot
            if(TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                string testName = TestContext.CurrentContext.Test.Name;
                test.Log(Status.Fail, $"Tests  '{testName}' failed");
                CaptureScreenshot(testName);
            }

            if(driver!=null)
            {
                Close();
            }
        }
    }
}
