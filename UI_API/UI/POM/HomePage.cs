using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UI_API.Steps;

namespace UI_API.Pages
{
    class HomePage
    {
        private IWebDriver Driver;
        string inchcolor;

        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void CheckHPLoad()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.XPath("//app-mc-image/img")));
        }

        public void VerifyPageTitle()
        {
            Assert.IsTrue(Driver.Title.ToLower().Contains("machiningcloud webapp"));

        }

        public void ClickBrowseCatalogs()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.XPath("//app-mc-image/img")));
            IWebElement catalog = Driver.FindElement(By.XPath("//app-home-item[1]"));
            catalog.Click();
        }

        public void SearchBrand()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.CssSelector(".dialog-title")));
            IWebElement search = Driver.FindElement(By.XPath("//input[@id='searchTextBox']"));
            search.SendKeys("Iscar");
        }

        public void ClickOnSearchBrand()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            IWebElement searchedbrand = Driver.FindElement(By.XPath("//button[2]/img"));
            searchedbrand.Click();
        }

        public string ClickOnCatalogUnit()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.CssSelector("div .unit-toggle-img")));
            IWebElement kebabmenu = Driver.FindElement(By.XPath("//span/mat-icon"));
            kebabmenu.Click();
            IWebElement inchstate = Driver.FindElement(By.XPath("//app-mc-navbar-actions/div/app-mc-preference/div/label[1]"));
            string inchcolor = inchstate.GetCssValue("background-color");
            IWebElement catalogunit = Driver.FindElement(By.CssSelector("div .unit-toggle-img"));
            catalogunit.Click();
            return inchcolor;
        }

        public  void VerifyGlobalUnit()
        {
            inchcolor = ClickOnCatalogUnit();
            IWebElement afterclickstate = Driver.FindElement(By.XPath("//app-mc-navbar-actions/div/app-mc-preference/div/label[1]"));
            Assert.AreNotEqual(inchcolor, afterclickstate);
            Console.WriteLine("Global Unit Switcher working as expected.");
        }


    }
}
