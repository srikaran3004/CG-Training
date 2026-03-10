using OpenQA.Selenium;

namespace SeleniumTesting;

[TestFixture]
[Description("Demonstrates Selenium login/logout automation")]
public class LoginTests : TestBase
{
    [Test]
    public void ValidLogin_ShouldRedirectToDashboard()
    {
        Driver.Navigate().GoToUrl(BaseUrl);

        Driver.FindElement(By.Id("username")).SendKeys("admin");
        Driver.FindElement(By.Id("password")).SendKeys("Admin@123");
        Driver.FindElement(By.Id("login-btn")).Click();

        Wait.Until(d => d.Url.Contains("/Dashboard"));
        Assert.That(Driver.Url, Does.Contain("/Dashboard"));

        var welcomeMessage = Driver.FindElement(By.Id("welcome-message"));
        Assert.That(welcomeMessage.Text, Does.Contain("admin"));
    }

    [Test]
    public void InvalidLogin_ShouldShowErrorMessage()
    {
        Driver.Navigate().GoToUrl(BaseUrl);

        Driver.FindElement(By.Id("username")).SendKeys("admin");
        Driver.FindElement(By.Id("password")).SendKeys("wrongpassword");
        Driver.FindElement(By.Id("login-btn")).Click();

        var errorMessage = Wait.Until(d => d.FindElement(By.Id("error-message")));
        Assert.That(errorMessage.Displayed, Is.True);
        Assert.That(errorMessage.Text, Does.Contain("Invalid username or password"));
    }

    [Test]
    public void EmptyCredentials_ShouldShowErrorMessage()
    {
        Driver.Navigate().GoToUrl(BaseUrl);

        Driver.FindElement(By.Id("login-btn")).Click();

        var errorMessage = Wait.Until(d => d.FindElement(By.Id("error-message")));
        Assert.That(errorMessage.Displayed, Is.True);
        Assert.That(errorMessage.Text, Does.Contain("Please enter both username and password"));
    }

    [Test]
    public void Logout_ShouldRedirectToLoginPage()
    {
        Login();

        Driver.FindElement(By.Id("logout-btn")).Click();

        Wait.Until(d => d.FindElement(By.Id("login-btn")).Displayed);
        Assert.That(Driver.FindElement(By.Id("login-btn")).Displayed, Is.True);
    }

    [Test]
    public void LoginAsUser_ShouldShowUserRole()
    {
        Login("user", "User@123");

        var roleElement = Driver.FindElement(By.Id("user-role"));
        Assert.That(roleElement.Text, Does.Contain("Standard User"));
    }

    [Test]
    public void LoginAsAdmin_ShouldShowAdminRole()
    {
        Login("admin", "Admin@123");

        var roleElement = Driver.FindElement(By.Id("user-role"));
        Assert.That(roleElement.Text, Does.Contain("Administrator"));
    }

    [Test]
    public void AccessProtectedPage_WithoutLogin_ShouldRedirectToLogin()
    {
        Driver.Navigate().GoToUrl($"{BaseUrl}/Dashboard");

        Wait.Until(d => d.FindElement(By.Id("login-btn")).Displayed);
        Assert.That(Driver.FindElement(By.Id("login-btn")).Displayed, Is.True);
    }
}
