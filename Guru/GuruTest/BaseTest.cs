using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using System.IO;

namespace DemoTests
{
    [SetUpFixture]
    class BaseTest 
    {
        IWebDriver Driver { get;  set; }
        
        [OneTimeSetUp]
        public void Init()
        {
#if CHROME
            Driver = new ChromeDriver();
# elif FIREFOX
            Driver = new FirefoxDriver();
            
#endif
            Pages.Initialyze(Driver);
        }
        [OneTimeTearDown]
        public void Clear()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var screen = ((ITakesScreenshot)Driver).GetScreenshot();
                var path = Path.Combine("D:\\FolderWithFailedTestScreens", "FailScreen.png");
                screen.SaveAsFile(path, ScreenshotImageFormat.Png);
                TestContext.AddTestAttachment(path);
            }
            Pages.QuitDriver();
        }
    }
}
