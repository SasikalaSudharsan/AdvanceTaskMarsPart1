using AdvanceTaskMarsPart1.Pages;
using AdvanceTaskMarsPart1.Utilities;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using AdvanceTaskMarsPart1.Data;
using OpenQA.Selenium;

namespace AdvanceTaskMarsPart1.Tests
{
    public class SearchSkills_Tests : CommonDriver
    {
        LoginPage loginPageObj;
        SearchSkillsPage searchSkillsObj;
        public static ExtentReports extent;
        public static ExtentTest test;

        public SearchSkills_Tests()
        {
            loginPageObj = new LoginPage();
            searchSkillsObj = new SearchSkillsPage();
        }

        [OneTimeSetUp]
        public static void ExtentStart()
        {
            //Create new instance of ExtentReports
            extent = new ExtentReports();
            //Create new instance of ExtentSparkReporter
            var SparkReporter = new ExtentSparkReporter(@"D:\Sasikala\MVP_Studio\AdvanceTaskPart1\AdvanceTaskMarsPart1\AdvanceTaskMarsPart1\ExtentReports\SearchSkill.html");
            //Attach the ExtentSparkReporter to the ExtentReports
            extent.AttachReporter(SparkReporter);
        }

        [SetUp]
        public void SetUp()
        {
            Initialize();
            loginPageObj.LoginActions();
        }

        [Test, Order(1), Description("This test is returning the skills by category")]
        public void SearchSkills_Category()
        {
            test = extent.CreateTest("SearchSkills_Category").Info("Test started");
            List<SearchSkillData> searchSkillDataList = SearchSkillDataHelper.ReadSearchSkillData(@"searchSkillData.json");
            foreach (var searchSkillData in searchSkillDataList)
            {
                searchSkillsObj.SearchSkills_Categories(searchSkillData);
                List<IWebElement> skillList = searchSkillsObj.getSkillList();
                // Check if the skillList contains elements
                if (skillList.Count > 0)
                {
                    // If the skillList is not empty, each skill is displayed
                    foreach (var skill in skillList)
                    {
                        Assert.That(skill.Displayed, Is.True, "Skill list is empty");
                    } 
                }
                else
                {
                    //If the skillList is empty, print a message SkillList is empty
                    Assert.That(skillList, Is.Empty, "Skill list is not empty");
                    string Message = searchSkillsObj.getMessage();
                    Console.WriteLine(Message);
                }
                test.Log(Status.Pass, "SearchSkills_Category passed");
            }
        }

        [Test, Order(2), Description("This test is returning the skills by filters")]
        public void SearchSkills_Filters()
        {
            test = extent.CreateTest("SearchSkills_Filters").Info("Test started");
            List<SearchSkillData> searchSkillDataList = SearchSkillDataHelper.ReadSearchSkillData(@"searchSkillData.json");
            foreach (var searchSkillData in searchSkillDataList)
            {
                searchSkillsObj.SearchSkills_Filters(searchSkillData);
                List<IWebElement> skillList = searchSkillsObj.getSkillList();
                // Check if the skillList contains elements
                if (skillList.Count > 0)
                {
                    // If the skillList is not empty, each skill is displayed
                    foreach (var skill in skillList)
                    {
                        Assert.That(skill.Displayed, Is.True, "Skill list is empty");
                    }
                }
                else
                {
                    //If the skillList is empty, print a message SkillList is empty
                    Assert.That(skillList, Is.Empty, "Skill list is not empty");
                    string Message = searchSkillsObj.getMessage();
                    Console.WriteLine(Message);
                }
                test.Log(Status.Pass, "SearchSkills_Filters passed");
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
