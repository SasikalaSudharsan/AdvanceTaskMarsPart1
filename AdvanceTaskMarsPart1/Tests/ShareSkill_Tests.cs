using AdvanceTaskMarsPart1.Pages;
using AdvanceTaskMarsPart1.Utilities;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using AdvanceTaskMarsPart1.Data;

namespace AdvanceTaskMarsPart1.Tests
{
    public class ShareSkill_Tests : CommonDriver
    {
        LoginPage loginPageObj;
        HomePage homePageObj;
        ShareSkillPage shareSkillPageObj;
        public static ExtentReports extent;
        public static ExtentTest test;

        public ShareSkill_Tests()
        {
            loginPageObj = new LoginPage();
            homePageObj = new HomePage();
            shareSkillPageObj = new ShareSkillPage();
        }

        [OneTimeSetUp]
        public static void ExtentStart()
        {
            //Create new instance of ExtentReports
            extent = new ExtentReports();
            //Create new instance of ExtentSparkReporter
            var SparkReporter = new ExtentSparkReporter(@"D:\Sasikala\MVP_Studio\AdvanceTaskPart1\AdvanceTaskMarsPart1\AdvanceTaskMarsPart1\ExtentReports\ShareSkill.html");
            //Attach the ExtentSparkReporter to the ExtentReports
            extent.AttachReporter(SparkReporter);
        }

        [SetUp]
        public void SetUp()
        {
            Initialize();
            loginPageObj.LoginActions();
        }

        [Test, Order(1), Description("This test is adding shareskill in the shareskill list")]
        [TestCase(1)]
        public void Add_ShareSkill(int id)
        {
            test = extent.CreateTest("Add_ShareSkill").Info("Test started");
            ShareSkillData shareSkillData = ShareSkillDataHelper.ReadShareSkillData(@"addShareSkillData.json").FirstOrDefault(x => x.Id == id);
            homePageObj.GoToShareSkillPage();
            shareSkillPageObj.Add_ShareSkill(shareSkillData);
            //Check the added shareskill in the list in ManageListings 
            shareSkillPageObj.ManageListings();
            string newTitle = shareSkillPageObj.getTitle(shareSkillData.Title);
            Assert.That(newTitle == shareSkillData.Title, "Actual message and expected message do not match");
            test.Log(Status.Pass, "Add_ShareSkill passed");
        }

        [Test, Order(2), Description("This test is updating an existing shareskill in the shareskill list")]
        [TestCase(2)]
        public void Update_ShareSkill(int id)
        {
            test = extent.CreateTest("Update_ShareSkill").Info("Test started");

            ShareSkillData shareSkillData = ShareSkillDataHelper.ReadShareSkillData(@"addShareSkillData.json").FirstOrDefault(x => x.Id == id);

            shareSkillPageObj.Update_ShareSkill(shareSkillData);
            //Check the updated shareskill in the list in ManageListings 
            shareSkillPageObj.ManageListings();
            string newTitle = shareSkillPageObj.getTitle(shareSkillData.Title);
            Assert.That(newTitle == shareSkillData.Title, "Actual message and expected message do not match");
            test.Log(Status.Pass, "Update_ShareSkill passed");
        }

        [Test, Order(3), Description("This test is deleting an existing shareskill in the shareskill list")]
        [TestCase(2)]
        public void Delete_ShareSkill(int id)
        {
            test = extent.CreateTest("Delete_ShareSkill").Info("Test started");

            ShareSkillData shareSkillData = ShareSkillDataHelper.ReadShareSkillData(@"addShareSkillData.json").FirstOrDefault(x => x.Id == id);

            shareSkillPageObj.Delete_ShareSkill(shareSkillData);

            string actualMessage = shareSkillPageObj.getMessage();
            Assert.That(actualMessage == "Nunit has been deleted", "Actual message and expected message do not match");
            test.Log(Status.Pass, "Delete_ShareSkill passed");
            Console.WriteLine(actualMessage);
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
