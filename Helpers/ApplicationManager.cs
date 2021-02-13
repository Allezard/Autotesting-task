using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using NUnit.Framework;
using ProjectAddressbook.Model;

namespace ProjectAddressbook.Helpers
{
    public class ApplicationManager
    {
        protected IWebDriver webDriver;
        protected LoginHelper LoginHelper;
        protected NavigationHelper NavigationHelper;
        protected TestingGroupHelper TestingGroupHelper;
        protected TestingContactHelper TestingContactHelper;
        private static readonly ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            webDriver = new ChromeDriver();
            LoginHelper = new LoginHelper(webDriver);
            NavigationHelper = new NavigationHelper(webDriver);
            TestingGroupHelper = new TestingGroupHelper(webDriver);
            TestingContactHelper = new TestingContactHelper(webDriver);
        }

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                app.Value = new ApplicationManager();
            }
            return app.Value;
        }

        public void Stop()
        {
            try
            {
                webDriver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        //~ApplicationManager()
        //{
        //    try
        //    {
        //        webDriver.Quit();
        //    }
        //    catch (Exception)
        //    {
                // Ignore errors if unable to close the browser
        //    }
        //}

        public LoginHelper Auth
        {
            get { return LoginHelper; }
        }

        public NavigationHelper Navigation
        {
            get { return NavigationHelper; }
        }

        public TestingGroupHelper Groups
        {
            get { return TestingGroupHelper; }
        }

        public TestingContactHelper Contacts
        {
            get { return TestingContactHelper; }
        }
    }
}
