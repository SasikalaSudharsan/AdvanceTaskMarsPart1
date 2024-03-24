using AdvanceTaskMarsPart1.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using AdvanceTaskMarsPart1.Steps;

namespace AdvanceTaskMarsPart1.Tests
{
    [TestFixture]
    public class SearchSkills_Tests : BaseSetUp
    {
        LoginSteps loginSteps;
        SearchSkillSteps searchSkillSteps;
        public static ExtentTest test;

        public SearchSkills_Tests()
        {
            loginSteps = new LoginSteps();
            searchSkillSteps = new SearchSkillSteps();
        }

        [SetUp]
        public void SetUp()
        {
            Initialize();
            loginSteps.doLogin();
        }

        [Test, Order(1), Description("This test is returning the skills by category")]
        public void SearchSkills_Category()
        {
            test = extent.CreateTest("SearchSkills_Category").Info("Test started");
            searchSkillSteps.searchSkillCategory();           
            test.Log(Status.Pass, "SearchSkills_Category passed");
        }

        [Test, Order(2), Description("This test is returning the skills by filters")]
        public void SearchSkills_Filters()
        {
            test = extent.CreateTest("SearchSkills_Filters").Info("Test started");
            searchSkillSteps.searchSkillFilters();
            test.Log(Status.Pass, "SearchSkills_Filters passed");           
        } 

        [TearDown]
        public void TearDown()
        {
            Close();
        }
    }
}
