using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTests
{
    public class AddTariffPlanPage : APage
    {
        public AddTariffPlanPage(IWebDriver driver) : base(driver)
        {

        }

        public static readonly By monthlyRentalField = By.Id("rental1");
        public static readonly By freeLocalMinutesField = By.Id("local_minutes");
        public static readonly By freeInternationalMinutesField = By.Id("inter_minutes");
        public static readonly By freeSMSPackField = By.Id("sms_pack");
        public static readonly By localPerMinutesChargesField = By.Id("minutes_charges");
        public static readonly By internationalPerMinutesChargesField = By.Id("inter_charges");
        public static readonly By SMSPerChargesField = By.Id("sms_charges");
        public static readonly By congratulationYouAddTariffPlanByString = By.XPath("//h2['Congratulation you add Tariff Plan']");
        public static readonly By submitButton = By.XPath("//input[@value='submit']");
        public List<By> ListOfLocators()
        {
            List<By> list = new List<By>(10);
            list.Add(monthlyRentalField);
            list.Add(freeLocalMinutesField);
            list.Add(freeInternationalMinutesField);
            list.Add(freeSMSPackField);
            list.Add(internationalPerMinutesChargesField);
            list.Add(localPerMinutesChargesField);
            list.Add(SMSPerChargesField);
            return list;
        }

        public bool VerifyIfAddTariffPlansFieldsAreEmpty()
        {
            bool res = true;
            foreach (var locator in ListOfLocators())
            {
                if (driver.FindElement(locator).Text != "")
                {
                    res = false;
                    break;
                }
                else
                {
                    res = true;
                }
            }
            return res;
        }
        public void EnterMonthlyRental()
        {
            InputValue(monthlyRentalField, $"{randomValue}");
        }
        public void EnterFreeLocalMinutes()
        {
            InputValue(freeLocalMinutesField, $"{randomValue}");
        }
        public void EnterFreeInternationalMinutesField()
        {
            InputValue(freeInternationalMinutesField, $"{randomValue}");
        }
        public void EnterFreeSMSPackField()
        {
            InputValue(freeSMSPackField, $"{randomValue}");
        }
        public void EnterLocalPerMinutesChargesField()
        {
            InputValue(localPerMinutesChargesField, $"{randomValue}");
        }
        public void EnterInternationalPerMinutesChargesField()
        {
            InputValue(internationalPerMinutesChargesField, $"{randomValue}");
        }
        public void EnterSMSPerChargesField()
        {
            InputValue(SMSPerChargesField, $"{randomValue}");
        }
        public void AddTariffP()
        {
            EnterMonthlyRental();
            EnterFreeLocalMinutes();
            EnterFreeInternationalMinutesField();
            EnterFreeSMSPackField();
            EnterLocalPerMinutesChargesField();
            EnterInternationalPerMinutesChargesField();
            EnterSMSPerChargesField();
            ClickOnElement(submitButton);
        }
        public void FillAllFieldsInAddTariffPlansAndReset()
        {
            EnterMonthlyRental();
            EnterFreeLocalMinutes();
            EnterFreeInternationalMinutesField();
            EnterFreeSMSPackField();
            EnterLocalPerMinutesChargesField();
            EnterInternationalPerMinutesChargesField();
            EnterSMSPerChargesField();
            ClickOnElement(resetButton);
        }
        public bool VerifyIfTarifPlanIsCreated()
        {
            return IsElementPresent(congratulationYouAddTariffPlanByString);
        }

        void CheckIfAddTariffPlansFielsAreEmpty()
        {
            var inputValue = driver.FindElement(monthlyRentalField).Text;
        }
    }
}
