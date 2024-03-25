using AdvanceTaskMarsPart1.Pages.Components.ProfileOverview;
using AdvanceTaskMarsPart1.Steps;
using AdvanceTaskMarsPart1.Utilities;
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

        public Skill_Tests()
        {
            loginSteps = new LoginSteps();
            profileMenuTabsComponents = new ProfileMenuTabsComponents();
            addAndUpdateSkillComponent = new AddAndUpdateSkillComponent();
            skillSteps = new SkillSteps();
        }

        [SetUp]
        public void LoginActions()
        {
            loginSteps.doLogin();
            profileMenuTabsComponents.clickSkillsTab();
        }

        [Test, Order(1), Description("This test is deleting all records in skill list")]
        public void Delete_All_Records()
        {
            addAndUpdateSkillComponent.DeleteAllRecords();
        }

        [Test, Order(2), Description("This test is adding skill in the skill list")]
        public void Add_Skill()
        {
            skillSteps.addSkill();
        }

        [Test, Order(3), Description("This test is updating an existing skill in the skill list")]
        [TestCase(1)]
        public void Update_Skill(int id)
        {
            skillSteps.updateSkill(id);
        }

        [Test, Order(4), Description("This test is deleting an existing skill in the skill list")]
        [TestCase(1)]
        public void Delete_Skill(int id)
        {
            skillSteps.deleteSkill(id);
        }

        [Test, Order(5), Description("This test is adding empty textbox in the skill list")]
        public void EmptyTextbox_Skill()
        {
            skillSteps.emptySkill();
        }

        [Test, Order(6), Description("This test is adding exists skill in the skill list")]
        public void Exists_Skill()
        {
            skillSteps.existsSkill();
        }

        [Test, Order(7), Description("This test is adding special characters in the skill list")]
        public void SpecialCharacters_Skill()
        {
            skillSteps.specialCharactersSkill();
        }
    }
}
