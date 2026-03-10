using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumTesting;

[TestFixture]
[Description("Demonstrates advanced Selenium features — screenshots, waits, JS execution, locator strategies")]
public class AdvancedFeatureTests : TestBase
{
    [SetUp]
    public void AdvancedSetUp()
    {
        Login();
    }

    [Test]
    public void TakeScreenshot_ShouldSaveFile()
    {
        var path = TakeScreenshot("dashboard_screenshot");
        Assert.That(File.Exists(path), Is.True, $"Screenshot not saved at {path}");
        TestContext.WriteLine($"Screenshot saved: {path}");
    }

    [Test]
    public void ExplicitWait_ShouldWaitForDelayedNotification()
    {
        // The dashboard has a notification that appears after a 3-second JavaScript delay.
        // This is a classic explicit wait scenario.
        var notification = Wait.Until(d =>
        {
            var element = d.FindElement(By.Id("delayed-notification"));
            return element.Displayed ? element : null;
        });

        Assert.That(notification, Is.Not.Null);
        Assert.That(notification!.Text, Does.Contain("loaded successfully"));
    }

    [Test]
    public void ExecuteJavaScript_ReadPageTitle()
    {
        var jsExecutor = (IJavaScriptExecutor)Driver;
        var title = (string)jsExecutor.ExecuteScript("return document.title;");

        Assert.That(title, Does.Contain("Dashboard"));
    }

    [Test]
    public void ExecuteJavaScript_ScrollToElement()
    {
        Driver.FindElement(By.Id("nav-products")).Click();
        Wait.Until(d => d.Url.Contains("/Products"));

        var jsExecutor = (IJavaScriptExecutor)Driver;
        var lastRow = Driver.FindElements(By.CssSelector("#product-table tbody tr")).Last();

        jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", lastRow);

        Assert.That(lastRow.Displayed, Is.True);
    }

    [Test]
    public void ExecuteJavaScript_ModifyDom()
    {
        var jsExecutor = (IJavaScriptExecutor)Driver;

        // Inject a new element into the page via JavaScript
        jsExecutor.ExecuteScript(
            "var el = document.createElement('div');" +
            "el.id = 'injected-element';" +
            "el.textContent = 'Injected by Selenium';" +
            "document.body.appendChild(el);");

        var injected = Driver.FindElement(By.Id("injected-element"));
        Assert.That(injected.Text, Is.EqualTo("Injected by Selenium"));
    }

    [Test]
    public void GetPageSource_ShouldContainExpectedContent()
    {
        var pageSource = Driver.PageSource;

        Assert.Multiple(() =>
        {
            Assert.That(pageSource, Does.Contain("Dashboard"));
            Assert.That(pageSource, Does.Contain("Welcome"));
        });
    }

    [Test]
    public void GetCurrentUrl_ShouldMatchExpectedPattern()
    {
        Assert.That(Driver.Url, Does.Contain("/Dashboard"));

        Driver.FindElement(By.Id("nav-products")).Click();
        Wait.Until(d => d.Url.Contains("/Products"));
        Assert.That(Driver.Url, Does.Contain("/Products"));
    }

    [Test]
    public void GetElementCssProperty_ShouldReturnStyleValue()
    {
        var heading = Driver.FindElement(By.TagName("h1"));
        var fontSize = heading.GetCssValue("font-size");

        Assert.That(fontSize, Is.Not.Empty);
        TestContext.WriteLine($"H1 font-size: {fontSize}");
    }

    [Test]
    public void FindElementsByMultipleStrategies()
    {
        // By.Id
        var byId = Driver.FindElement(By.Id("welcome-message"));
        Assert.That(byId.Displayed, Is.True);

        // By.CssSelector
        var byCss = Driver.FindElement(By.CssSelector(".navbar-brand"));
        Assert.That(byCss.Displayed, Is.True);

        // By.XPath
        var byXPath = Driver.FindElement(By.XPath("//h1[@id='welcome-message']"));
        Assert.That(byXPath.Displayed, Is.True);

        // By.TagName
        var byTag = Driver.FindElements(By.TagName("a"));
        Assert.That(byTag.Count, Is.GreaterThan(0));

        // By.ClassName
        var byClass = Driver.FindElements(By.ClassName("nav-link"));
        Assert.That(byClass.Count, Is.GreaterThan(0));

        // By.LinkText
        var byLinkText = Driver.FindElement(By.LinkText("Products"));
        Assert.That(byLinkText.Displayed, Is.True);

        // By.PartialLinkText
        var byPartial = Driver.FindElement(By.PartialLinkText("Prod"));
        Assert.That(byPartial.Displayed, Is.True);
    }

    [Test]
    public void WindowManagement_ShouldResizeAndRestore()
    {
        var originalSize = Driver.Manage().Window.Size;
        Assert.That(originalSize.Width, Is.GreaterThan(0));

        Driver.Manage().Window.Size = new System.Drawing.Size(800, 600);
        var newSize = Driver.Manage().Window.Size;
        Assert.That(newSize.Width, Is.LessThanOrEqualTo(800));

        Driver.Manage().Window.Maximize();
        TestContext.WriteLine($"Original: {originalSize.Width}x{originalSize.Height}, Resized: {newSize.Width}x{newSize.Height}");
    }

    [Test]
    public void ActionChains_HoverOverNavLink()
    {
        var navLink = Driver.FindElement(By.Id("nav-products"));
        var actions = new Actions(Driver);
        actions.MoveToElement(navLink).Perform();

        Assert.That(navLink.Displayed, Is.True);
    }

    [Test]
    public void CookieManagement_ShouldReadAuthCookie()
    {
        var cookies = Driver.Manage().Cookies.AllCookies;
        Assert.That(cookies.Count, Is.GreaterThan(0));

        TestContext.WriteLine("=== Browser Cookies ===");
        foreach (var cookie in cookies)
        {
            TestContext.WriteLine($"  {cookie.Name} = {cookie.Value}");
        }
    }

    [Test]
    public void ImplicitWaitDemo_ShouldSetTimeout()
    {
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        // Navigates to a page and finds an element — the implicit wait
        // gives the page up to 5 seconds to render the element before failing.
        Driver.FindElement(By.Id("nav-products")).Click();
        var table = Driver.FindElement(By.Id("product-table"));

        Assert.That(table.Displayed, Is.True);

        // Reset implicit wait
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
    }
}
