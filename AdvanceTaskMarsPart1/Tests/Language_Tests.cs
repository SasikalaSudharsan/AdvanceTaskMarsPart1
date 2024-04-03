using AdvanceTaskMarsPart1.Pages.Components.ProfileOverview;
using AdvanceTaskMarsPart1.Steps;
using AdvanceTaskMarsPart1.Utilities;
using NUnit.Framework;

namespace AdvanceTaskMarsPart1.Tests
{
    [TestFixture]
    public class Language_Tests : BaseSetUp
    {
        LoginSteps loginSteps;
        ProfileMenuTabsComponents profileMenuTabsComponents;
        AddAndUpdateLanguageComponent addAndUpdateLanguageComponent;
        LanguageSteps languageSteps;

        public Language_Tests()
        {
            loginSteps = new LoginSteps();
            profileMenuTabsComponents = new ProfileMenuTabsComponents();
            addAndUpdateLanguageComponent = new AddAndUpdateLanguageComponent();
            languageSteps = new LanguageSteps();
        }

        [SetUp]
        public void LoginActions()
        {
            loginSteps.doLogin();
            profileMenuTabsComponents.clickLanguageTab();
        } 

        [Test, Order(1), Description("This test is deleting all records in language list")]
        public void Delete_All_Records()
        {
            addAndUpdateLanguageComponent.DeleteAllRecords();
        }

        [Test, Order(2), Description("This test is adding language in the language list")]
        public void Add_Language()
        {
            languageSteps.addLanguage();
        }

        [Test, Order(3), Description("This test is updating an existing language in the language list")]
        [TestCase(1)]
        public void Update_Language(int id)
        {
            languageSteps.updateLanguage(id);
        }

        [Test, Order(4), Description("This test is deleting an existing language in the language list")]
        [TestCase(1)]
        public void Delete_Language(int id)
        {
            languageSteps.deleteLanguage(id);
        }

        [Test, Order(5), Description("This test is adding empty textbox in the language list")]
        public void EmptyTextbox_Language()
        {
            languageSteps.emptyLanguage();
        }

        [Test, Order(6), Description("This test is adding exists language in the language list")]
        public void Exists_Language()
        {
            languageSteps.existsLanguage();
        }

        [Test, Order(7), Description("This test is adding special characters in the language list")]
        public void SpecialCharacters_Language()
        {
            languageSteps.specialCharactersLanguage();
        }
    }
}
