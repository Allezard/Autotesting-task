using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using ProjectAddressbook.Helpers;
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
            webDriver.Navigate().GoToUrl("http://localhost/addressbook/");
        }
    }
}
