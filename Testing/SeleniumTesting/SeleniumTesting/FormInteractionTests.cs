using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTesting;

[TestFixture]
[Description("Demonstrates Selenium form interactions — text fields, dropdowns, checkboxes")]
public class FormInteractionTests : TestBase
{
    [SetUp]
    public void FormSetUp()
    {
        Login();
        Driver.FindElement(By.Id("nav-contact")).Click();
        Wait.Until(d => d.Url.Contains("/Contact"));
    }

    [Test]
    public void FillAndSubmitContactForm_ShouldShowSuccessMessage()
    {
        Driver.FindElement(By.Id("name")).SendKeys("John Doe");
        Driver.FindElement(By.Id("email")).SendKeys("john@example.com");
        Driver.FindElement(By.Id("phone")).SendKeys("1234567890");

        var subjectDropdown = new SelectElement(Driver.FindElement(By.Id("subject")));
        subjectDropdown.SelectByText("General Inquiry");

        Driver.FindElement(By.Id("message")).SendKeys("This is a test message from Selenium automation.");

        var subscribeCheckbox = Driver.FindElement(By.Id("subscribe"));
        if (!subscribeCheckbox.Selected)
            subscribeCheckbox.Click();

        Driver.FindElement(By.Id("submit-btn")).Click();

        var successMessage = Wait.Until(d => d.FindElement(By.Id("success-message")));
        Assert.That(successMessage.Displayed, Is.True);
        Assert.That(successMessage.Text, Does.Contain("Thank you"));
    }

    [Test]
    public void SelectDropdownByText_ShouldUpdateValue()
    {
        var subjectDropdown = new SelectElement(Driver.FindElement(By.Id("subject")));

        subjectDropdown.SelectByText("Technical Support");
        Assert.That(subjectDropdown.SelectedOption.Text, Is.EqualTo("Technical Support"));

        subjectDropdown.SelectByText("Feedback");
        Assert.That(subjectDropdown.SelectedOption.Text, Is.EqualTo("Feedback"));
    }

    [Test]
    public void SelectDropdownByValue_ShouldUpdateValue()
    {
        var subjectDropdown = new SelectElement(Driver.FindElement(By.Id("subject")));

        subjectDropdown.SelectByValue("support");
        Assert.That(subjectDropdown.SelectedOption.Text, Is.EqualTo("Technical Support"));

        subjectDropdown.SelectByValue("bug");
        Assert.That(subjectDropdown.SelectedOption.Text, Is.EqualTo("Bug Report"));
    }

    [Test]
    public void SelectDropdownByIndex_ShouldUpdateValue()
    {
        var subjectDropdown = new SelectElement(Driver.FindElement(By.Id("subject")));

        subjectDropdown.SelectByIndex(1); // General Inquiry
        Assert.That(subjectDropdown.SelectedOption.Text, Is.EqualTo("General Inquiry"));

        subjectDropdown.SelectByIndex(3); // Feedback
        Assert.That(subjectDropdown.SelectedOption.Text, Is.EqualTo("Feedback"));
    }

    [Test]
    public void VerifyAllDropdownOptions()
    {
        var subjectDropdown = new SelectElement(Driver.FindElement(By.Id("subject")));
        var options = subjectDropdown.Options.Select(o => o.Text).ToList();

        Assert.Multiple(() =>
        {
            Assert.That(options, Has.Count.EqualTo(5));
            Assert.That(options, Does.Contain("Select a subject"));
            Assert.That(options, Does.Contain("General Inquiry"));
            Assert.That(options, Does.Contain("Technical Support"));
            Assert.That(options, Does.Contain("Feedback"));
            Assert.That(options, Does.Contain("Bug Report"));
        });
    }

    [Test]
    public void ToggleCheckbox_ShouldChangeState()
    {
        var checkbox = Driver.FindElement(By.Id("subscribe"));

        bool initialState = checkbox.Selected;
        checkbox.Click();
        Assert.That(checkbox.Selected, Is.Not.EqualTo(initialState));

        checkbox.Click();
        Assert.That(checkbox.Selected, Is.EqualTo(initialState));
    }

    [Test]
    public void ClearAndRetype_ShouldUpdateFieldValue()
    {
        var nameField = Driver.FindElement(By.Id("name"));

        nameField.SendKeys("Initial Value");
        Assert.That(nameField.GetAttribute("value"), Is.EqualTo("Initial Value"));

        nameField.Clear();
        Assert.That(nameField.GetAttribute("value"), Is.Empty);

        nameField.SendKeys("Updated Value");
        Assert.That(nameField.GetAttribute("value"), Is.EqualTo("Updated Value"));
    }

    [Test]
    public void VerifyPlaceholderText()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Driver.FindElement(By.Id("name")).GetAttribute("placeholder"),
                Is.EqualTo("Enter your name"));
            Assert.That(Driver.FindElement(By.Id("email")).GetAttribute("placeholder"),
                Is.EqualTo("Enter your email"));
            Assert.That(Driver.FindElement(By.Id("phone")).GetAttribute("placeholder"),
                Is.EqualTo("Enter your phone number"));
            Assert.That(Driver.FindElement(By.Id("message")).GetAttribute("placeholder"),
                Is.EqualTo("Type your message here..."));
        });
    }

    [Test]
    public void TabThroughFormFields_ShouldFollowOrder()
    {
        var nameField = Driver.FindElement(By.Id("name"));
        nameField.Click();
        Assert.That(Driver.SwitchTo().ActiveElement().GetAttribute("id"), Is.EqualTo("name"));

        nameField.SendKeys(Keys.Tab);
        Assert.That(Driver.SwitchTo().ActiveElement().GetAttribute("id"), Is.EqualTo("email"));
    }
}
