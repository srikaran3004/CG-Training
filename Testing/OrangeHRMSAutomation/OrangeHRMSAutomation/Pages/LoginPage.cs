using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace OrangeHRMSAutomation.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        // --- Locators ---
        private By UsernameField => By.Name("username");
        private By PasswordField => By.Name("password");
        private By LoginButton => By.CssSelector("button[type='submit']");

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // --- Actions ---
        public void EnterUsername(string username)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(UsernameField));
            _driver.FindElement(UsernameField).Clear();
            _driver.FindElement(UsernameField).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            _driver.FindElement(PasswordField).Clear();
            _driver.FindElement(PasswordField).SendKeys(password);
        }

        public DashboardPage ClickLogin()
        {
            _driver.FindElement(LoginButton).Click();
            return new DashboardPage(_driver);
        }

        public DashboardPage LoginAs(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            return ClickLogin();
        }
    }
}
