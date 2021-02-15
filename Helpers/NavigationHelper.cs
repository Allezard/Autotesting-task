using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using ProjectAddressbook.Model;

namespace ProjectAddressbook.Helpers
{
    public class NavigationHelper : BaseHelper
    {
        public NavigationHelper(IWebDriver webDriver)
            : base(webDriver)
        {
        }

        public void GoToURL()
        {
            if (IsloggedIn())
            {
                return;
            }

            webDriver.Manage().Cookies.DeleteAllCookies();
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(BaseHelper.urlLogin);
        }
    }
}
