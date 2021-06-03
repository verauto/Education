using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTests
{
    public class AddTariffPlanToCustomerPage : APage
    {

        public AddTariffPlanToCustomerPage(IWebDriver driver) : base(driver)
        {

        }

        public static readonly By enterYourCustomerIDField = By.Id("customer_id");
        public static readonly By submitButtonAddTariffPlantoCustomerButton = By.Name("submit");

        public void ClickAddTariffPToCustomerSubmit()
        {
            ClickOnElement(submitButton);
        }
        public string GetAlertMessage()
        {
            var alert = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();
            return alert;
        }
    }
}
