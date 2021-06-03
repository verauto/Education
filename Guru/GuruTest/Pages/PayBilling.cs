using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTests
{
    public class PayBillingPayPage : APage
    {
        public static readonly By enterYourCustomerID = By.Id("customer_id");
        public static readonly By messageSpecialCharacters = By.XPath("//label['Special characters are not allowed']");
        public static readonly By messageCharactersArentAllowed = By.XPath("//label['Characters are not allowed']");

        public PayBillingPayPage(IWebDriver driver) : base(driver)
        {
        }

        public void EnterIncorrectCharactersToCustomerID(string incorrectValue)
        {
            InputValue(enterYourCustomerID, $"{incorrectValue}");
        }
        public void ClickSubmitButton()
        {
            ClickOnElement(submitButton);
        }
        public string GetMessageWithSpecCharacters()
        {
           return driver.FindElement(messageSpecialCharacters).Text;
        }
        public string GetMessageWithSpaceField()
        {
            return driver.FindElement(messageCharactersArentAllowed).Text;
        }
    }
}
