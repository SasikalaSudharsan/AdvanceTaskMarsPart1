using AdvanceTaskMarsPart1.Pages.Components.ProfileOverview;
using AdvanceTaskMarsPart1.Steps;
using AdvanceTaskMarsPart1.Utilities;
using AventStack.ExtentReports;
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
        public static ExtentTest test;

        public Language_Tests()
        {
            loginSteps = new LoginSteps();
            profileMenuTabsComponents = new ProfileMenuTabsComponents();
            addAndUpdateLanguageComponent = new AddAndUpdateLanguageComponent();
            languageSteps = new LanguageSteps();
        }

        [SetUp]
        public void SetUp()
        {
            Initialize();
            loginSteps.doLogin();
            profileMenuTabsComponents.clickLanguageTab();
        }

        [Test, Order(1), Description("This test is deleting all records in language list")]
        public void Delete_All_Records()
        {
            test = extent.CreateTest("Delete_AllRecords").Info("Test started");
            addAndUpdateLanguageComponent.DeleteAllRecords();
            test.Log(Status.Pass, "Delete_AllRecords passed");
        }

        [Test, Order(2), Description("This test is adding language in the language list")]
        public void Add_Language()
        {
            test = extent.CreateTest("Add_Language").Info("Test started");
            languageSteps.addLanguage();
            test.Log(Status.Pass, "Add_Language passed");
        }

        [Test, Order(3), Description("This test is updating an existing language in the language list")]
        [TestCase(1)]
        public void Update_Language(int id)
        {
            test = extent.CreateTest("Update_Language").Info("Test started");
            languageSteps.updateLanguage(id);
            test.Log(Status.Pass, "Update_Language passed");
        }

        [Test, Order(4), Description("This test is deleting an existing language in the language list")]
        [TestCase(1)]
        public void Delete_Language(int id)
        {
            test = extent.CreateTest("Delete_Language").Info("Test started");
            languageSteps.deleteLanguage(id);
            test.Log(Status.Pass, "Delete_Language passed");
        }

        [Test, Order(5), Description("This test is adding empty textbox in the language list")]
        public void EmptyTextbox_Language()
        {
            test = extent.CreateTest("EmptyTextbox_Language").Info("Test started");
            languageSteps.emptyLanguage();
            test.Log(Status.Pass, "EmptyTextbox_Language passed");
        }

        [Test, Order(6), Description("This test is adding exists language in the language list")]
        public void Exists_Language()
        {
            test = extent.CreateTest("Exists_Language").Info("Test started");
            languageSteps.existsLanguage();
            test.Log(Status.Pass, "Exists_Language passed");
        }

        [Test, Order(7), Description("This test is adding special characters in the language list")]
        public void SpecialCharacters_Language()
        {
            test = extent.CreateTest("SpecialCharacters_Language").Info("Test started");
            languageSteps.specialCharactersLanguage();
            test.Log(Status.Pass, "SpecialCharacters_Language passed");
        }

        [TearDown]
        public void TearDown()
        {
            //If tests fails capture screenshot
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                string testName = TestContext.CurrentContext.Test.Name;
                test.Log(Status.Fail, $"Tests  '{testName}' failed");
                CaptureScreenshot(testName);
            }

            if (driver != null)
            {
                Close();
            }
        }
    }
}
