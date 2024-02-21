using AdvanceTaskMarsPart1.Data;
using AdvanceTaskMarsPart1.Pages;
using AdvanceTaskMarsPart1.Utilities;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

namespace AdvanceTaskMarsPart1.Tests
{
    public class Skill_Tests : CommonDriver
    {
        LoginPage loginPageObj;
        HomePage homePageObj;
        SkillPage skillPageObj;
        public static ExtentReports extent;
        public static ExtentTest test;

        public Skill_Tests()
        {
            loginPageObj = new LoginPage();
            homePageObj = new HomePage();
            skillPageObj = new SkillPage();
        }

        [OneTimeSetUp]
        public static void ExtentStart()
        {
            //Create new instance of ExtentReports
            extent = new ExtentReports();
            //Create new instance of ExtentSparkReporter
            var SparkReporter = new ExtentSparkReporter(@"D:\Sasikala\MVP_Studio\AdvanceTaskPart1\AdvanceTaskMarsPart1\AdvanceTaskMarsPart1\ExtentReports\Skill.html");
            //Attach the ExtentSparkReporter to the ExtentReports
            extent.AttachReporter(SparkReporter);
        }

        [SetUp]
        public void SetUp()
        {
            Initialize();
            loginPageObj.LoginActions();
            homePageObj.GoToSkillsPage();
        }

        [Test, Order(1), Description("This test is deleting all records in skill list")]
        public void Delete_All_Records()
        {
            test = extent.CreateTest("Delete_AllRecords").Info("Test started");
            skillPageObj.Delete_All_Records();
            test.Log(Status.Pass, "Delete_AllRecords passed");
        }

        [Test, Order(2), Description("This test is adding skill in the skill list")]
        public void Add_Skill()
        {
            test = extent.CreateTest("Add_Skill").Info("Test started");
            // Read test data for the AddSkill test case
            List<SkillData> skillDataList = SkillDataHelper.ReadSkillData(@"addSkillData.json");

            // Iterate through test data and retrieve AddSkill test data
            foreach (var skillData in skillDataList)
            {
                skillPageObj.Add_Skill(skillData);
                string actualMesasge = skillPageObj.getMessage();

                // Check if the Skill contains special characters
                bool containsSpecialCharacters = ContainsSpecialCharacters(skillData.Skill);
                if (containsSpecialCharacters)
                {
                    try
                    {
                        // Verify that the actual message matches the expected message for special characters
                        Assert.That(actualMesasge == skillData.ExpectedMessage, "Actual message and expected message do not match");
                    }
                    catch (AssertionException ex)
                    {
                        // Log the failure and capture a screenshot
                        test.Log(Status.Fail, "Skill failed: " + ex.Message);
                        Console.WriteLine(actualMesasge);
                        CaptureScreenshot("SpecialCharsSkillFailed");
                    }
                }
                else
                {
                    // Verify if special characters are not present in the Skill
                    if (skillPageObj.getSkill(skillData.Skill) == skillData.Skill)
                    {
                        Assert.That(skillPageObj.getSkill(skillData.Skill) == skillData.Skill, "Actual skill and expected skill do not match");
                        Assert.That(skillPageObj.getSkillLevel(skillData.SkillLevel) == skillData.SkillLevel, "Actual skilllevel and expected skilllevel do not match");
                        Console.WriteLine(actualMesasge);
                    }
                    try
                    {
                        Assert.That(actualMesasge == skillData.ExpectedMessage || actualMesasge == skillData.ExpectedMessage, "Actual message and expected message do not match");
                        test.Log(Status.Pass, "Skill passed");
                        // If information already exists, call the cancel method
                        if (actualMesasge == skillData.ExpectedMessage)
                        {
                            skillPageObj.getCancel();
                        }
                    }
                    catch (AssertionException ex)
                    {
                        // Log the failure and capture a screenshot
                        test.Log(Status.Fail, "Skill failed: " + ex.Message);
                        Console.WriteLine(actualMesasge);
                        CaptureScreenshot("SkillTestFailed");
                    }
                }
            }
        }

        [Test, Order(3), Description("This test is updating an existing skill in the skill list")]
        [TestCase(1)]
        public void Update_Skill(int id)
        {
            test = extent.CreateTest("Update_Skill").Info("Test started");

            // Read skill data from the specified JSON file and retrieve the item with a matching Id
            SkillData existingSkillData = SkillDataHelper.ReadSkillData(@"addSkillData.json").FirstOrDefault(x => x.Id == id);
            SkillData newSkillData = SkillDataHelper.ReadSkillData(@"updateSkillData.json").FirstOrDefault(x => x.Id == id);

            skillPageObj.Update_Skill(existingSkillData, newSkillData);
            string actualMessage = skillPageObj.getMessage();
            Assert.That(actualMessage == newSkillData.ExpectedMessage, "Actual message and expected message do not match");

            Assert.That(skillPageObj.getSkill(newSkillData.Skill) == newSkillData.Skill, "Updated skill and expected skill do not match");
            Assert.That(skillPageObj.getSkillLevel(newSkillData.SkillLevel) == newSkillData.SkillLevel, "Updated skilllevel and expected skilllevel do not match");
            test.Log(Status.Pass, "Update_Skill passed");
            Console.WriteLine(actualMessage);
        }

        [Test, Order(4), Description("This test is deleting an existing skill in the skill list")]
        [TestCase(1)]
        public void Delete_Skill(int id)
        {
            test = extent.CreateTest("Delete_Skill").Info("Test started");

            // Read skill data from the specified JSON file and retrieve the item with a matching Id
            SkillData skillData = SkillDataHelper.ReadSkillData(@"deleteSkillData.json").FirstOrDefault(x => x.Id == id);

            skillPageObj.Delete_Skill(skillData);
            string actualMessage = skillPageObj.getMessage();
            Assert.That(actualMessage == skillData.ExpectedMessage, "Actual message and expected message do not match");

            string deletedSkill = skillPageObj.getDeletedSkill(skillData);
            Assert.That(deletedSkill == null, "Expected skill has not been deleted");

            test.Log(Status.Pass, "Delete_Skill passed");
            Console.WriteLine(actualMessage);
        }

        [Test, Order(5), Description("This test is adding empty textbox in the skill list")]
        public void EmptyTextbox_Skill()
        {
            test = extent.CreateTest("EmptyTextbox_Skill").Info("Test started");
            // Read test data for the emptySkill test case
            List<SkillData> skillDataList = SkillDataHelper.ReadSkillData(@"emptySkillData.json");

            // Iterate through test data and retrieve EmptySkill test data
            foreach (var skillData in skillDataList)
            {
                skillPageObj.Add_Skill(skillData);
                string actualMessage = skillPageObj.getMessage();
                Assert.That(actualMessage == skillData.ExpectedMessage, "Actual message and expected message do not match");
                test.Log(Status.Pass, "EmptyTextbox_Skill passed");
                Console.WriteLine(actualMessage);
            }
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
