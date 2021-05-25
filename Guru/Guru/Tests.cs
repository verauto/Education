using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTests
{
    [TestFixture]
    public class Tests
    {
        Pages pages;

        [SetUp]
        public void Setup()
        {
            pages = Pages.GetPages();
            pages.LoadHomePage();
        }

        [Test]
        public void CheckWhetherMainLogPresent()
        {
           var actualResult = pages.HomePage.LogoIsPresent();
            Assert.IsTrue(actualResult, "Logo is not present on the page");
        }

        [Test]
        public void AddCustomer()
        {
            pages.AddCustomerPage().CreateCustomer();
            //Assert
        }

        [Test]
        public void AddTariffPlan()
        {
           pages.AddTariffPlanPage().AddTariffP();
           bool actualResult = pages.AddTariffPlanP.VerifyIfTarifPlanIsCreated();
           Assert.IsTrue(actualResult, "Tariff Plan is not created");
        }          

        [Test]
        public void CheckAlertAfterEnteringIncorrectValueToCuctomerIDField()
        {
            pages.AddTariffPlanToCustomer().ClickAddTariffPToCustomerSubmit();
            string actualMessage = pages.AddTariffPlanToCustomerP.GetAlertMessage();
            string expectedMessage = "Please Correct Value Input";
            StringAssert.AreEqualIgnoringCase(expectedMessage, actualMessage, "Incorrect alert!");
        }
        [Test]
        public void VerifyPayBillingCustomerIDFieldUsingSpecialCharacters()
        {
            pages.PayBillingPay().EnterIncorrectCharactersToCustomerID("!@#$%^&"); 
            string expectedErrorMessage = "Special characters are not allowed";
            string actualErrorMessage = pages.PayBillingPayPage.GetMessageWithSpecCharacters();
            StringAssert.AreEqualIgnoringCase(expectedErrorMessage, actualErrorMessage, "The message is incorrect!");
        }
        [Test]
        public void VerifyPayBillingCustomerIDFieldSubmitingWithSpaseValue()
        {
            pages.PayBillingPay().EnterIncorrectCharactersToCustomerID(" ");
            string expectedErrorMessage = "Characters are not allowed";
            string actualErrorMessage = pages.PayBillingPayPage.GetMessageWithSpaceField();
            StringAssert.AreEqualIgnoringCase(expectedErrorMessage, actualErrorMessage, "The message is incorrect!");
        }
        [Test]
        public void CheckWhetherResetButtonClearsDataFromInputs()
        {
            pages.AddTariffPlanPage().FillAllFieldsInAddTariffPlansAndReset();
            bool actualValue = pages.AddTariffPlanP.VerifyIfAddTariffPlansFieldsAreEmpty();
            Assert.IsTrue(actualValue, "At least one of the field wasn't reset");
        }
    }
}
