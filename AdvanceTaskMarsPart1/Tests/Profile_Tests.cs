using AdvanceTaskMarsPart1.Utilities;
using NUnit.Framework;
using AdvanceTaskMarsPart1.Steps;

namespace AdvanceTaskMarsPart1.Tests
{
    [TestFixture]
    public class Profile_Tests : BaseSetUp
    {
        LoginSteps loginSteps;
        ProfileSteps profileSteps;

        public Profile_Tests()
        {
            loginSteps = new LoginSteps();
            profileSteps = new ProfileSteps();
        }

        [SetUp]
        public void LoginActions()
        {
            loginSteps.doLogin();
        }

        [Test, Order(1), Description("This test is updating Availability type in the Profile")]
        [TestCase(1)]
        public void Edit_Availability(int id)
        {
            profileSteps.editAvailability(id);
        }
        
        [Test, Order(2), Description("This test is cancelling Availability type in the Profile")]
        public void Cancel_Availability()
        {
            profileSteps.cancelAvailability();
        }
        
        [Test, Order(3), Description("This test is updating Hours in the Profile")]
        [TestCase(2)]
        public void Edit_Hours(int id)
        {
            profileSteps.editHours(id);
        }

        [Test, Order(4), Description("This test is updating EarnTarget in the Profile")]
        [TestCase(3)]
        public void Edit_EarnTarget(int id)
        {
            profileSteps.editEarnTarget(id);
        } 
    }
}
