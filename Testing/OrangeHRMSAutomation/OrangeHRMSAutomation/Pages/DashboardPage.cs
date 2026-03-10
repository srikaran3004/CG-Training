using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace OrangeHRMSAutomation.Pages
{
    public class DashboardPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        // --- Locators ---
        private By PimMenu => By.XPath("//span[text()='PIM']");

        public DashboardPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // --- Actions ---
        public bool IsDashboardDisplayed()
        {
            try
            {
                _wait.Until(ExpectedConditions.UrlContains("dashboard"));
                return _driver.Url.Contains("dashboard");
            }
            catch
            {
                return false;
            }
        }

        public AddEmployeePage GoToAddEmployee()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(PimMenu));
            _driver.FindElement(PimMenu).Click();

            var addTab = By.XPath("//a[text()='Add Employee']");
            _wait.Until(ExpectedConditions.ElementToBeClickable(addTab));
            _driver.FindElement(addTab).Click();

            return new AddEmployeePage(_driver);
        }
    }
}
