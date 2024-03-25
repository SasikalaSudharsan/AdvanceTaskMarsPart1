using AdvanceTaskMarsPart1.AssertHelpers;
using AdvanceTaskMarsPart1.Data;
using AdvanceTaskMarsPart1.Pages.Components;
using AdvanceTaskMarsPart1.Utilities;

namespace AdvanceTaskMarsPart1.Steps
{
    public class ShareSkillSteps
    {
        ShareSkillOverviewComponent shareSkillOverviewComponent;
        AddAndUpdateShareSkillComponents addAndUpdateShareSkillComponents;


        public ShareSkillSteps()
        {
            shareSkillOverviewComponent = new ShareSkillOverviewComponent();
            addAndUpdateShareSkillComponents = new AddAndUpdateShareSkillComponents();
        }

        public void addShareSkill(int id)
        {
            ShareSkillData shareSkillData = JsonReader.LoadData<ShareSkillData>(@"ShareSkillData.json").FirstOrDefault(x => x.Id == id);
            shareSkillOverviewComponent.clickShareSkillButton();
            addAndUpdateShareSkillComponents.addShareSkill(shareSkillData);
            //Check the added shareskill in the list in ManageListings 
            shareSkillOverviewComponent.clickManageListings();
            string newTitle = addAndUpdateShareSkillComponents.getTitle(shareSkillData.Title);
            ShareSkillAssertHelper.assertAddShareSkillSuccessMessage(shareSkillData.Title, newTitle);
        }

        public void updateShareSkill(int id)
        {
            ShareSkillData shareSkillData = JsonReader.LoadData<ShareSkillData>(@"ShareSkillData.json").FirstOrDefault(x => x.Id == id);
            shareSkillOverviewComponent.clickManageListings();
            shareSkillOverviewComponent.clickUpdateButton(shareSkillData);
            addAndUpdateShareSkillComponents.updateShareSkill(shareSkillData);
            //Check the updated shareskill in the list in ManageListings 
            shareSkillOverviewComponent.clickManageListings();
            string newTitle = addAndUpdateShareSkillComponents.getTitle(shareSkillData.Title);
            ShareSkillAssertHelper.assertUpdateShareSkillSuccessMessage(shareSkillData.Title, newTitle);
        }

        public void deleteShareSkill(int id)
        {
            ShareSkillData shareSkillData = JsonReader.LoadData<ShareSkillData>(@"ShareSkillData.json").FirstOrDefault(x => x.Id == id);
            shareSkillOverviewComponent.clickManageListings();
            shareSkillOverviewComponent.clickDeleteButton(shareSkillData);
            string actualMessage = addAndUpdateShareSkillComponents.getMessage();
            ShareSkillAssertHelper.assertDeleteShareSkillSuccessMessage("Nunit has been deleted", actualMessage);
            Console.WriteLine(actualMessage);
        }
    }
}
