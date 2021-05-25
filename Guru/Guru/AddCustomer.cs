using OpenQA.Selenium;

namespace DemoTests
{
    public class AddCustomerPage : APage
    {
        public AddCustomerPage(IWebDriver driver) : base (driver)
        {

        }
        public static readonly By firstNameField = By.Id("fname");
        public static readonly By lastNameField = By.Id("lname");
        public static readonly By emailField = By.Id("email");
        public static readonly By addressField = By.Id("message");
        public static readonly By mobileNumberField = By.Id("message7");
        public static readonly By submitAddingCustomerButton = By.XPath("//*[@value='Submit']");
        public static readonly By resetButton = By.XPath("//*[@value='Reset']");

        public void EnterFisrtName()
        {
            driver.FindElement(firstNameField).SendKeys($"First Name");
        }
        public void EnterLastName()
        {
            driver.FindElement(lastNameField).SendKeys($"Last Name");
        }
        public void EnterEmail()
        {
            driver.FindElement(emailField).SendKeys($"email{randomValue}@mail.com");
        }
        public void EnterMobileNumber()
        {
            driver.FindElement(mobileNumberField).SendKeys($"38097{randomValue}");
        }

        public void EnterAddress()
        {
            //need to be finished
            actions.MoveToElement(driver.FindElement(By.Id("message"))).Perform();
            driver.FindElement(By.Id("message")).SendKeys("12345");
        }
        public void Submit()
        {
            ClickOnElement(submitAddingCustomerButton);
        }
        public void CreateCustomer()
        {
            ClickOnElement(firstNameField);
            EnterFisrtName();
            EnterLastName();
            EnterEmail();
            EnterAddress();
            EnterMobileNumber();
            Submit();
        }
    }
}
