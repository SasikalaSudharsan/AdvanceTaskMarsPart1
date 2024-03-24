using AdvanceTaskMarsPart1.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using AdvanceTaskMarsPart1.Steps;

namespace AdvanceTaskMarsPart1.Tests
{
    [TestFixture]
    public class Profile_Tests : BaseSetUp
    {
        LoginSteps loginSteps;
        ProfileSteps profileSteps;
        public static ExtentTest test;

        public Profile_Tests()
        {
            loginSteps = new LoginSteps();
            profileSteps = new ProfileSteps();
        }

        [SetUp]
        public void SetUp()
        {
            Initialize();
            loginSteps.doLogin();
        }

        [Test, Order(1), Description("This test is updating Availability type in the Profile")]
        [TestCase(1)]
        public void Edit_Availability(int id)
        {
            test = extent.CreateTest("Edit_Availability").Info("Test Started");
            profileSteps.editAvailability(id);
            test.Log(Status.Pass, "Edit_Availability passed");
        }
        
        [Test, Order(2), Description("This test is cancelling Availability type in the Profile")]
        public void Cancel_Availability()
        {
            test = extent.CreateTest("Cancel_Availability").Info("Test Started");
            profileSteps.cancelAvailability();
            test.Log(Status.Pass, "Cancel_Availability passed");
        }
        
        [Test, Order(3), Description("This test is updating Hours in the Profile")]
        [TestCase(2)]
        public void Edit_Hours(int id)
        {
            test = extent.CreateTest("Edit_Hours").Info("Test Started");
            profileSteps.editHours(id);
            test.Log(Status.Pass, "Edit_Hours passed");
        }

        [Test, Order(4), Description("This test is updating EarnTarget in the Profile")]
        [TestCase(3)]
        public void Edit_EarnTarget(int id)
        {
            test = extent.CreateTest("Edit_EarnTarget").Info("Test Started");
            profileSteps.editEarnTarget(id);
            test.Log(Status.Pass, "Edit_EarnTarget passed");
        }  

        [TearDown]
        public void TearDown()
        {
            Close();
        }
    }
}
