using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace OrangeHRMSAutomation.Pages
{
    public class AddEmployeePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        // --- Locators ---
        private By FirstNameField => By.Name("firstName");
        private By LastNameField => By.Name("lastName");
        private By SaveButton => By.CssSelector("button[type='submit']");
        private By SuccessHeader => By.XPath("//h6[text()='Personal Details']");

        public AddEmployeePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // --- Actions ---
        public void EnterFirstName(string firstName)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(FirstNameField));
            _driver.FindElement(FirstNameField).Clear();
            _driver.FindElement(FirstNameField).SendKeys(firstName);
        }

        public void EnterLastName(string lastName)
        {
            _driver.FindElement(LastNameField).Clear();
            _driver.FindElement(LastNameField).SendKeys(lastName);
        }

        public void ClickSave()
        {
            _driver.FindElement(SaveButton).Click();
        }

        public bool IsEmployeeSaved()
        {
            try
            {
                _wait.Until(ExpectedConditions.ElementIsVisible(SuccessHeader));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddEmployee(string firstName, string lastName)
        {
            EnterFirstName(firstName);
            EnterLastName(lastName);
            ClickSave();
            return IsEmployeeSaved();
        }
    }
}
