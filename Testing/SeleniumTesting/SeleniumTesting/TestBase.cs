using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTesting;

/// <summary>
/// Base class for all Selenium tests. Provides shared WebDriver setup/teardown,
/// helper methods for login, and screenshot capture.
/// 
/// IMPORTANT: Before running these tests, start the DemoWebApp project:
///   cd DemoWebApp
///   dotnet run
/// The app must be running at http://localhost:5050
/// </summary>
public abstract class TestBase
{
    protected IWebDriver Driver { get; private set; } = null!;
    protected WebDriverWait Wait { get; private set; } = null!;
    protected const string BaseUrl = "http://localhost:5050";

    [SetUp]
    public void BaseSetUp()
    {
        var options = new ChromeOptions();
        // Uncomment the line below to run in headless mode (no browser UI)
        // options.AddArgument("--headless=new");
        options.AddArgument("--start-maximized");

        Driver = new ChromeDriver(options);
        Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
    }

    [TearDown]
    public void BaseTearDown()
    {
        Driver?.Quit();
        Driver?.Dispose();
    }

    /// <summary>
    /// Logs into the DemoWebApp with the given credentials.
    /// Defaults to the admin account.
    /// </summary>
    protected void Login(string username = "admin", string password = "Admin@123")
    {
        Driver.Navigate().GoToUrl(BaseUrl);
        Driver.FindElement(By.Id("username")).Clear();
        Driver.FindElement(By.Id("username")).SendKeys(username);
        Driver.FindElement(By.Id("password")).Clear();
        Driver.FindElement(By.Id("password")).SendKeys(password);
        Driver.FindElement(By.Id("login-btn")).Click();
        Wait.Until(d => d.Url.Contains("/Dashboard"));
    }

    /// <summary>
    /// Takes a screenshot and saves it to the test output directory.
    /// Returns the file path of the saved screenshot.
    /// </summary>
    protected string TakeScreenshot(string name)
    {
        var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
        var path = Path.Combine(
            TestContext.CurrentContext.WorkDirectory,
            $"{name}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
        File.WriteAllBytes(path, screenshot.AsByteArray);
        return path;
    }
}
