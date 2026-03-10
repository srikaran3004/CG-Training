using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace OrangeHRMSAutomation
{
    public class LoginTest
    {
        IWebDriver driver;
        ExtentReports extent;
        ExtentTest test;

        [OneTimeSetUp]
        public void SetupReporting()
        {
            var htmlReporter = new ExtentHtmlReporter("TestReport.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver(@"C:\WebDrivers"); // Update path
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
        }

        [Test]
        public void LoginToOrangeHRMS()
        {
            test = extent.CreateTest("Login Test").Info("Test Started");

            try
            {
                driver.FindElement(By.Name("username")).SendKeys("Admin");
                driver.FindElement(By.Name("password")).SendKeys("admin123");
                driver.FindElement(By.CssSelector("button[type='submit']")).Click();

                Assert.IsTrue(driver.Url.Contains("dashboard"));
                test.Pass("Login successful");
            }
            catch (Exception ex)
            {
                test.Fail("Test failed: " + ex.Message);
                throw;
            }
        }

        [TearDown]
        public void EndTest()
        {
            driver.Quit();
        }

        [OneTimeTearDown]
        public void GenerateReport()
        {
            extent.Flush();
        }
    }
}