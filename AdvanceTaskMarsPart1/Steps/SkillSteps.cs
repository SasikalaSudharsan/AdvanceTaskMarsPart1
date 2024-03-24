using AdvanceTaskMarsPart1.AssertHelpers;
using AdvanceTaskMarsPart1.Data;
using AdvanceTaskMarsPart1.Pages.Components.ProfileOverview;
using AdvanceTaskMarsPart1.Utilities;

namespace AdvanceTaskMarsPart1.Steps
{
    public class SkillSteps
    {
        AddAndUpdateSkillComponent addAndUpdateSkillComponent;
        ProfileSkillOverviewComponent profileSkillOverviewComponent;

        public SkillSteps()
        {
            addAndUpdateSkillComponent = new AddAndUpdateSkillComponent();
            profileSkillOverviewComponent = new ProfileSkillOverviewComponent();
        }

        public void addSkill()
        {
            // Read test data for the AddSkill test case
            List<SkillData> skillDataList = JsonReader.LoadData<SkillData>(@"addSkillData.json");
            // Iterate through test data and retrieve AddSkill test data
            foreach (var skillData in skillDataList)
            {
                profileSkillOverviewComponent.clickAddSkillButton();
                addAndUpdateSkillComponent.addSkill(skillData);
                string actualMessage = addAndUpdateSkillComponent.getMessage();
                SkillAssertHelper.assertAddSkillSuccessMessage(skillData.ExpectedMessage, actualMessage);
                Console.WriteLine(actualMessage);
            }
        }

        public void updateSkill(int id)
        {
            // Read skill data from the specified JSON file and retrieve the item with a matching Id
            SkillData existingSkillData = JsonReader.LoadData<SkillData>(@"addSkillData.json").FirstOrDefault(x => x.Id == id);
            SkillData newSkillData = JsonReader.LoadData<SkillData>(@"updateSkillData.json").FirstOrDefault(x => x.Id == id);
            profileSkillOverviewComponent.clickUpdateSkillButton(existingSkillData);
            addAndUpdateSkillComponent.updateSkill(newSkillData);
            string actualMessage = addAndUpdateSkillComponent.getMessage();
            SkillAssertHelper.assertUpdateSkillSuccessMessage(newSkillData.ExpectedMessage, actualMessage);
            Console.WriteLine(actualMessage);
        }

        public void deleteSkill(int id)
        {
            // Read skill data from the specified JSON file and retrieve the item with a matching Id
            SkillData skillData = JsonReader.LoadData<SkillData>(@"deleteSkillData.json").FirstOrDefault(x => x.Id == id);
            profileSkillOverviewComponent.clickDeleteSkillButton(skillData);
            string actualMessage = addAndUpdateSkillComponent.getMessage();
            SkillAssertHelper.assertDeleteSkillSuccessMessage(skillData.ExpectedMessage, actualMessage);
            Console.WriteLine(actualMessage);
        }

        public void emptySkill()
        {
            // Read test data for the emptySkill test case
            List<SkillData> skillDataList = JsonReader.LoadData<SkillData>(@"emptySkillData.json");
            // Iterate through test data and retrieve EmptySkill test data
            foreach (var skillData in skillDataList)
            {
                profileSkillOverviewComponent.clickAddSkillButton();
                addAndUpdateSkillComponent.addSkill(skillData);
                string actualMessage = addAndUpdateSkillComponent.getMessage();
                SkillAssertHelper.assertEmptySkillSuccessMessage(skillData.ExpectedMessage, actualMessage);
                Console.WriteLine(actualMessage);
            }
        }

        public void existsSkill()
        {
            // Read test data for the existsSkill test case
            List<SkillData> skillDataList = JsonReader.LoadData<SkillData>(@"existsSkillData.json");
            // Iterate through test data and retrieve existsSkill test data
            foreach (var skillData in skillDataList)
            {
                profileSkillOverviewComponent.clickAddSkillButton();
                addAndUpdateSkillComponent.addSkill(skillData);
                string actualMessage = addAndUpdateSkillComponent.getMessage();
                SkillAssertHelper.assertExistsSkillSuccessMessage(skillData.ExpectedMessage, actualMessage);
                Console.WriteLine(actualMessage);
            }
        }

        public void specialCharactersSkill()
        {
            // Read test data for the SpecialCharsSkill test case
            List<SkillData> skillDataList = JsonReader.LoadData<SkillData>(@"specialCharsSkillData.json");
            // Iterate through test data and retrieve SpecialCharsSkill test data
            foreach (var skillData in skillDataList)
            {
                profileSkillOverviewComponent.clickAddSkillButton();
                addAndUpdateSkillComponent.addSkill(skillData);
                string actualMessage = addAndUpdateSkillComponent.getMessage();
                SkillAssertHelper.assertSpecialCharsSkillSuccessMessage(skillData.ExpectedMessage, actualMessage);
                Console.WriteLine(actualMessage);
            }
        }
    }
}
