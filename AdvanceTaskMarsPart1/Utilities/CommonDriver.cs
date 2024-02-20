using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;   

namespace AdvanceTaskMarsPart1.Utilities
{
    public class CommonDriver
    {
        public static WebDriver driver;

        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/Home");
        }

        public void CaptureScreenshot(string screenshotName)
        {
            // Capture the screenshot
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string filePath = "D:\\Sasikala\\MVP_Studio\\AdvanceTaskPart1\\AdvanceTaskMarsPart1\\AdvanceTaskMarsPart1\\Screenshot";
            string screenshotPath = Path.Combine(filePath, $"{screenshotName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
            screenshot.SaveAsFile(screenshotPath);
        }

        public bool ContainsSpecialCharacters(string universityName)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(universityName, @"[^a-zA-Z0-9\s]");
        }

        public void Close()
        {
            driver.Quit();
        }
    }
}
