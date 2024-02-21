using AdvanceTaskMarsPart1.Data;
using AdvanceTaskMarsPart1.Pages;
using AdvanceTaskMarsPart1.Utilities;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

namespace AdvanceTaskMarsPart1.Tests
{
    public class Language_Tests : CommonDriver
    {
        LoginPage loginPageObj;
        LanguagePage languagePageObj;
        public static ExtentReports extent;
        public static ExtentTest test;

        public Language_Tests()
        {
            loginPageObj = new LoginPage();
            languagePageObj = new LanguagePage();
        }

        [OneTimeSetUp]
        public static void ExtentStart()
        {
            //Create new instance of ExtentReports
            extent = new ExtentReports();
            //Create new instance of ExtentSparkReporter
            var SparkReporter = new ExtentSparkReporter(@"D:\Sasikala\MVP_Studio\AdvanceTaskPart1\AdvanceTaskMarsPart1\AdvanceTaskMarsPart1\ExtentReports\Language.html");
            //Attach the ExtentSparkReporter to the ExtentReports
            extent.AttachReporter(SparkReporter);
        }

        [SetUp]
        public void SetUp()
        {
            Initialize();
            loginPageObj.LoginActions();
        }

        [Test, Order(1), Description("This test is deleting all records in language list")]
        public void Delete_All_Records()
        {
            test = extent.CreateTest("Delete_AllRecords").Info("Test started");
            languagePageObj.Delete_All_Records();
            test.Log(Status.Pass, "Delete_AllRecords passed");
        }

        [Test, Order(2), Description("This test is adding language in the language list")]
        public void Add_Language()
        {
            test = extent.CreateTest("Add_Language").Info("Test started");
            // Read test data for the AddLanguage test case
            List<LanguageData> languageDataList = LanguageDataHelper.ReadLanguageData(@"addLanguageData.json");

            // Iterate through test data and retrieve AddLanguage test data
            foreach (var languageData in languageDataList)
            {
                languagePageObj.Add_Language(languageData);
                string actualMessage = languagePageObj.getMessage();

                // Check if the Language contains special characters
                bool containsSpecialCharacters = ContainsSpecialCharacters(languageData.Language);
                if(containsSpecialCharacters)
                {
                    try
                    {
                        // Verify that the actual message matches the expected message for special characters
                        Assert.That(actualMessage == languageData.ExpectedMessage, "Actual message and expected message do not match");
                    }
                    catch(AssertionException ex)
                    {
                        // Log the failure and capture a screenshot
                        test.Log(Status.Fail, "Language failed: " + ex.Message);
                        Console.WriteLine(actualMessage);
                        CaptureScreenshot("SpecialCharsLanguageFailed");
                    }
                }
                else
                {
                    // Verify if special characters are not present in the Language
                    if (languagePageObj.getLanguage(languageData.Language) == languageData.Language)
                    {
                        Assert.That(languagePageObj.getLanguage(languageData.Language) == languageData.Language, "Actual language and expected language do not match");
                        Assert.That(languagePageObj.getLanguageLevel(languageData.LanguageLevel) == languageData.LanguageLevel, "Actual languagelevel and expected languagelevel do not match");
                        Console.WriteLine(actualMessage);
                    }
                    try
                    {
                        Assert.That(actualMessage == languageData.ExpectedMessage || actualMessage == languageData.ExpectedMessage, "Actual message and expected message do not match");
                        test.Log(Status.Pass, "Language passed");
                        // If information already exists, call the cancel method
                        if (actualMessage == languageData.ExpectedMessage)
                        {
                            languagePageObj.getCancel();
                        }
                    }
                    catch(AssertionException ex)
                    {
                        // Log the failure and capture a screenshot
                        test.Log(Status.Fail, "Language failed: " + ex.Message);
                        Console.WriteLine(actualMessage);
                        CaptureScreenshot("LanguageTestFailed");
                    }                    
                }
            }
        }

        [Test, Order(3), Description("This test is updating an existing language in the language list")]
        [TestCase(1)]
        public void Update_Language(int id)
        {
            test = extent.CreateTest("Update_Language").Info("Test started");

            // Read language data from the specified JSON file and retrieve the item with a matching Id
            LanguageData existingLanguageData = LanguageDataHelper.ReadLanguageData(@"addLanguageData.json").FirstOrDefault(x => x.Id == id);
            LanguageData newLanguageData = LanguageDataHelper.ReadLanguageData(@"updateLanguageData.json").FirstOrDefault(x => x.Id == id);

            languagePageObj.Update_Language(existingLanguageData, newLanguageData);
            string actualMessage = languagePageObj.getMessage();
            Assert.That(actualMessage == newLanguageData.ExpectedMessage, "Actual message and expected message do not match");

            Assert.That(languagePageObj.getLanguage(newLanguageData.Language) == newLanguageData.Language, "Updated language and expected language do not match");
            Assert.That(languagePageObj.getLanguageLevel(newLanguageData.LanguageLevel) == newLanguageData.LanguageLevel, "Updated languagelevel and expected languagelevel do not match");
            test.Log(Status.Pass, "Update_Language passed");
            Console.WriteLine(actualMessage);
        }

        [Test, Order(4), Description("This test is deleting an existing language in the language list")]
        [TestCase(1)]
        public void Delete_Language(int id)
        {
            test = extent.CreateTest("Delete_Language").Info("Test started");

            // Read language data from the specified JSON file and retrieve the item with a matching Id
            LanguageData languageData = LanguageDataHelper.ReadLanguageData(@"deleteLanguageData.json").FirstOrDefault(x => x.Id == id);

            languagePageObj.Delete_Language(languageData);
            string actualMessage = languagePageObj.getMessage();
            Assert.That(actualMessage == languageData.ExpectedMessage, "Actual message and expected message do not match");

            string deletedLanguage = languagePageObj.getDeletedLanguage(languageData);
            Assert.That(deletedLanguage == null, "Expected language has not been deleted");

            test.Log(Status.Pass, "Delete_Language passed");
            Console.WriteLine(actualMessage);
        }

        [Test, Order(5), Description("This test is adding empty textbox in the language list")]
        public void EmptyTextbox_Language()
        {
            test = extent.CreateTest("EmptyTextbox_Language").Info("Test started");
            // Read test data for the emptyLanguage test case
            List<LanguageData> languageDataList = LanguageDataHelper.ReadLanguageData(@"emptyLanguageData.json");

            // Iterate through test data and retrieve EmptyLanguage test data
            foreach (var languageData in languageDataList)
            {
                languagePageObj.Add_Language(languageData);
                string actualMessage = languagePageObj.getMessage();
                Assert.That(actualMessage == languageData.ExpectedMessage, "Actual message and expected message do not match");
                test.Log(Status.Pass, "EmptyTextbox_Language passed");
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
