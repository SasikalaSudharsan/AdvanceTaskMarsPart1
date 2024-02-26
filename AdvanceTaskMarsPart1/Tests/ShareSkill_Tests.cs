using AdvanceTaskMarsPart1.Pages;
using AdvanceTaskMarsPart1.Utilities;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [Test]
        public void Add_ShareSkill()
        {
            homePageObj.GoToShareSkillPage();
            shareSkillPageObj.Add_ShareSkill();
            //Check the added shareskill in the list in ManageListings 
            shareSkillPageObj.ManageListings();
            string newTitle = shareSkillPageObj.getTitle("Selenium");
            Assert.That(newTitle == "Selenium", "Actual message and expected message do not match");
        }

        [Test]
        public void Update_ShareSkill()
        {
            shareSkillPageObj.Update_ShareSkill();
            //Check the updated shareskill in the list in ManageListings 
            shareSkillPageObj.ManageListings();
            string newTitle = shareSkillPageObj.getTitle("Nunit");
            Assert.That(newTitle == "Nunit", "Actual message and expected message do not match"); 
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
