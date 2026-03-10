using OpenQA.Selenium;

namespace SeleniumTesting;

[TestFixture]
[Description("Demonstrates Selenium page navigation and browser history")]
public class NavigationTests : TestBase
{
    [SetUp]
    public void NavigationSetUp()
    {
        Login();
    }

    [Test]
    public void NavigateToDashboard_ShouldShowDashboardPage()
    {
        Driver.FindElement(By.Id("nav-dashboard")).Click();
        Wait.Until(d => d.Url.Contains("/Dashboard"));

        Assert.That(Driver.Title, Does.Contain("Dashboard"));
    }

    [Test]
    public void NavigateToProducts_ShouldShowProductsPage()
    {
        Driver.FindElement(By.Id("nav-products")).Click();
        Wait.Until(d => d.Url.Contains("/Products"));

        Assert.That(Driver.Title, Does.Contain("Products"));
    }

    [Test]
    public void NavigateToContact_ShouldShowContactPage()
    {
        Driver.FindElement(By.Id("nav-contact")).Click();
        Wait.Until(d => d.Url.Contains("/Contact"));

        Assert.That(Driver.Title, Does.Contain("Contact"));
    }

    [Test]
    public void BrowserBackButton_ShouldNavigateBack()
    {
        Driver.FindElement(By.Id("nav-products")).Click();
        Wait.Until(d => d.Url.Contains("/Products"));

        Driver.FindElement(By.Id("nav-contact")).Click();
        Wait.Until(d => d.Url.Contains("/Contact"));

        Driver.Navigate().Back();
        Wait.Until(d => d.Url.Contains("/Products"));
        Assert.That(Driver.Url, Does.Contain("/Products"));
    }

    [Test]
    public void BrowserForwardButton_ShouldNavigateForward()
    {
        Driver.FindElement(By.Id("nav-products")).Click();
        Wait.Until(d => d.Url.Contains("/Products"));

        Driver.FindElement(By.Id("nav-contact")).Click();
        Wait.Until(d => d.Url.Contains("/Contact"));

        Driver.Navigate().Back();
        Wait.Until(d => d.Url.Contains("/Products"));

        Driver.Navigate().Forward();
        Wait.Until(d => d.Url.Contains("/Contact"));
        Assert.That(Driver.Url, Does.Contain("/Contact"));
    }

    [Test]
    public void VerifyAllNavLinksPresent()
    {
        var dashboardLink = Driver.FindElement(By.Id("nav-dashboard"));
        var productsLink = Driver.FindElement(By.Id("nav-products"));
        var contactLink = Driver.FindElement(By.Id("nav-contact"));

        Assert.Multiple(() =>
        {
            Assert.That(dashboardLink.Displayed, Is.True);
            Assert.That(productsLink.Displayed, Is.True);
            Assert.That(contactLink.Displayed, Is.True);
        });
    }

    [Test]
    public void NavigateByDirectUrl_ShouldLoadPage()
    {
        Driver.Navigate().GoToUrl($"{BaseUrl}/Products");
        Wait.Until(d => d.Url.Contains("/Products"));

        Assert.That(Driver.Title, Does.Contain("Products"));
        Assert.That(Driver.FindElement(By.Id("product-table")).Displayed, Is.True);
    }

    [Test]
    public void RefreshPage_ShouldReloadContent()
    {
        Driver.FindElement(By.Id("nav-products")).Click();
        Wait.Until(d => d.Url.Contains("/Products"));

        var rowsBefore = Driver.FindElements(By.CssSelector("#product-table tbody tr")).Count;

        Driver.Navigate().Refresh();
        Wait.Until(d => d.FindElement(By.Id("product-table")).Displayed);

        var rowsAfter = Driver.FindElements(By.CssSelector("#product-table tbody tr")).Count;
        Assert.That(rowsAfter, Is.EqualTo(rowsBefore));
    }
}
