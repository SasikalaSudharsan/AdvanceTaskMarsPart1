using AdvanceTaskMarsPart1.AssertHelpers;
using AdvanceTaskMarsPart1.Data;
using AdvanceTaskMarsPart1.Pages.Components.ProfileAboutMe;
using AdvanceTaskMarsPart1.Utilities;

namespace AdvanceTaskMarsPart1.Steps
{
    public class ProfileSteps : BaseSetUp
    {
        ProfileComponents profileComponents;

        public ProfileSteps()
        {
            profileComponents = new ProfileComponents();
        }

        public void editAvailability(int id)
        {
            ProfileData profileData = JsonReader.LoadData<ProfileData>(@"ProfileData.json").FirstOrDefault(x => x.Id == id);
            profileComponents.editAvailability(profileData.Availability);
            // Retrieve the message displayed after updating Availability
            string actualMessage = profileComponents.getMessage();
            ProfileAssertHelper.assertAvailabilitySuccessMessage(profileData.ExpectedMessage, actualMessage);
            Console.WriteLine(actualMessage);
        }

        public void cancelAvailability()
        {
            profileComponents.cancelAvailabilityButton();
        }

        public void editHours(int id)
        {
            ProfileData profileData = JsonReader.LoadData<ProfileData>(@"ProfileData.json").FirstOrDefault(x => x.Id == id);
            profileComponents.editHours(profileData.Hours);
            string actualMessage = profileComponents.getMessage();
            ProfileAssertHelper.assertHoursSuccessMessage(profileData.ExpectedMessage, actualMessage);
            Console.WriteLine(actualMessage);
        }

        public void editEarnTarget(int id)
        {
            ProfileData profileData = JsonReader.LoadData<ProfileData>(@"ProfileData.json").FirstOrDefault(x => x.Id == id);
            profileComponents.editEarnTarget(profileData.EarnTarget);
            string actualMessage = profileComponents.getMessage();
            ProfileAssertHelper.assertEarnTargetSuccessMessage(profileData.ExpectedMessage, actualMessage);
            Console.WriteLine(actualMessage);
        }
    }
}
