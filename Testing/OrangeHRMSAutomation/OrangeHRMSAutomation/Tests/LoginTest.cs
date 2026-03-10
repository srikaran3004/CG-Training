using NUnit.Framework;
using AventStack.ExtentReports;
using OrangeHRMSAutomation.Pages;

namespace OrangeHRMSAutomation.Tests
{
    public class LoginTest : BaseTest
    {
        [Test]
        public void ValidLoginTest()
        {
            Test = Extent!.CreateTest("Valid Login Test").Info("Test Started");

            try
            {
                var loginPage = new LoginPage(Driver!);
                var dashboardPage = loginPage.LoginAs("Admin", "admin123");

                Assert.That(dashboardPage.IsDashboardDisplayed(), Is.True,
                    "Dashboard should be displayed after login");

                Test.Pass("Login successful — Dashboard is displayed");
            }
            catch (Exception ex)
            {
                Test.Fail("Test failed: " + ex.Message);
                throw;
            }
        }
    }
}
