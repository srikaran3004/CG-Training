using NUnit.Framework;
using AventStack.ExtentReports;
using OrangeHRMSAutomation.Pages;

namespace OrangeHRMSAutomation.Tests
{
    public class AddEmployeeTest : BaseTest
    {
        [Test]
        public void AddNewEmployeeTest()
        {
            Test = Extent!.CreateTest("Add New Employee Test").Info("Test Started");

            try
            {
                // Step 1: Login
                var loginPage = new LoginPage(Driver!);
                var dashboardPage = loginPage.LoginAs("Admin", "admin123");
                Assert.That(dashboardPage.IsDashboardDisplayed(), Is.True);
                Test.Info("Logged in successfully");

                // Step 2: Navigate to PIM > Add Employee
                var addEmployeePage = dashboardPage.GoToAddEmployee();
                Test.Info("Navigated to Add Employee page");

                // Step 3: Fill details and save
                bool saved = addEmployeePage.AddEmployee("John", "Doe");
                Assert.That(saved, Is.True, "Employee should be saved successfully");

                Test.Pass("New employee added successfully");
            }
            catch (Exception ex)
            {
                Test.Fail("Test failed: " + ex.Message);
                throw;
            }
        }
    }
}
