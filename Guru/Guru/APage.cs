using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace DemoTests
{

    public abstract class APage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected Actions actions;

        public static readonly By submitButton = By.XPath("//input[@value='submit']");
        public static readonly By resetButton = By.XPath("//input[@value='Reset']");

        public APage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            actions = new Actions(driver);
        }
        public void ClickOnElement(By locator)
        {
            IWebElement element = wait.Until( ExpectedConditions.ElementToBeClickable(locator));
            element.Click();
        }
        public bool IsElementPresent(By locator)
        {
            try
            {
                var element = wait.Until(driver => { return ExpectedConditions.ElementIsVisible(locator); });
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public int randomValue = RandomNumber(1, 100);

        public void InputValue(By locator, string inputValue)
        {
            driver.FindElement(locator).SendKeys(inputValue);
        }
    }
}
