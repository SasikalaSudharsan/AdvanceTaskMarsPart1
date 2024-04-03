using AdvanceTaskMarsPart1.AssertHelpers;
using AdvanceTaskMarsPart1.Data;
using AdvanceTaskMarsPart1.Pages.Components.ProfileOverview;
using AdvanceTaskMarsPart1.Utilities;

namespace AdvanceTaskMarsPart1.Steps
{
    public class LanguageSteps : BaseSetUp
    {
        ProfileLanguageOverviewComponent profileLanguageOverviewComponent;
        AddAndUpdateLanguageComponent addAndUpdateLanguageComponent;

        public LanguageSteps()
        {
            profileLanguageOverviewComponent = new ProfileLanguageOverviewComponent();
            addAndUpdateLanguageComponent = new AddAndUpdateLanguageComponent();
        }

        public void addLanguage()
        {
            // Read test data for the AddLanguage test case
            List<LanguageData> languageDataList = JsonReader.LoadData<LanguageData>(@"addLanguageData.json");
            // Iterate through test data and retrieve AddLanguage test data
            foreach (var languageData in languageDataList)
            {
                profileLanguageOverviewComponent.clickAddLanguageButton();
                addAndUpdateLanguageComponent.addLanguage(languageData);
                string actualMessage = addAndUpdateLanguageComponent.getMessage();
                LanguageAssertHelper.assertAddLanguageSuccessMessage(languageData.ExpectedMessage, actualMessage);
                Console.WriteLine(actualMessage);
            }
        }

        public void updateLanguage(int id)
        {
            // Read language data from the specified JSON file and retrieve the item with a matching Id
            LanguageData existingLanguageData = JsonReader.LoadData<LanguageData>(@"addLanguageData.json").FirstOrDefault(x => x.Id == id);
            LanguageData newLanguageData = JsonReader.LoadData<LanguageData>(@"updateLanguageData.json").FirstOrDefault(x => x.Id == id);
            profileLanguageOverviewComponent.clickUpdateLanguageButton(existingLanguageData);
            addAndUpdateLanguageComponent.updateLanguage(newLanguageData);
            string actualMessage = addAndUpdateLanguageComponent.getMessage();
            LanguageAssertHelper.assertUpdateLanguageSuccessMessage(newLanguageData.ExpectedMessage, actualMessage);
            Console.WriteLine(actualMessage);
        }

        public void deleteLanguage(int id)
        {
            // Read language data from the specified JSON file and retrieve the item with a matching Id
            LanguageData languageData = JsonReader.LoadData<LanguageData>(@"deleteLanguageData.json").FirstOrDefault(x => x.Id == id);
            profileLanguageOverviewComponent.clickDeleteLanguageButton(languageData);
            string actualMessage = addAndUpdateLanguageComponent.getMessage();
            LanguageAssertHelper.assertDeleteLanguageSuccessMessage(languageData.ExpectedMessage, actualMessage);
            Console.WriteLine(actualMessage);
        }

        public void emptyLanguage()
        {
            // Read test data for the emptyLanguage test case
            List<LanguageData> languageDataList = JsonReader.LoadData<LanguageData>(@"emptyLanguageData.json");
            // Iterate through test data and retrieve emptyLanguage test data
            foreach (var languageData in languageDataList)
            {
                profileLanguageOverviewComponent.clickAddLanguageButton();
                addAndUpdateLanguageComponent.addLanguage(languageData);
                string actualMessage = addAndUpdateLanguageComponent.getMessage();
                LanguageAssertHelper.assertEmptyLanguageSuccessMessage(languageData.ExpectedMessage, actualMessage);
                Console.WriteLine(actualMessage);
            }
        }

        public void existsLanguage()
        {
            // Read test data for the existsLanguage test case
            List<LanguageData> languageDataList = JsonReader.LoadData<LanguageData>(@"existsLanguageData.json");
            // Iterate through test data and retrieve existsLanguage test data
            foreach (var languageData in languageDataList)
            {
                profileLanguageOverviewComponent.clickAddLanguageButton();
                addAndUpdateLanguageComponent.addLanguage(languageData);
                string actualMessage = addAndUpdateLanguageComponent.getMessage();
                LanguageAssertHelper.assertExistsLanguageSuccessMessage(languageData.ExpectedMessage, actualMessage);
                Console.WriteLine(actualMessage);
            }
        }

        public void specialCharactersLanguage()
        {
            // Read test data for the spacialCharsLanguage test case
            List<LanguageData> languageDataList = JsonReader.LoadData<LanguageData>(@"specialCharsLanguageData.json");
            // Iterate through test data and retrieve spacialCharsLanguage test data
            foreach (var languageData in languageDataList)
            {
                profileLanguageOverviewComponent.clickAddLanguageButton();
                addAndUpdateLanguageComponent.addLanguage(languageData);
                string actualMessage = addAndUpdateLanguageComponent.getMessage();
                LanguageAssertHelper.assertSpecialCharsLanguageSuccessMessage(languageData.ExpectedMessage, actualMessage);
                Console.WriteLine(actualMessage);
            }
        }
    }
}
