using AdvanceTaskMarsPart1.Utilities;
using NUnit.Framework;
using AdvanceTaskMarsPart1.Steps;

namespace AdvanceTaskMarsPart1.Tests
{
    [TestFixture]
    public class SearchSkills_Tests : BaseSetUp
    {
        LoginSteps loginSteps;
        SearchSkillSteps searchSkillSteps;

        public SearchSkills_Tests()
        {
            loginSteps = new LoginSteps();
            searchSkillSteps = new SearchSkillSteps();
        }

        [SetUp]
        public void LoginActions()
        {
            loginSteps.doLogin();
        }

        [Test, Order(1), Description("This test is returning the skills by category")]
        public void SearchSkills_Category()
        {
            searchSkillSteps.searchSkillCategory();
        }

        [Test, Order(2), Description("This test is returning the skills by filters")]
        public void SearchSkills_Filters()
        {
            searchSkillSteps.searchSkillFilters();
        } 
    }
}
