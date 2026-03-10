using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace OrangeHRMSAutomation.Tests
{
    public class BaseTest
    {
        protected IWebDriver? Driver;
        protected static AventStack.ExtentReports.ExtentReports? Extent;
        protected ExtentTest? Test;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var htmlReporter = new ExtentHtmlReporter("TestReport.html");
            Extent = new AventStack.ExtentReports.ExtentReports();
            Extent.AttachReporter(htmlReporter);
        }

        [SetUp]
        public void StartBrowser()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
        }

        [TearDown]
        public void EndTest()
        {
            Driver?.Quit();
            Driver?.Dispose();
        }

        [OneTimeTearDown]
        public void GenerateReport()
        {
            Extent?.Flush();
        }
    }
}
