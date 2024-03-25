using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework.Internal;

namespace AdvanceTaskMarsPart1.Utilities
{
    [SetUpFixture]
    public class BaseSetUp
    {
        public static WebDriver driver;
        public static ExtentReports extent;
        public static ExtentTest test;

        [OneTimeSetUp]
        public static void ExtentStart()
        {
            if (extent == null)
            {
                extent = new ExtentReports();
                var SparkReporter = new ExtentSparkReporter("D:\\Sasikala\\MVP_Studio\\AdvanceTaskPart1\\AdvanceTaskMarsPart1\\AdvanceTaskMarsPart1\\ExtentReport\\ExtentReport.html");
                extent.AttachReporter(SparkReporter);
            }
        }

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/Home");
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void TearDown()
        {
            //If tests fails capture screenshot
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                string testName = TestContext.CurrentContext.Test.Name;
                test.Log(Status.Fail, $"Tests  '{testName}' failed");
                CaptureScreenshot(testName);
            }
            driver.Quit();
        }

        [OneTimeTearDown]
        public static void ExtentClose()
        {
            extent.Flush();
        }

        public void CaptureScreenshot(string testName)
        {
            string screenshotFileName = $"screenshot_{testName}";
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string filePath = "D:\\Sasikala\\MVP_Studio\\AdvanceTaskPart1\\AdvanceTaskMarsPart1\\AdvanceTaskMarsPart1\\Screenshot";
            string screenshotPath = Path.Combine(filePath, $"{screenshotFileName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
            screenshot.SaveAsFile(screenshotPath);
        }
    }
}
