using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTests
{
    public class Pages 
    {
        static private IWebDriver driver;
        static private Pages pages;

        private AddCustomerPage addCustomerPage;
        private AddTariffPlanPage addTariffPlanPage;
        private AddTariffPlanToCustomerPage addTariffPlanToCustomerPage;
        private PayBillingPayPage payBillingPage;
        private HomePage homePage;


        public static readonly By addCustomerLink = By.XPath("//h3/a[contains (text(), 'Add Customer')]");
        public static readonly By addTariffPlanToCustomerLink = By.XPath("//h3/a[contains (text(), 'Add Tariff Plan to Customer')]");
        public static readonly By addTariffPlanLink = By.XPath("//div[@class='flex-item right']//h3/a[contains (text(), 'Add Tariff Plan')]");
        public static readonly By payBillingLink = By.XPath("//div[@class='flex-item right']//h3/a[contains (text(), 'Pay Billing')]");
        private Pages()
        {
        }
        public static Pages GetPages()
        {
            if (pages == null)
            {
                pages = new Pages();
                return pages;
            }
            else
            {
                return pages;
            }
        }
        public AddTariffPlanPage AddTariffPlanP => addTariffPlanPage != null ? addTariffPlanPage : new AddTariffPlanPage(driver);
        public AddTariffPlanToCustomerPage AddTariffPlanToCustomerP => addTariffPlanToCustomerPage != null ? addTariffPlanToCustomerPage : new AddTariffPlanToCustomerPage(driver);
        public PayBillingPayPage PayBillingPayPage => payBillingPage != null ? payBillingPage : new PayBillingPayPage(driver);
        public AddCustomerPage AddCustomerP => addCustomerPage != null ? addCustomerPage : new AddCustomerPage(driver);
        public HomePage HomePage => homePage != null ? homePage : new HomePage(driver);

        public AddCustomerPage AddCustomerPage()
        {
            HomePage.ClickOnElement(addCustomerLink);
            return AddCustomerP;
        }

        public AddTariffPlanPage AddTariffPlanPage()
        {
            HomePage.ClickOnElement(addTariffPlanLink);
            return AddTariffPlanP;
        }

        public AddTariffPlanToCustomerPage AddTariffPlanToCustomer()
        {
            HomePage.ClickOnElement(addTariffPlanToCustomerLink);
            return AddTariffPlanToCustomerP;
        }

        public PayBillingPayPage PayBillingPay()
        {
            HomePage.ClickOnElement(payBillingLink);
            return new PayBillingPayPage(driver);
        }
        public static void Initialyze(IWebDriver webDriver)
        {
            driver = webDriver;
        }
       
        public static void QuitDriver()
        {
            driver.Quit();
        }

        public void LoadHomePage()
        {
            driver.Navigate().GoToUrl("http://demo.guru99.com/telecom");
            driver.Manage().Window.Maximize();
        }
    }
}
