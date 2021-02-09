using System;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using ProjectAddressbook.Helpers;

namespace ProjectAddressbook.Model
{
    public class BaseClass
    {
        protected IWebDriver webDriver;
        protected StringBuilder verificationErrors;
        protected bool acceptNextAlert = true;
        protected LoginHelper LoginHelper;
        protected NavigationHelper NavigationHelper;
        protected TestingGroupHelper TestingGroupHelper;
        protected TestingContactHelper TestingContactHelper;
        protected TearDownHelper TearDownHelper;

        public void SetupFirefoxDriver()
        {
            webDriver = new FirefoxDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Cookies.DeleteAllCookies();
            verificationErrors = new StringBuilder();
            LoginHelper = new LoginHelper(webDriver);
            NavigationHelper = new NavigationHelper(webDriver);
            TestingGroupHelper = new TestingGroupHelper(webDriver);
            TestingContactHelper = new TestingContactHelper(webDriver);
            TearDownHelper = new TearDownHelper(webDriver, verificationErrors);
        }

        public void SetupChromeDriver()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Cookies.DeleteAllCookies();
            verificationErrors = new StringBuilder();
            LoginHelper = new LoginHelper(webDriver);
            NavigationHelper = new NavigationHelper(webDriver);
            TestingGroupHelper = new TestingGroupHelper(webDriver);
            TestingContactHelper = new TestingContactHelper(webDriver);
            TearDownHelper = new TearDownHelper(webDriver, verificationErrors);
        }
    }
}