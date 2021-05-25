using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTests
{
    public class HomePage: APage
    {
        public HomePage(IWebDriver driver) : base (driver)
        {

        }
        public static readonly By homeButton = By.LinkText("index.html");
        public static readonly By mainLogo = By.XPath("//*[contains(text(), 'Guru99 telecom')]");
        
        public bool LogoIsPresent()
        {
           return IsElementPresent(mainLogo);
        }
    }
}
