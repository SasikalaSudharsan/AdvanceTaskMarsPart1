using AdvanceTaskMarsPart1.Pages;
using AdvanceTaskMarsPart1.Utilities;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using AdvanceTaskMarsPart1.Data;

namespace AdvanceTaskMarsPart1.Tests
{
    public class Profile_Tests : CommonDriver
    {
        LoginPage loginPageObj;
        ProfilePage profilePageObj;
        public static ExtentReports extent;
        public static ExtentTest test;

        public Profile_Tests()
        {
            loginPageObj = new LoginPage();
            profilePageObj = new ProfilePage();
        }

        [OneTimeSetUp]
        public static void ExtentStart()
        {
            //Create new instance of ExtentReports
            extent = new ExtentReports();
            //Create new instance of ExtentSparkReporter
            var SparkReporter = new ExtentSparkReporter(@"D:\Sasikala\MVP_Studio\AdvanceTaskPart1\AdvanceTaskMarsPart1\AdvanceTaskMarsPart1\ExtentReports\Profile.html");
            //Attach the ExtentSparkReporter to the ExtentReports
            extent.AttachReporter(SparkReporter);
        }

        [SetUp]
        public void SetUp()
        {
            Initialize();
            loginPageObj.LoginActions();
        }

        [Test, Order(1), Description("This test is updating Availability type in the Profile")]
        public void Edit_Availability()
        {
            test = extent.CreateTest("Edit_Availability").Info("Test Started");
            //Read data from the specified Json file
            ProfileData profileData = ProfileDataHelper.ReadProfileData(@"ProfileData.json");
            profilePageObj.Edit_Availability(profileData.Availability);
            // Retrieve the message displayed after updating Availability
            string actualMessage = profilePageObj.getMessage();
            Assert.That(actualMessage == profileData.ExpectedMessage, "Actual message and expected message do not match");
            // Assert that the updated availability matches the expected availability
            Assert.That(profilePageObj.getAvailabilityType(profileData.Availability) == profileData.Availability, "Updated AvailabilityType and expected AvailabilityType do not match");
            test.Log(Status.Pass, "Edit_Availability passed");
        }

        [Test, Order(2), Description("This test is cancelling Availability type in the Profile")]
        public void Cancel_Availability()
        {
            test = extent.CreateTest("Cancel_Availability").Info("Test Started");
            profilePageObj.Cancel_Availability();
            test.Log(Status.Pass, "Cancel_Availability passed");
        }

        [Test, Order(3), Description("This test is updating Hours in the Profile")]
        public void Edit_Hours()
        {
            test = extent.CreateTest("Edit_Hours").Info("Test Started");
            //Read data from the specified Json file
            ProfileData profileData = ProfileDataHelper.ReadProfileData(@"ProfileData.json");
            profilePageObj.Edit_Hours(profileData.Hours);
            // Retrieve the message displayed after updating Hours
            string actualMessage = profilePageObj.getMessage();
            Assert.That(actualMessage == profileData.ExpectedMessage, "Actual message and expected message do not match");
            // Assert that the updated hours matches the expected hours
            Assert.That(profilePageObj.getHours(profileData.Hours) == profileData.Hours, "Updated Hours and expected Hours do not match");
            test.Log(Status.Pass, "Edit_Hours passed");
        }

        [Test, Order(4), Description("This test is updating EarnTarget in the Profile")]
        public void Edit_EarnTarget()
        {
            test = extent.CreateTest("Edit_EarnTarget").Info("Test Started");
            //Read data from the specified Json file
            ProfileData profileData = ProfileDataHelper.ReadProfileData(@"ProfileData.json");
            profilePageObj.Edit_EarnTarget(profileData.EarnTarget);
            // Retrieve the message displayed after updating EarnTarget
            string actualMessage = profilePageObj.getMessage();
            Assert.That(actualMessage == profileData.ExpectedMessage, "Actual message and expected message do not match");
            // Assert that the updated earnTarget matches the expected earnTarget
            Assert.That(profilePageObj.getEarnTarget(profileData.EarnTarget) == profileData.EarnTarget, "Updated EarnTarget and expected EarnTarget do not match");
            test.Log(Status.Pass, "Edit_EarnTarget passed");
        }

        [TearDown]
        public void TearDown()
        {
            Close();
        }

        [OneTimeTearDown]
        public static void ExtentClose()
        {
            //Flush the ExtentReports instance
            extent.Flush();
        }
    }
}
