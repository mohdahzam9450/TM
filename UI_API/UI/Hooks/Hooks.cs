using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace UI_API.UI.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private DriverHelper _driverHelper;

        public Hooks(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
           // _driverHelper.Driver = new ChromeDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
           // _driverHelper.Driver.Quit();
        }
    }
}
